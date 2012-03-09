using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExperimentsManager.Helpers;
using ExperimentsManager.Models;

namespace MainTest
{
    [TestClass]
    public class SqlFactoryShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenInsertingExperiment()
        {
            SqlFactory.CreateInsertExperimentQueryFromObject(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenInsertingDataset()
        {
            SqlFactory.CreateInsertDatasetTableRowsQueryFromObject(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenInsertingGSMs()
        {
            SqlFactory.CreateInsertGSMQueryFromObject(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenSelectingExperiment()
        {
            SqlFactory.CreateSelectExperimentQuery(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenSelectingGSMs()
        {
            SqlFactory.CreateSelectGSMsForExperimentQuery(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenSelectingDatasetRows()
        {
            SqlFactory.CreateSelectDatasetTableRowsForExperimentQuery(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenDeletingExperiment()
        {
            SqlFactory.CreateDeleteExperimentQueryFromObject(null);
        }

        [TestMethod]
        public void ReturnSelectAllExperimentsQuery()
        {
            string query = SqlFactory.CreateSelectAllExperimentsQuery();

            Assert.IsTrue(query != "" && query.Contains("SELECT * FROM experiments"));
        }

        [TestMethod]
        public void ReturnDeleteQueryForExperimentAndRelatedData()
        {
            Experiment e = new Experiment();
            e.Dataset = "foobar";

            string query = SqlFactory.CreateDeleteExperimentQueryFromObject(e);
            bool deleteFromExperiments = query.Contains("DELETE FROM experiments WHERE dataset = 'foobar'");
            bool deleteGSMsData = query.Contains("DELETE FROM gsms_data WHERE experiment_id = 'foobar'");
            bool deleteFromDatasets = query.Contains("DELETE FROM datasets WHERE experiment_id = 'foobar'");

            Assert.IsTrue(deleteFromExperiments && deleteGSMsData && deleteFromDatasets);
        }
    }
}
