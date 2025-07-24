using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Do_An1.Helpers
{
    public class Connect
    {
        private static string _connectionString = "Data Source=DESKTOP-39CDSH8;Initial Catalog=QLPhongKham;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] prms)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                foreach (SqlParameter p in prms)
                {
                    cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.SqlDbType)
                    {
                        Value = p.Value ?? DBNull.Value
                    });
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ExecuteQuery(string query, object[] objects, params SqlParameter[] parameters)
        {
            try
            {
                Console.WriteLine($"Executing ExecuteQuery with query: {query}, parameters count: {parameters?.Length ?? 0}");
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                if (param.Value == null)
                                    param.Value = DBNull.Value;
                            }
                            cmd.Parameters.AddRange(parameters);
                        }

                        Console.WriteLine($"Query: {query}");
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                Console.WriteLine($"Parameter {param.ParameterName}: {param.Value}");
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count == 0)
                                Console.WriteLine("Warning: No data returned from query.");
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}\nQuery: {query}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            return ExecuteQuery(query, null, parameters);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter prm)
        {
            return ExecuteQuery(query, null, prm);
        }

        public static DataTable ExecuteQuery(string query)
        {
            return ExecuteQuery(query, null, null);
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        if (param.Value == null)
                            param.Value = DBNull.Value;
                    }
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ExecuteNonQuery(string query, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(query, parameters, transaction);
        }

        // Thêm phương thức ExecuteScalar với SqlParameter[] và không có transaction
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                if (param.Value == null)
                                    param.Value = DBNull.Value;
                            }
                            cmd.Parameters.AddRange(parameters);
                        }
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}\nQuery: {query}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Overload với transaction
        public static object ExecuteScalar(string query, SqlParameter[] parameters, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(query, transaction.Connection, transaction))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        if (param.Value == null)
                            param.Value = DBNull.Value;
                    }
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }

        // Overload với 1 tham số
        public static object ExecuteScalar(string query, SqlParameter parameter, SqlTransaction transaction)
        {
            return ExecuteScalar(query, new[] { parameter }, transaction);
        }

        // Triển khai các phương thức internal bị lỗi
        internal static void ExecuteNonQuery(string query, SqlParameter sqlParameter)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (sqlParameter.Value == null)
                    sqlParameter.Value = DBNull.Value;
                cmd.Parameters.Add(sqlParameter);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal static object ExecuteScalar(string insertPhieu, SqlParameter sqlParameter1, SqlParameter sqlParameter2, SqlParameter sqlParameter3)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(insertPhieu, conn))
                    {
                        cmd.Parameters.Add(sqlParameter1);
                        cmd.Parameters.Add(sqlParameter2);
                        cmd.Parameters.Add(sqlParameter3);
                        if (sqlParameter1.Value == null) sqlParameter1.Value = DBNull.Value;
                        if (sqlParameter2.Value == null) sqlParameter2.Value = DBNull.Value;
                        if (sqlParameter3.Value == null) sqlParameter3.Value = DBNull.Value;
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}\nQuery: {insertPhieu}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        internal static object? ExecuteScalar(string queryInsertHoSo, SqlParameter paramInsert)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(queryInsertHoSo, conn))
                    {
                        if (paramInsert.Value == null)
                            paramInsert.Value = DBNull.Value;
                        cmd.Parameters.Add(paramInsert);
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}\nQuery: {queryInsertHoSo}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi SQL: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}