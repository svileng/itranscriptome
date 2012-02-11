using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using ExperimentsManager.Properties;
using System.Windows.Forms;

namespace ExperimentsManager
{
    /// <summary>Singleton which manages the connection to the database</summary>
    public class DatabaseManager
    {
        #region Variables
        private static DatabaseManager databaseManagerSingleton;
        #endregion

        #region Properties

        /// <summary>The actual connection to the database</summary>
        public SQLiteConnection Connection { get; private set; }
        
        /// <summary>DatabaseManager is a singleton, so always use this property to get an instance</summary>
        public static DatabaseManager Instance
        {
            get
            {
                if (databaseManagerSingleton == null) databaseManagerSingleton = new DatabaseManager();
                return databaseManagerSingleton;
            }
        }

        #endregion

        #region Constructors
        /// <summary>Creates a connection to the database</summary>
        /// <remarks>Path to database is stored in Properties/Settings.settings</remarks>
        private DatabaseManager()
        {
            string pathToDatabase = Settings.Default.PathToDatabase;
            if (File.Exists(pathToDatabase)) {
                string connectionString = "Data Source=" + pathToDatabase;
                try {
                    Connection = new SQLiteConnection(connectionString);
                } catch (Exception e) {
                    MessageBox.Show(e.Message);
                }
            } else {
                throw new FileNotFoundException();
            }
        }
        #endregion

    }
}
