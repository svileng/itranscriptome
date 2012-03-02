using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;
using System.IO;
using System.Text.RegularExpressions;
using ExperimentsManager.Helpers;
using System.Windows.Forms;

namespace ExperimentsManager.Controllers
{
    /// <summary>Manages Experiment related actions</summary>
    /// <remarks>The controller caches data which needs to be updated when original data changes.</remarks>
    public class ExperimentsController
    {
        #region Public Static Properties
        /// <summary>Flag which tells the controller whether or not to fetch data from db</summary>
        /// <remarks>IMPORTANT: Don't forget to update the flag when an Experiment is added/deleted/updated!</remarks>
        public static bool ExperimentsCacheExpired { get; set; } 
        #endregion

        #region Private Instance Variables
        /// <summary>Cached copy of all experiments in db</summary>
        private Experiment[] cachedExperiments;
        #endregion

        #region Constructors
        /// <summary>Default constructor</summary>
        public ExperimentsController()
        {
            ExperimentsCacheExpired = true; // no data was cached yet
        }
        #endregion

        #region Public Instance Methods
        
        /// <summary>Load experiment data from a CSV file into database</summary>
        /// <param name="path">Path to CSV file containig the data</param>
        public void LoadExperimentFromCsvFile(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    Experiment experiment = new Experiment();

                    string lineFromFile = null;
                    while ((lineFromFile = reader.ReadLine()) != null)
                    {
                        ExperimentHelper.SetExperimentPropertyFromCsvLine(experiment, lineFromFile);
                    }

                    experiment.Save(); // will save as new experiment

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>Returns all experiments stored database</summary>
        /// <returns>Array of Experiments</returns>
        public Experiment[] GetAllExperiments()
        {
            if (ExperimentsCacheExpired)
            {
                cachedExperiments = Experiment.All();
            }

            return cachedExperiments;
        }

        public Experiment FindExperimentByDataset(string dataset)
        {
            return Experiment.FindBy(dataset);
        }

        public void UpdateExperimentTags(string dataset, string tags)
        {
            Experiment experiment = FindExperimentByDataset(dataset);
            experiment.Tags = tags;
            experiment.Update();
        }

        #endregion
    }
}
