using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ExperimentsManager.Helpers
{
    /// <summary>Custom sorter for ListView controls</summary>
    public class ListViewItemSorter : IComparer
    {
        #region Private Variables
        
        private static ListViewItemSorter lvSorterSingleton;
        private SortOrder order = SortOrder.Descending;
        private int col = 0;
        private int result = 0;

        #endregion

        #region Public Properties

        public SortOrder Order
        {
            get { return order; }
            set { order = value; }
        }

        public int Column
        {
            get { return col; }
            set { col = value; }
        }

        public static ListViewItemSorter Instance
        {
            get
            {
                if (lvSorterSingleton == null) lvSorterSingleton = new ListViewItemSorter();
                return lvSorterSingleton;
            }
        }

        #endregion

        #region Contstructors
        /// <summary>Default constructor</summary>
        private ListViewItemSorter()
        {

        }
        #endregion

        #region Public Methods

        /// <summary>Compare method override to sort columns alphabetically</summary>
        /// <param name="x">First object used for the comparison</param>
        /// <param name="y">Second object used for the comparison</param>
        /// <returns>positive int for ascending sort, negative for descending, 0 otherwise</returns>
        public int Compare(object x, object y)
        {
            try
            {
                result = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                if (order == SortOrder.Ascending)
                {
                    return result;
                }
                else if (order == SortOrder.Descending)
                {
                    return (-result);
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}
