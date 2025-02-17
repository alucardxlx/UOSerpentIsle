using System;
using System.Text;
using System.Threading;

namespace Server.Engines.MyRunUO
{
    public class Config
    {
        // Is MyRunUO enabled?
        public static bool Enabled = false;
        // Details required for database connection string
        public const string DatabaseDriver = "{MySQL ODBC 5.3 Unicode Driver}"; // MySQL ODBC 5.3 Unicode Driver
        public const string DatabaseServer = "192.254.237.103";
        public const string DatabaseName = "patrickg_myrunuo";
        public const string DatabaseUserID = "patrickg_myrunuo";
        public const string DatabasePassword = "3^D7q2BkXvRA";
        // Should the database use transactions? This is recommended
        public static bool UseTransactions = true;
        // Use optimized table loading techniques? (LOAD DATA INFILE)
        public static bool LoadDataInFile = true;
        // This must be enabled if the database server is on a remote machine.
        public static bool DatabaseNonLocal = (DatabaseServer != "localhost");
        // Text encoding used
        public static Encoding EncodingIO = Encoding.ASCII;
        // Database communication is done in a separate thread. This value is the 'priority' of that thread, or, how much CPU it will try to use
        public static ThreadPriority DatabaseThreadPriority = ThreadPriority.BelowNormal;
        // Any character with an AccessLevel equal to or higher than this will not be displayed
        public static AccessLevel HiddenAccessLevel = AccessLevel.Counselor;
        // Export character database every 30 minutes
        public static TimeSpan CharacterUpdateInterval = TimeSpan.FromMinutes(30.0);
        // Export online list database every 5 minutes
        public static TimeSpan StatusUpdateInterval = TimeSpan.FromMinutes(5.0);
        public static string CompileConnectionString()
        {
            string connectionString = String.Format("DRIVER={0};SERVER={1};DATABASE={2};UID={3};PASSWORD={4};",
                DatabaseDriver, DatabaseServer, DatabaseName, DatabaseUserID, DatabasePassword);

            return connectionString;
        }
    }
}
