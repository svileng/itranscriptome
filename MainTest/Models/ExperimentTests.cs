using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExperimentsManager.Models;

namespace MainTest.Models
{
    [TestClass]
    public class ExperimentShould
    {
        [TestMethod]
        public void CreateEmptyListsWhenInitialised()
        {
            Experiment ex = new Experiment();
            Assert.IsNotNull(ex.GSMs);
            Assert.IsNotNull(ex.DatasetTable);
        }
    }
}
