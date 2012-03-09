using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Distributions;
using ExperimentsManager.Helpers;

namespace ExperimentsManager.Controllers
{
    /// <summary>Manages the Experiment Selection algorithm part of the application</summary>
    public class ExperimentSelectionController
    {
        #region Private Properties
        private int Seeds { get; set; }
        private double Significance { get; set; }
        private string[] Identifiers { get; set; }
        private Experiment[] Experiments { get; set; }
        #endregion

        #region Constructors
        /// <summary>Default constructor</summary>
        public ExperimentSelectionController(int seeds, double significance, string[] identifiers, Experiment[] experiments)
        {
            if (identifiers == null || identifiers.Count() == 0 || experiments == null || experiments.Count() <= 1) {
                throw new ArgumentNullException("Invalid arguments, experiment selection aborted");
            }

            Seeds = seeds;
            Significance = significance;
            Identifiers = identifiers;
            Experiments = experiments;
        }
        #endregion

        public void RunAlgorithm()
        { 
            foreach (Experiment e in Experiments) 
            {
                // depending on the size of the dataset table, this could take a second or a few seconds to load

                e.LoadDatasetTable();

                // compute pairwise correlation

                CorrelationTable ct = new CorrelationTable();

                for (int i = 0; i < e.DatasetTable.Count; i++)
                {
                    DatasetTableRow rowA = e.DatasetTable[i];

                    for (int k = i + 1; k < e.DatasetTable.Count; k++)
                    {
                        DatasetTableRow rowB = e.DatasetTable[k];

                        string id_a = rowA.Identifier;
                        string id_b = rowB.Identifier;

                        if (!ct.CorrelationExist(id_a, id_b))
                        {
                            double[] valuesA = ExperimentHelper.MakeArrayFromStringValues(rowA.Value);
                            double[] valuesB = ExperimentHelper.MakeArrayFromStringValues(rowB.Value);
                            double correlation = Correlation.Pearson(valuesA, valuesB);

                            CorrelationResult cr = new CorrelationResult(id_a, id_b, correlation);
                            ct.Correlations.Add(cr);
                        }
                    }
                }

                // select the rows which correspond to the supplied identifiers

                List<CorrelationResult> selectedIdentifiers = new List<CorrelationResult>();
                for (int i = ct.Correlations.Count - 1; i >= 0; i--)
                {
                    CorrelationResult cr = ct.Correlations[i];
                    if (Identifiers.Contains(cr.IdentifierA) && Identifiers.Contains(cr.IdentifierB))
                    {
                        selectedIdentifiers.Add(cr);
                        ct.Correlations.RemoveAt(i);
                    }
                }
            }
        }
    }

    class CorrelationResult
    {
        public string IdentifierA { get; private set; }
        public string IdentifierB { get; private set; }
        public double Value { get; private set; }

        public CorrelationResult(string id_a, string id_b, double value)
        {
            IdentifierA = id_a;
            IdentifierB = id_b;
            Value = value;
        }
    }

    class CorrelationTable
    {
        public List<CorrelationResult> Correlations { get; set; }

        public CorrelationTable()
        {
            Correlations = new List<CorrelationResult>();
        }

        public bool CorrelationExist(string id_a, string id_b)
        {
            bool result = false;

            for (int i = 0; i < Correlations.Count() && !result; i++)
            {
                CorrelationResult cr = Correlations[i];
                if ((cr.IdentifierA == id_a && cr.IdentifierB == id_b) || (cr.IdentifierA == id_b && cr.IdentifierB == id_a))
                {
                    result = true;
                }
            }

            return result;
        }
    }

    /// <summary>TTest class by George Bell, sharpstatistics.co.uk (http://sharpstatistics.co.uk/stats/t-test-in-c/)</summary>
    public class TTest
    {
        private StudentT tDistribution = new StudentT();
        private double testStatistic;
        private double p;

        public double TestStatistics
        {
            get { return testStatistic; }
        }

        public double PValue
        {
            get { return p; }
        }

        public double DegreesOfFreedom
        {
            get { return tDistribution.DegreesOfFreedom; }
        }

        //Two sided one sample t test
        public TTest(double[] data, double testValue)
        {
            tDistribution.DegreesOfFreedom = data.Length;
            testStatistic = T(data.Average(), testValue, Statistics.Variance(data), data.Length);
            p = 2.0 * tDistribution.CumulativeDistribution(-1.0 * testStatistic);
        }

        public TTest(double[] data1, double[] data2, bool equalVariance)
        {
            if (equalVariance)
            {
                tDistribution.DegreesOfFreedom = data1.Length + data2.Length - 2;
                testStatistic = Math.Abs(T2Equal(data1.Average(), data2.Average(), Statistics.Variance(data1),
                    Statistics.Variance(data2), data1.Length, data2.Length));
            }
            else
            {
                tDistribution.DegreesOfFreedom = DOF(Statistics.Variance(data1), Statistics.Variance(data2),
                    data1.Length, data2.Length);
                testStatistic = Math.Abs(T2Unequal(data1.Average(), data2.Average(), Statistics.Variance(data1),
                    Statistics.Variance(data2), data1.Length, data2.Length));
            }
            p = 2.0 * tDistribution.CumulativeDistribution(-testStatistic);
        }

        //test statistic for 1-sample t-test
        private double T(double sampleMean, double constant, double sampleVariance, double length)
        {
            return (sampleMean - constant) / Math.Sqrt(sampleVariance / length);
        }

        //test statistic for 2-sample test does not assume equal variance
        private double T2Unequal(double mean1, double mean2, double variance1, double variance2, double length1,
            double length2)
        {
            return (mean1 - mean2) / Math.Sqrt((variance1 / length1) + (variance2 / length2));
        }

        //test statistic for 2-sample test does assume equal variance
        private double T2Equal(double mean1, double mean2, double variance1, double variance2, double length1,
            double length2)
        {
            double Variance = ((length1 - 1.0) * variance1 + (length2 - 1.0) * variance2) / (length1 + length2 - 2.0);
            return (mean1 - mean2) / Math.Sqrt(Variance * (1.0 / length1 + 1.0 / length2));
        }

        //Degrees of freedom to 2 sample unequal variance
        private double DOF(double variance1, double variance2, double length1, double length2)
        {
            double nom = ((variance1 / length1) + (variance2 / length2)) * ((variance1 / length1) + (variance2 / length2));
            double denom = ((variance1 * variance1) / (length1 * length1 * (length1 - 1.0)) + (variance2 * variance2) /
                (length2 * length2 * (length2 - 1.0)));
            return nom / denom;
        }
    }
}
