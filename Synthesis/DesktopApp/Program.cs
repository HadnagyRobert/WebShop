using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace DesktopApp
{
    internal static class Program
    {
        public static readonly string Connection = "Server=studmysql01.fhict.local;Uid=dbi497144;Database=dbi497144;Pwd=1207;";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (CheckConnection())
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());
            }
    }

        public static bool CheckConnection()
        { 
            using (MySqlConnection connection = new MySqlConnection(Connection))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Error: Check your connection");
                    Environment.Exit(1);
                    return false;
                }
            }
        }
    }
}