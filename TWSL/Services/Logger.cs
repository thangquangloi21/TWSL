using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSL
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public static class Logger
    {
        //private static string connectionString = "Server=10.239.1.54;Database=DB_SL;User Id=sa;Password=123456;";
        //private static string connectionString = "Server=pc-tql;Database=DB_SL;User Id=sa;Password=P@ssw0rd2025!;";

        //private static readonly string connectionString = "Data Source=SERVER_NAME;Initial Catalog=DB_NAME;Integrated Security=True";

        // Ghi log vào file theo ngày và thư mục riêng
        private static string GetLogFilePath()
        {
            string baseLogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            string dateFolder = DateTime.Now.ToString("yyyy-MM-dd");
            string dailyLogDirectory = Path.Combine(baseLogDirectory, dateFolder);

            if (!Directory.Exists(dailyLogDirectory))
            {
                Directory.CreateDirectory(dailyLogDirectory);
            }

            return Path.Combine(dailyLogDirectory, "log.txt");
        }

        private static void LogToFile(string level, string message, Exception ex = null)
        {
            try
            {
                string logMessage = $"{DateTime.Now:HH:mm:ss} [{level}] {message}";
                if (ex != null)
                {
                    logMessage += $" | Exception: {ex.Message}";
                }

                File.AppendAllText(GetLogFilePath(), logMessage + Environment.NewLine);
            }
            catch (Exception fileEx)
            {
                Console.WriteLine("Lỗi ghi log vào file: " + fileEx.Message);
            }
        }

        private static void LogToDatabase(string level, string message, Exception ex = null)
        {
            try
            {
                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                    string query = @"INSERT INTO LogSystem (LogDate, LogLevel, Message, Exception)
                                 VALUES (@LogDate, @LogLevel, @Message, @Exception)";
                    SqlParameter[] data = new SqlParameter[]
                    {
                            new SqlParameter("@LogDate", DateTime.Now),
                            new SqlParameter("@LogLevel", level),
                            new SqlParameter("@Message", message),
                            new SqlParameter("@Exception", ex?.ToString() ?? ""),
                    };
                    DatabaseHelper.ExecuteNonQuery(query, data);

                //    using (SqlCommand cmd = new SqlCommand(query, conn))
                //    {
                //        cmd.Parameters.AddWithValue("@LogDate", DateTime.Now);
                //        cmd.Parameters.AddWithValue("@LogLevel", level);
                //        cmd.Parameters.AddWithValue("@Message", message);
                //        cmd.Parameters.AddWithValue("@Exception", ex?.ToString() ?? "");

                //        conn.Open();
                //        cmd.ExecuteNonQuery();
                //    }
                //}

            }
            catch (Exception dbEx)
            {
                Console.WriteLine("Lỗi ghi log vào database: " + dbEx.Message);
            }
        }

        // Ghi log đồng thời vào file và database
        public static void Log(string level, string message, Exception ex = null)
        {
            LogToFile(level, message, ex);
            LogToDatabase(level, message, ex);
        }

        public static void LogInfo(string message) => Log("INFO", message);
        public static void LogWarning(string message) => Log("WARNING", message);
        public static void LogError(string message, Exception ex) => Log("ERROR", message, ex);
    }

}
