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
        #endregion

        #region Public Properties

        public SortOrder Order { get; set; }

        public int Column { get; set; }

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
        /// <param name="a">First object used for the comparison</param>
        /// <param name="b">Second object used for the comparison</param>
        /// <returns>positive int for ascending sort, negative for descending, 0 otherwise</returns>
        public int Compare(object a, object b)
        {
            int result = 0;

            try
            {
                string aText = ((ListViewItem)a).SubItems[Column].Text;
                string bText = ((ListViewItem)b).SubItems[Column].Text;
                result = String.Compare(aText, bText);

                switch (Order)
                {
                    case SortOrder.Ascending:
                        return result;
                    case SortOrder.Descending:
                        return -result;
                    default:
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
