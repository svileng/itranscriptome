using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;
using System.IO;
using System.Text.RegularExpressions;
using ExperimentsManager.Helpers;
using System.Windows.Forms;
using ExperimentsManager.Views;

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
        /// <remarks>Will update experiments cache if needed</remarks>
        /// <returns>Array of Experiments</returns>
        public Experiment[] GetAllExperiments()
        {
            if (ExperimentsCacheExpired)
            {
                cachedExperiments = Experiment.All();
                ExperimentsCacheExpired = false;
            }

            return cachedExperiments;
        }

        /// <summary>Get the experiment corresponding to the given unique dataset id</summary>
        /// <param name="dataset">Dataset to look for</param>
        /// <returns>Experiment with that dataset</returns>
        public Experiment FindExperimentByDataset(string dataset)
        {
            Experiment result = null;

            if (ExperimentsCacheExpired)
            {
                result = Experiment.FindBy(dataset);
            }
            else
            {
                foreach (Experiment e in cachedExperiments)
                {
                    if (e.Dataset == dataset)
                    {
                        result = e;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>Update an experiment with new tags</summary>
        /// <param name="dataset">Unique dataset for the experiment to update</param>
        /// <param name="tags">The tags to set</param>
        public void UpdateExperimentTags(string dataset, string tags)
        {
            Experiment experiment = FindExperimentByDataset(dataset);
            experiment.Tags = tags;
            experiment.Update();
        }

        /// <summary>Will delete the experiment and its associated data (gsms, datasetrows) from the database</summary>
        /// <param name="dataset">Experiment's unique dataset id</param>
        public void DeleteExperiment(string dataset)
        {
            Experiment experiment = FindByDataset(dataset);
            experiment.Delete();
        }

        public void ShowDetailsForExperiment(string dataset)
        {
            Experiment experiment = FindByDataset(dataset);
            using (ExperimentDetailsForm form = new ExperimentDetailsForm(experiment))
            {
                form.ShowDialog();
            }
        }

        #endregion
    }
}
