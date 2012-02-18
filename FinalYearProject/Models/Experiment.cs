using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using ExperimentsManager.Helpers;
using ExperimentsManager.Controllers;

namespace ExperimentsManager.Models
{
    /// <summary>Represents an Experiment in the system</summary>
    /// <remarks>Represents data from the database table 'experiments'</remarks>
    public class Experiment
    {
        #region Properties

        public int Id { get; set; }
        public string Database { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseInstitute { get; set; }
        public string DatabaseWebLink { get; set; }
        public string DatabaseEmail { get; set; }
        public string DatabaseRef { get; set; }
        public string Dataset { get; set; }
        public string DatasetTitle { get; set; }
        public string DatasetDescription { get; set; }
        public string DatasetType { get; set; }
        public string DatasetPubmedId { get; set; }
        public string DatasetPlatform { get; set; }
        public string DatasetPlatformOrganism { get; set; }
        public string DatasetPlatformTechnologyType { get; set; }
        public string DatasetFeatureCount { get; set; }
        public string DatasetSampleOrganism { get; set; }
        public string DatasetSampleType { get; set; }
        public string DatasetReferenceSeries { get; set; }
        public string DatasetUpdateDate { get; set; }
        public string Tags { get; set; }
        public List<ExperimentGSM> GSMs { get; set; }

        #endregion

        #region Constructors
        /// <summary>Default constructor</summary>
        public Experiment()
        {
            GSMs = new List<ExperimentGSM>();
        }
        #endregion

        #region Public Instance Methods

        /// <summary>Saves the experiment object as a new experiment in the database</summary>
        /// <remarks>Method will not overwrite or update existing data</remarks>
        public void Save()
        {
            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();
            try
            {
                SQLiteCommand command = new SQLiteCommand(dbConnection);
                command.CommandText = SqlFactory.CreateInsertExperimentQueryFromObject(this);

                try {
                    command.ExecuteNonQuery();
                    ExperimentsController.ExperimentsCacheExpired = true;
                } catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public void Update()
        {
            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();
            try
            {
                SQLiteCommand command = new SQLiteCommand(dbConnection);
                command.CommandText = SqlFactory.CreateUpdateExperimentQueryFromObject(this);
                
                try {
                    command.ExecuteNonQuery();
                    ExperimentsController.ExperimentsCacheExpired = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            finally
            {
                dbConnection.Close();
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>Get all experiments from database</summary>
        /// <returns>Array of Experiments</returns>
        public static Experiment[] All()
        {
            List<Experiment> result = new List<Experiment>();
          
            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();

            try {
                
                SQLiteCommand command = new SQLiteCommand(dbConnection);
                command.CommandText = SqlFactory.CreateSelectAllExperimentsQuery();   
                using (SQLiteDataReader reader = command.ExecuteReader()) 
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Experiment experiment = new Experiment();
                            ExperimentHelper.SetExperimentPropertiesFromDb(experiment, reader);
                            result.Add(experiment);
                        }
                    }
                }

                foreach (Experiment experiment in result)
                {
                    command.CommandText = SqlFactory.CreateSelectGSMsForExperimentQuery(experiment.Dataset);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            experiment.GSMs.Clear();
                            while (reader.Read())
                            {
                                ExperimentGSMHelper.SetExperimentGSMsFromDb(experiment, reader);
                            }
                        }
                    }
                }

            } finally {
                dbConnection.Close();
            }

            return result.ToArray();
        }

        public static Experiment FindBy(string condition)
        {
            Experiment result = null;

            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();

            try {
                SQLiteCommand command = new SQLiteCommand(dbConnection);
                command.CommandText = SqlFactory.CreateSelectExperimentQuery(condition);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        result = new Experiment();
                        ExperimentHelper.SetExperimentPropertiesFromDb(result, reader);
                    }
                }

                command.CommandText = SqlFactory.CreateSelectGSMsForExperimentQuery(result.Dataset);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        result.GSMs.Clear();
                        while (reader.Read())
                        {
                            ExperimentGSMHelper.SetExperimentGSMsFromDb(result, reader);
                        }
                    }
                }

            } finally {
                dbConnection.Close();
            }

            return result;
        }

        #endregion

    }
}
