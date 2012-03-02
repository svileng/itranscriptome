using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;
using System.Data.SQLite;

namespace ExperimentsManager.Helpers
{
    /// <summary>Helper methods for/related the DatasetTableRow model</summary>
    public static class DatasetTableRowHelper
    {
        /// <summary>Will add a DatasetTableRow from db to the given Experiment</summary>
        /// <param name="experiment">Experiment to have its GSMs property updated</param>
        public static void AddDatasetTableRowToExperimentFromDb(Experiment experiment, SQLiteDataReader reader)
        {
            DatasetTableRow dtr = new DatasetTableRow(reader["id_ref"].ToString(), reader["identifier"].ToString(), reader["value"].ToString());
            dtr.Id = Convert.ToInt32(reader["id"].ToString());
            dtr.ExperimentId = reader["experiment_id"].ToString();
            experiment.DatasetTable.Add(dtr);
        }
    }
}
