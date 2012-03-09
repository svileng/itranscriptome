using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExperimentsManager.Controllers;
using System.IO;
using ExperimentsManager.Helpers;
using System.Threading;
using MathNet.Numerics.Statistics;
using ExperimentsManager.Models;

namespace ExperimentsManager.Views
{
    public partial class MainForm : Form
    {
        #region Public Instance Properties
        
        /// <summary>The controller responsible for this form</summary>
        public ExperimentsController Controller { get; private set; }
        /// <summary>Column index in listview showing name</summary>
        public static int COL_INDEX_NAME = 0;
        /// <summary>Column index in listview showing the institute</summary>
        public static int COL_INDEX_INSTITUTE = 1;
        /// <summary>Column index in listview showing the dataset number</summary>
        public static int COL_INDEX_DATASET = 2;
        /// <summary>Column index in listview showing tags</summary>
        public static int COL_INDEX_TAGS = 3;

        #endregion

        #region Private Instance Variables
        /// <summary>Current sorting order for the Experiments listview control</summary>
        private SortOrder lvExperimentsSortOrder = SortOrder.Ascending;
        /// <summary>Used to set progress bar visibility</summary>
        private enum ProgressBarStatus { Visible, Hidden };
        #endregion

        #region Constructors
        /// <summary>Default constructor</summary>
        /// <param name="controller">Form's controller</param>
        public MainForm(ExperimentsController controller)
        {
            if (controller == null) {
                throw new ArgumentNullException("Controller for form can't be null");
            }

            InitializeComponent();
            Controller = controller;
        }
        #endregion

        #region Form Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormHelper.UpdateExperimentsListView(lvExperiments, Controller.GetAllExperiments());
            if (lvExperiments.Items.Count > 0) lvExperiments.Items[0].Selected = true;
            cbFilterBy.SelectedItem = cbFilterBy.Items[0];
        }

