using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;

namespace ExperimentsManager.Controllers
{
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
            if (seeds == null || significance == null || identifiers == null || identifiers.Count() == 0 || experiments == null || experiments.Count() <= 1) {
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



        }
    }
}
