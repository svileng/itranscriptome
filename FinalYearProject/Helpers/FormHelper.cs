using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExperimentsManager.Models;
using ExperimentsManager.Views;

namespace ExperimentsManager.Helpers
{
    /// <summary>Helper methods used for forms/ui controls</summary>
    public static class FormHelper
    {
        /// <summary>Clears and populates a listview control with given data</summary>
        /// <param name="lv">Listview control to be updated</param>
        /// <param name="data">The data to be added to the listview</param>
        public static void UpdateExperimentsListView(ListView lv, Experiment[] data)
        {
            lv.Items.Clear();
            lv.BeginUpdate(); // avoid control flicker if large amount of data is going to be added

            foreach (Experiment e in data)
            {
                ListViewItem lvi = new ListViewItem(e.DatabaseName);
                lvi.SubItems.Add(e.DatabaseInstitute);
                lvi.SubItems.Add(e.Dataset);
                lvi.SubItems.Add(e.Tags);
                lv.Items.Add(lvi);
            }

            lv.EndUpdate();
        }

        public static void UpdateExperimentDetails(GroupBox details, Experiment experiment)
        {
            foreach (Control control in details.Controls)
            {
                switch (control.AccessibleName) 
                {
                    case "txtExperimentNameOutput":
                        control.Text = experiment.DatabaseName;
                        break;
                    case "txtExperimentDescriptionOutput":
                        control.Text = experiment.DatasetDescription;
                        break;
                }
            }
        }

        /// <summary>Filters an Experiments listview control, using filter text and type</summary>
        /// <param name="lv">Experiments ListView to filter</param>
        /// <param name="text">Text to look for</param>
        /// <param name="type">The filter type (i.e. column to filter)</param>
        public static void FilterExperimentsListView(ListView lv, string text, ComboBox type)
        {
            int column = MainForm.COL_INDEX_NAME;
            string filterType = type.SelectedItem == null ? "Name" : type.SelectedItem.ToString();

            switch (filterType)
            {
                case "Name":
                    // set by default
                    break;
                case "Institute":
                    column = MainForm.COL_INDEX_INSTITUTE;
                    break;
                case "Dataset":
                    column = MainForm.COL_INDEX_DATASET;
                    break;
                case "Tags":
                    column = MainForm.COL_INDEX_TAGS;
                    break;
            }

            lv.BeginUpdate();

            for (int i = lv.Items.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = lv.Items[i];
                ListViewItem.ListViewSubItem lvsi = lvi.SubItems[column];
                if (!lvsi.Text.Contains(text))
                {
                    lv.Items.Remove(lvi);
                }
            }

            lv.EndUpdate();
        }
    }
}
