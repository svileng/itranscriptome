using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExperimentsManager.Controllers;
using System.IO;

namespace MainTest.Controllers
{
    [TestClass]
    public class ExperimentsControllerShould
    {
        ExperimentsController controller;

        [TestInitialize]
        public void Init()
        {
            controller = new ExperimentsController();
        }

        [TestMethod]
        public void HaveItsCacheExpiredWhenInitialised()
        {
            Assert.IsTrue(ExperimentsController.ExperimentsCacheExpired);
        }

    }
}
