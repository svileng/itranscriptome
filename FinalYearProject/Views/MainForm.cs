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
        #endregion

        #region Constructors
        /// <summary>Default constructor</summary>
        /// <param name="controller">Form's controller</param>
        public MainForm(ExperimentsController controller)
        {
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
                    Controller.LoadExperimentFromCsvFile(dialog.FileName);
                    statusStripLabel.Text = "Experiment loaded successfully!";
                    FormHelper.UpdateExperimentsListView(lvExperiments, Controller.GetAllExperiments());
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
                FormHelper.UpdateExperimentDetails(grpExperimentDetails, Controller.FindByDataset(dataset));
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
                lvi.SubItems[COL_INDEX_TAGS].Text = txtTags.Text;
                Controller.UpdateExperimentTags(lvi.SubItems[COL_INDEX_DATASET].Text, txtTags.Text);
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

        #endregion

    }
}
