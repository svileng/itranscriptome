using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExperimentsManager.Views;

namespace MainTest
{
    [TestClass]
    public class MainFormShould
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionIfControllerIsNull()
        {
            MainForm form = new MainForm(null);
        }
    }
}
