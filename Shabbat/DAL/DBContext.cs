using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shabbat.DAL
{
    public class DBContext
    {
        private string _connectionString;
        public DBContext(string conn)
        {
            if (string.IsNullOrEmpty(conn))
                throw new ArgumentNullException(nameof(conn));
            _connectionString = conn;
        }
        public DataTable ExecuteQuery(string queryStr, SqlParameter[]? parameters = null)
        {
            DataTable output = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(output);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            return output;
        }
        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameters to the command.
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine($"SQL Error: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"General Error: {ex.Message}");
                    }

                    return null;
                }
            }
        }
        public int ExecuteNonQuery(string queryStr, SqlParameter[]? parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine("An error occurred: " + ex.Message);
                        return -1;
                    }
                }
            }
        }
    }   
}
