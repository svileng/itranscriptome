using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExperimentsManager.Models;

namespace ExperimentsManager.Helpers
{
    /// <summary>Factory for SQL queries, mainly used by models</summary>
    public static class SqlFactory
    {
        public static string CreateInsertExperimentQueryFromObject(Experiment e)
        {
            if (e == null) {
                throw new ArgumentNullException("Invalid query argument");
            }

            if (string.IsNullOrEmpty(e.Dataset)) {
                throw new ArgumentException("Experiment dataset is null or empty");
            }

            StringBuilder result = new StringBuilder();

            result.Append("INSERT INTO experiments (database_used, database_name, database_web_link, ");
            result.Append("database_institute, database_email, database_ref, dataset, dataset_title, ");
            result.Append("dataset_description, dataset_type, dataset_pubmed_id, dataset_platform, ");
            result.Append("dataset_platform_organism, dataset_platform_technology_type, ");
            result.Append("dataset_feature_count, dataset_sample_organism, dataset_sample_type, ");
            result.Append("dataset_reference_series, dataset_update_date) VALUES (");
            result.Append("'"); result.Append(e.Database); result.Append("', ");
            result.Append("'"); result.Append(e.DatabaseName); result.Append("', ");
            result.Append("'"); result.Append(e.DatabaseWebLink); result.Append("', ");
            result.Append("'"); result.Append(e.DatabaseInstitute); result.Append("', ");
            result.Append("'"); result.Append(e.DatabaseEmail); result.Append("', ");
            result.Append("'"); result.Append(e.DatabaseRef); result.Append("', ");
            result.Append("'"); result.Append(e.Dataset); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetTitle); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetDescription); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetType); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetPubmedId); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetPlatform); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetPlatformOrganism); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetPlatformTechnologyType); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetFeatureCount); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetSampleOrganism); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetSampleType); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetReferenceSeries); result.Append("', ");
            result.Append("'"); result.Append(e.DatasetUpdateDate); result.Append("'); ");

            return result.ToString();
        }

        public static string CreateInsertDatasetTableRowsQueryFromObject(Experiment e)
        {
            if (e == null) {
                throw new ArgumentNullException("Invalid query argument");
            }

            StringBuilder result = new StringBuilder();

            // optimisation: group all INSERTs into a single transaction
            result.Append("BEGIN TRANSACTION; ");

            foreach (DatasetTableRow dtr in e.DatasetTable)
            {
                result.Append("INSERT INTO datasets (experiment_id, id_ref, identifier, value) VALUES (");
                result.Append("'"); result.Append(e.Dataset); result.Append("', ");
                result.Append("'"); result.Append(dtr.IdRef); result.Append("', ");
                result.Append("'"); result.Append(dtr.Identifier); result.Append("', ");
                result.Append("'"); result.Append(dtr.Value); result.Append("'); ");
            }

            result.Append("COMMIT; ");

            return result.ToString();
        }

        public static string CreateInsertGSMQueryFromObject(Experiment e)
        {
            if (e == null) {
                throw new ArgumentNullException("Invalid query argument");
            }

            StringBuilder result = new StringBuilder();

            foreach (ExperimentGSM gsm in e.GSMs) 
            {
                result.Append("INSERT INTO gsms_data (experiment_id, gsm_id, gsm_value) VALUES (");
                result.Append("'"); result.Append(e.Dataset); result.Append("', ");
                result.Append("'"); result.Append(gsm.GSMId); result.Append("', ");
                result.Append("'"); result.Append(gsm.Value); result.Append("'); ");
            }

            return result.ToString();
        }

        public static string CreateSelectExperimentQuery(string condition)
        {
            if (string.IsNullOrEmpty(condition)) {
                throw new ArgumentNullException("Invalid query argument");
            }

            StringBuilder result = new StringBuilder();

            result.Append("SELECT * FROM experiments WHERE ");
            result.Append("dataset = '"); result.Append(condition); result.Append("' OR ");
            result.Append("database_name = '"); result.Append(condition); result.Append("' OR ");
            result.Append("database_used = '"); result.Append(condition); result.Append("' LIMIT 1");

            return result.ToString();
        }

        public static string CreateSelectAllExperimentsQuery()
        {
            string result = "SELECT * FROM experiments";
            return result;
        }

        internal static string CreateUpdateExperimentQueryFromObject(Experiment e)
        {
            if (e == null) {
                throw new ArgumentNullException("Invalid query argument");
            }

            StringBuilder result = new StringBuilder();

            result.Append("UPDATE experiments SET ");
            result.Append("database_used = "); result.Append("'"); result.Append(e.Database); result.Append("', ");
            result.Append("database_name = "); result.Append("'"); result.Append(e.DatabaseName); result.Append("', ");
            result.Append("database_web_link = "); result.Append("'"); result.Append(e.DatabaseWebLink); result.Append("', ");
            result.Append("database_institute = "); result.Append("'"); result.Append(e.DatabaseInstitute); result.Append("', ");
            result.Append("database_email = "); result.Append("'"); result.Append(e.DatabaseEmail); result.Append("', ");
            result.Append("database_ref = "); result.Append("'"); result.Append(e.DatabaseRef); result.Append("', ");
            result.Append("dataset = "); result.Append("'"); result.Append(e.Dataset); result.Append("', ");
            result.Append("dataset_title = "); result.Append("'"); result.Append(e.DatasetTitle); result.Append("', ");
            result.Append("dataset_description = "); result.Append("'"); result.Append(e.DatasetDescription); result.Append("', ");
            result.Append("dataset_type = "); result.Append("'"); result.Append(e.DatasetType); result.Append("', ");
            result.Append("dataset_pubmed_id = "); result.Append("'"); result.Append(e.DatasetPubmedId); result.Append("', ");
            result.Append("dataset_platform = "); result.Append("'"); result.Append(e.DatasetPlatform); result.Append("', ");
            result.Append("dataset_platform_organism = "); result.Append("'"); result.Append(e.DatasetPlatformOrganism); result.Append("', ");
            result.Append("dataset_platform_technology_type = "); result.Append("'"); result.Append(e.DatasetPlatformTechnologyType); result.Append("', ");
            result.Append("dataset_feature_count = "); result.Append("'"); result.Append(e.DatasetFeatureCount); result.Append("', ");
            result.Append("dataset_sample_organism = "); result.Append("'"); result.Append(e.DatasetSampleOrganism); result.Append("', ");
            result.Append("dataset_sample_type = "); result.Append("'"); result.Append(e.DatasetSampleType); result.Append("', ");
            result.Append("dataset_reference_series = "); result.Append("'"); result.Append(e.DatasetReferenceSeries); result.Append("', ");
            result.Append("dataset_update_date = "); result.Append("'"); result.Append(e.DatasetUpdateDate); result.Append("', ");
            result.Append("tags = "); result.Append("'"); result.Append(e.Tags); result.Append("' ");
            result.Append("WHERE id = "); result.Append(e.Id);

            return result.ToString();
        }

        public static string CreateSelectGSMsForExperimentQuery(string experiment_id)
        {
            if (string.IsNullOrEmpty(experiment_id)) {
                throw new ArgumentNullException("Invalid query argument");
            }

            StringBuilder result = new StringBuilder();

            result.Append("SELECT * FROM gsms_data WHERE experiment_id = '");
            result.Append(experiment_id);
            result.Append("'");

            return result.ToString();
        }

        public static string CreateSelectDatasetTableRowsForExperimentQuery(string experiment_id)
        {
            if (string.IsNullOrEmpty(experiment_id)) {
                throw new ArgumentNullException("Invalid query argument");
            }

            StringBuilder result = new StringBuilder();

            result.Append("SELECT * FROM datasets WHERE experiment_id = '");
            result.Append(experiment_id);
            result.Append("'");

            return result.ToString();
        }

        public static string CreateDeleteExperimentQueryFromObject(Experiment experiment)
        {
            if (experiment == null) {
                throw new ArgumentNullException();
            }

            StringBuilder result = new StringBuilder();

            result.Append("DELETE FROM experiments WHERE dataset = '");
            result.Append(experiment.Dataset);
            result.Append("';");

            result.Append("DELETE FROM gsms_data WHERE experiment_id = '");
            result.Append(experiment.Dataset);
            result.Append("';");

            result.Append("DELETE FROM datasets WHERE experiment_id = '");
            result.Append(experiment.Dataset);
            result.Append("';");

            return result.ToString();
        }
    }
}