        private void loadExperimentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.DefaultExt = "csv";
                dialog.Filter = "CSV (*.csv)|*.csv";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SetStatusBarInfo("Loading experiment...", ProgressBarStatus.Visible);
                    experimentLoader.RunWorkerAsync(dialog.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lvExperiments_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0) 
            {
                string dataset = lv.SelectedItems[0].SubItems[COL_INDEX_DATASET].Text;
                FormHelper.UpdateExperimentDetails(grpExperimentDetails, Controller.FindExperimentByDataset(dataset));
                btnSaveTags.Enabled = false;
            }
        }

        private void lvExperiments_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemSorter sorter = Helpers.ListViewItemSorter.Instance;
            lvExperiments.ListViewItemSorter = sorter;
            sorter.Column = e.Column;

            if (lvExperimentsSortOrder == SortOrder.Ascending)
            {
                sorter.Order = SortOrder.Descending;
                lvExperimentsSortOrder = SortOrder.Descending;
            }
            else
            {
                sorter.Order = SortOrder.Ascending;
                lvExperimentsSortOrder = SortOrder.Ascending;
            }

            lvExperiments.Sort();
        }

        private void txtKeywords_TextChanged(object sender, EventArgs e)
        {
            FormHelper.UpdateExperimentsListView(lvExperiments, Controller.GetAllExperiments());

            if (txtKeywords.Text != string.Empty)
            {
                FormHelper.FilterExperimentsListView(lvExperiments, txtKeywords.Text, cbFilterBy);
            }
        }

        private void btnSaveTags_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem lvi = lvExperiments.SelectedItems[0];
                
                Controller.UpdateExperimentTags(lvi.SubItems[COL_INDEX_DATASET].Text, txtTags.Text);
                FormHelper.UpdateExperimentsListView(lvExperiments, Controller.GetAllExperiments());

                btnSaveTags.Enabled = false;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("An experiment item must be selected first, before clicking 'Save'.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTags_Enter(object sender, EventArgs e)
        {
            btnSaveTags.Enabled = true;
        }

        private void experimentLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string fileName = (string)e.Argument;
                if (string.IsNullOrEmpty(fileName)) {
                    throw new ArgumentException("Error: Invalid experiment file name");
                }
                Controller.LoadExperimentFromCsvFile(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
        }

        private void experimentLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw new Exception("Error: Problem while loading experiment data");
            }
            else if (e.Cancelled)
            {
                SetStatusBarInfo("Error while loading the experiment", ProgressBarStatus.Hidden);
            }
            else
            {
                SetStatusBarInfo("Experiment loaded successfully!", ProgressBarStatus.Hidden);
                FormHelper.UpdateExperimentsListView(lvExperiments, Controller.GetAllExperiments());
            }
        }

        private void btnRunSelectionAlgorithm_Click(object sender, EventArgs e)
        {
            if (lvExperiments.SelectedItems.Count <= 1) {
                MessageBox.Show("You must select at least 2 experiments.");
            } else {
                
                int seeds = Convert.ToInt32(nudSeeds.Value);
                double significance = Convert.ToDouble(nudSignificance.Value);
                string[] identifiers = txtIdentifiers.Text.Split(',');
                
                List<Experiment> experiments = new List<Experiment>();
                foreach (ListViewItem lvi in lvExperiments.SelectedItems) {
                    Experiment exp = Controller.FindExperimentByDataset(lvi.SubItems[COL_INDEX_DATASET].Text);
                    experiments.Add(exp);
                }

                ExperimentSelectionController esc = new ExperimentSelectionController(seeds, significance, identifiers, experiments.ToArray());
                SetStatusBarInfo("Running the experiment selection algorithm...", ProgressBarStatus.Visible);
                expSelectionRunner.RunWorkerAsync(esc);
            }
        }

        private void expSelectionRunner_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ExperimentSelectionController esc = (ExperimentSelectionController)e.Argument;
                if (esc == null) {
                    throw new ArgumentNullException("Error: Missing argument for experiment selection algorithm");
                }
                esc.RunAlgorithm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
        }

        private void expSelectionRunner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw new Exception("Error: Problem while running experiment selection algorithm");
            }
            else if (e.Cancelled)
            {
                SetStatusBarInfo("Error: Problem while running experiment selection algorithm", ProgressBarStatus.Hidden);
            }
            else
            {
                SetStatusBarInfo("Experiment selection completed successfully!", ProgressBarStatus.Hidden);
            }
        }

        private void cmsExperiment_Opening(object sender, CancelEventArgs e)
        {
            if (lvExperiments.SelectedItems.Count == 0)
            {
                tsmiDeleteExperiment.Enabled = false;
                tsmiViewExperiment.Enabled = false;
            }
            else
            {
                tsmiDeleteExperiment.Enabled = true;
                tsmiViewExperiment.Enabled = true;
            }
        }

        private void tsmiDeleteExperiment_Click(object sender, EventArgs e)
        {
            if (lvExperiments.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select an experiment first");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected experiment from the database? All data will be lost.\nChoose Yes to delete the experiment and No to cancel.", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    ListViewItem lvi = lvExperiments.SelectedItems[0];
                    Controller.DeleteExperiment(lvi.SubItems[COL_INDEX_DATASET].Text);
                    FormHelper.UpdateExperimentsListView(lvExperiments, Controller.GetAllExperiments());
                    SetStatusBarInfo("Experiment deleted successfully!", ProgressBarStatus.Hidden);
                }
            }
        }

        private void tsmiViewExperiment_Click(object sender, EventArgs e)
        {
            if (lvExperiments.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select an experiment first");
            }
            else
            {
                ListViewItem lvi = lvExperiments.SelectedItems[0];
                Controller.ShowDetailsForExperiment(lvi.SubItems[COL_INDEX_DATASET].Text);
            }
        }


        #endregion

        #region Form Specific Helper Methods
        /// <summary>Updates the status bar of the main form</summary>
        /// <param name="text">Text to display on the status bar</param>
        /// <param name="progressBarStatus">Set progress bar to either visible or hidden</param>
        private void SetStatusBarInfo(string text, ProgressBarStatus progressBarStatus)
        {
            statusStripLabel.Text = string.Format("[{0}] {1}", DateTime.Now.ToShortTimeString(), text);
            statusStripProgressBar.Visible = progressBarStatus == ProgressBarStatus.Visible ? true : false;
        }
        #endregion

    }
}
