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
        public List<DatasetTableRow> DatasetTable { get; set; }

        #endregion

        #region Constructors
        /// <summary>Default constructor</summary>
        public Experiment()
        {
            GSMs = new List<ExperimentGSM>();
            DatasetTable = new List<DatasetTableRow>();
        }
        #endregion

        #region Public Instance Methods

        /// <summary>Saves the experiment object as a new experiment in the database</summary>
        /// <remarks>
        /// Method will not overwrite or update existing data.
        /// Also: the method can take considerable amount of time 
        /// depending on the size of the dataset table of the experiment.
        /// </remarks>
        public void Save()
        {
            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();
            try
            {
                SQLiteCommand insertExperimentCommand = new SQLiteCommand(dbConnection);
                SQLiteCommand insertGSMsCommand = new SQLiteCommand(dbConnection);
                SQLiteCommand insertDatasetsCommand = new SQLiteCommand(dbConnection);

                insertExperimentCommand.CommandText = SqlFactory.CreateInsertExperimentQueryFromObject(this);
                insertGSMsCommand.CommandText = SqlFactory.CreateInsertGSMQueryFromObject(this);
                insertDatasetsCommand.CommandText = SqlFactory.CreateInsertDatasetTableRowsQueryFromObject(this);

                try {
                    insertExperimentCommand.ExecuteNonQuery();
                    insertGSMsCommand.ExecuteNonQuery();
                    insertDatasetsCommand.ExecuteNonQuery();
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

        /// <summary>Loads the dataset table for the experiment from the database</summary>
        /// <remarks>Since this operation can take a second or two, it can visible freeze the UI for a bit.
        /// Load the dataset table only when necessary and preferably in a separate thread.</remarks>
        public void LoadDatasetTable()
        {
            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();

            try {
                SetDatasetTableRows(this, new SQLiteCommand(dbConnection));
            } finally {
                dbConnection.Close();
            }
        }

        public void Delete()
        {
            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();
            try
            {
                SQLiteCommand command = new SQLiteCommand(dbConnection);
                command.CommandText = SqlFactory.CreateDeleteExperimentQueryFromObject(this);

                try
                {
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
        /// <returns>Array of all Experiments</returns>
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
                    // get experiment GSMs
                    SetExperimentGSMs(experiment, command);
                }

            } finally {
                dbConnection.Close();
            }

            return result.ToArray();
        }

        /// <summary>Find an experiment in the database by given condition</summary>
        /// <remarks>Conditions currently supported (see the SQL query) are: dataset, database_name and database_used</remarks>
        /// <param name="condition">Condition to look for</param>
        /// <returns>Experiment matching the condition or null if one was not found</returns>
        public static Experiment FindBy(string condition)
        {
            Experiment result = null;

            SQLiteConnection dbConnection = DatabaseManager.Instance.Connection;
            dbConnection.Open();

            try {

                // get experiment metadata

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

                // get experiment GSMs
                SetExperimentGSMs(result, command);

            } finally {
                dbConnection.Close();
            }

            return result;
        }

        #endregion

        #region Private Static Methods

        /// <summary>Selects, reads and sets Experiment GSMs for Experiment</summary>
        /// <param name="result">Experiment to update</param>
        /// <param name="command">Command to use for the select the query</param>
        private static void SetExperimentGSMs(Experiment result, SQLiteCommand command)
        {
            command.CommandText = SqlFactory.CreateSelectGSMsForExperimentQuery(result.Dataset);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    result.GSMs.Clear();
                    while (reader.Read())
                    {
                        ExperimentGSMHelper.AddExperimentGSMToExperimentFromDb(result, reader);
                    }
                }
            }
        }

        /// <summary>Selects, reads and sets the DatasetTable for Experiment</summary>
        /// <param name="result">Experiment to update</param>
        /// <param name="command">Command to use for the select the query</param>
        private static void SetDatasetTableRows(Experiment result, SQLiteCommand command)
        {
            command.CommandText = SqlFactory.CreateSelectDatasetTableRowsForExperimentQuery(result.Dataset);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    result.DatasetTable.Clear();
                    while (reader.Read())
                    {
                        DatasetTableRowHelper.AddDatasetTableRowToExperimentFromDb(result, reader);
                    }
                }
            }
        }

        #endregion
    }
}