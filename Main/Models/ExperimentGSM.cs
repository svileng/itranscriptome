using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExperimentsManager.Models
{
    /// <summary>Represents GSM data for an Experiment</summary>
    public class ExperimentGSM
    {
        #region Properties
        public int Id { get; set; }
        public string ExperimentId { get; set; }
        public string GSMId { get; set; }
        public string Value { get; set; }
        #endregion

        #region Constructors
        /// <summary>Default constructor</summary>
        /// <param name="id">The GSM number</param>
        /// <param name="value">GSM value</param>
        public ExperimentGSM(string id, string value)
        {
            GSMId = id;
            Value = value;
        }
        #endregion
    }
}
