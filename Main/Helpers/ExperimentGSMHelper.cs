using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;
using System.Data.SQLite;

namespace ExperimentsManager.Helpers
{
    /// <summary>Helper methods related to the ExperimentGSM model</summary>
    public static class ExperimentGSMHelper
    {
        /// <summary>Will add GSMs from db to the given Experiment</summary>
        /// <param name="experiment">Experiment to have its GSMs property updated</param>
        public static void AddExperimentGSMToExperimentFromDb(Experiment experiment, SQLiteDataReader reader)
        {
            ExperimentGSM gsm = new ExperimentGSM(reader["gsm_id"].ToString(), reader["gsm_value"].ToString());
            gsm.Id = Convert.ToInt32(reader["id"].ToString());
            gsm.ExperimentId = reader["experiment_id"].ToString();                 
            experiment.GSMs.Add(gsm);
        }
    }
}
