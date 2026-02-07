using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuizExamSystem.Utils
{
    public static class DbHelper
    {
        // Lấy connection string từ App.config
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["QuizExamDB"].ConnectionString;

        /// <summary>
        /// Tạo và trả về SqlConnection
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Thực thi INSERT, UPDATE, DELETE
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Thực thi câu lệnh trả về 1 giá trị (COUNT, MAX, SUM…)
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
