using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;
using System.Data.SQLite;

namespace ExperimentsManager.Helpers
{
    /// <summary>Helper methods for the Experiment model/controller</summary>
    public static class ExperimentHelper
    {
        #region Public Static Methods
        
        /// <summary>Will set all Experiment properties using data from database</summary>
        /// <param name="experiment">Experiment to have its properties set</param>
        /// <param name="reader">The database reader containing columns data</param>
        public static void SetExperimentPropertiesFromDb(Experiment experiment, SQLiteDataReader reader)
        {
            experiment.Id = Convert.ToInt32(reader["id"].ToString());
            experiment.Database = reader["database_used"].ToString();
            experiment.DatabaseName = reader["database_name"].ToString();
            experiment.DatabaseInstitute = reader["database_institute"].ToString();
            experiment.DatabaseWebLink = reader["database_web_link"].ToString();
            experiment.DatabaseEmail = reader["database_email"].ToString();
            experiment.DatabaseRef = reader["database_ref"].ToString();
            experiment.Dataset = reader["dataset"].ToString();
            experiment.DatasetDescription = reader["dataset_description"].ToString();
            experiment.DatasetFeatureCount = reader["dataset_feature_count"].ToString();
            experiment.DatasetPlatform = reader["dataset_platform"].ToString();
            experiment.DatasetPlatformOrganism = reader["dataset_platform_organism"].ToString();
            experiment.DatasetPlatformTechnologyType = reader["dataset_platform_technology_type"].ToString();
            experiment.DatasetPubmedId = reader["dataset_pubmed_id"].ToString();
            experiment.DatasetReferenceSeries = reader["dataset_reference_series"].ToString();
            experiment.DatasetSampleOrganism = reader["dataset_sample_organism"].ToString();
            experiment.DatasetSampleType = reader["dataset_sample_type"].ToString();
            experiment.DatasetTitle = reader["dataset_title"].ToString();
            experiment.DatasetType = reader["dataset_type"].ToString();
            experiment.DatasetUpdateDate = reader["dataset_update_date"].ToString();
            experiment.Tags = reader["tags"].ToString();
        }

        /// <summary>Sets an Experiment property from given data</summary>
        /// <remarks>Method will figure out which property exactly to update</remarks>
        /// <param name="experiment">Experiment to be updated</param>
        /// <param name="lineFromCsvFile">Data from CSV containing the value to be set</param>
        public static void SetExperimentPropertyFromCsvLine(Experiment experiment, string lineFromCsvFile)
        {
            if (lineFromCsvFile.Contains("="))
            {
                string[] data = lineFromCsvFile.Split('=');
                data = Normalise(data);

                switch (data[0])
                {
                    case "^DATABASE":
                        experiment.Database = data[1];
                        break;
                    case "!Database_name":
                        experiment.DatabaseName = data[1];
                        break;
                    case "!Database_institute":
                        experiment.DatabaseInstitute = data[1];
                        break;
                    case "!Database_web_link":
                        experiment.DatabaseWebLink = data[1];
                        break;
                    case "!Database_email":
                        experiment.DatabaseEmail = data[1];
                        break;
                    case "!Database_ref":
                        experiment.DatabaseRef = data[1];
                        break;
                    case "^DATASET":
                        experiment.Dataset = RemoveDotsAndCommas(data[1]);
                        break;
                    case "!dataset_title":
                        experiment.DatasetTitle = data[1];
                        break;
                    case "!dataset_description":
                        experiment.DatasetDescription = data[1];
                        break;
                    case "!dataset_type":
                        experiment.DatasetType = data[1];
                        break;
                    case "!dataset_pubmed_id":
                        experiment.DatasetPubmedId = data[1];
                        break;
                    case "!dataset_platform":
                        experiment.DatasetPlatform = data[1];
                        break;
                    case "!dataset_platform_organism":
                        experiment.DatasetPlatformOrganism = data[1];
                        break;
                    case "!dataset_platform_technology_type":
                        experiment.DatasetPlatformTechnologyType = data[1];
                        break;
                    case "!dataset_feature_count":
                        experiment.DatasetFeatureCount = data[1];
                        break;
                    case "!dataset_sample_organism":
                        experiment.DatasetSampleOrganism = data[1];
                        break;
                    case "!dataset_sample_type":
                        experiment.DatasetSampleType = data[1];
                        break;
                    case "!dataset_reference_series":
                        experiment.DatasetReferenceSeries = data[1];
                        break;
                    case "!dataset_update_date":
                        experiment.DatasetUpdateDate = data[1];
                        break;
                }

                if (data[0].StartsWith("#GSM"))
                {
                    ExperimentGSM gsm = new ExperimentGSM(data[0], data[1]);
                    experiment.GSMs.Add(gsm);
                }
            }
        }

        #endregion

        #region Private Static Methods
        
        /// <summary>Normalises odd data to a standard usable format</summary>
        /// <param name="data">Data to normalise</param>
        /// <returns>Normalised strings</returns>
        private static string[] Normalise(string[] data)
        {
            // separator actually is " = " (with whitespace) but Split() requires a char,
            // so we have to explicitly remove the whitespaces ourselves
            data[0] = data[0].TrimEnd();
            data[1] = data[1].TrimStart();

            // some occurances start with a quote, which is then escaped by Excel, so we remove these bits
            if (data[0].StartsWith("\""))
            {
                data[0] = data[0].Substring(1, data[0].Length - 1);
            }

            return data;
        }

        /// <summary>Removes unwanted characters at the end of a dataset string</summary>
        /// <param name="str">The string containing the wrongly formatted dataset</param>
        /// <returns>New string with all dot-chars and comma-chars removed</returns>
        private static string RemoveDotsAndCommas(string str)
        {
            string result = str;

            if (str.EndsWith(","))
            {
                result = result.Replace(",", "");
            }

            return result;
        }

        #endregion
    }
}
