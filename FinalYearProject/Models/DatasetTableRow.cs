using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExperimentsManager.Models
{
    /// <summary>Represents a dataset for an Experiment</summary>
    public class DatasetTableRow
    {
        #region Properties
        public int Id { get; set; }
        public string ExperimentId { get; set; }
        public string IdRef { get; set; }
        public string Identifier { get; set; }
        public string Value { get; set; }
        #endregion

        #region Constructors
        public DatasetTableRow(string idref, string identifier, string value)
        {
            IdRef = idref;
            Identifier = identifier;
            Value = value;
        }
        #endregion
    }
}
