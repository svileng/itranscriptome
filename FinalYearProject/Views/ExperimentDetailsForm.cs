using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExperimentsManager.Models;

namespace ExperimentsManager.Views
{
    public partial class ExperimentDetailsForm : Form
    {
        private Experiment Experiment { get; set; }

        public ExperimentDetailsForm(Experiment experiment)
        {
            if (experiment == null) {
                throw new ArgumentNullException();
            }

            InitializeComponent();
            Experiment = experiment;
        }

        private void ExperimentDetailsForm_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Database used: ");
            sb.Append(Experiment.Database);

            sb.Append("\r\n");

            sb.Append("Database name: ");
            sb.Append(Experiment.DatabaseName);

            sb.Append("\r\n");

            sb.Append("Database institute: ");
            sb.Append(Experiment.DatabaseInstitute);

            sb.Append("\r\n");

            sb.Append("Dataabse web link: ");
            sb.Append(Experiment.DatabaseWebLink);

            sb.Append("\r\n");

            sb.Append("Database email: ");
            sb.Append(Experiment.DatabaseEmail);

            sb.Append("\r\n");

            sb.Append("Database ref: ");
            sb.Append(Experiment.DatabaseRef);

            sb.Append("\r\n");
            sb.Append("\r\n");

            sb.Append("Dataset: ");
            sb.Append(Experiment.Dataset);

            sb.Append("\r\n");
            
            sb.Append("Dataset title: ");
            sb.Append(Experiment.DatasetTitle);

            sb.Append("\r\n");

            sb.Append("Dataset type: ");
            sb.Append(Experiment.DatasetType);

            sb.Append("\r\n");

            sb.Append("Dataset pubmed id: ");
            sb.Append(Experiment.DatasetPubmedId);

            sb.Append("\r\n");

            sb.Append("Dataset description: ");
            sb.Append(Experiment.DatasetDescription);

            txtExperimentDetails.Text = sb.ToString();
            
        }
    }
}
