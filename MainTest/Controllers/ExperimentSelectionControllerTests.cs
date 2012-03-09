using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExperimentsManager.Controllers;
using ExperimentsManager.Models;

namespace MainTest.Controllers
{
    [TestClass]
    public class ExperimentSelectionControllerShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionIfSelectedExperimentsNotGreaterThanOne()
        {
            Experiment[] experiments = new Experiment[] { new Experiment() };
            string[] identifiers = new string[] { "foor", "bar" };
            ExperimentSelectionController controller = new ExperimentSelectionController(0, 0.0, identifiers, experiments.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionIfNoIdentifiersAreSelected()
        {
            Experiment[] experiments = new Experiment[] { new Experiment(), new Experiment() };
            string[] identifiers = new string[0];
            ExperimentSelectionController controller = new ExperimentSelectionController(0, 0.0, identifiers, experiments.ToArray());
        }
    }
}
