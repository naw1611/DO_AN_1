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
                        Value = p.Value
                    }); // Tạo parameter mới chứ không dùng lại object cũ
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
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}\nQuery: {query}\nStackTrace: {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            return ExecuteQuery(query, null, parameters);
        }
        public static DataTable ExecuteQuery(string query, SqlParameter prm)
        {
            return ExecuteQuery(query, null, prm); // Chuyển hướng
        }

        public static DataTable ExecuteQuery(string query)
        {
            return ExecuteQuery(query, null, null); // Chuyển hướng
        }

        public static int ExecuteNonQuery(string query, object[] objects, params SqlParameter[] parameters)
        {
            try
            {
                Console.WriteLine($"Executing ExecuteNonQuery with query: {query}, parameters count: {parameters?.Length ?? 0}");
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
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
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}\nQuery: {query}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                Console.WriteLine($"Executing ExecuteScalar with query: {query}, parameters count: {parameters?.Length ?? 0}");
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
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
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}\nQuery: {query}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        internal static void ExecuteNonQuery(string insertDonThuoc, SqlParameter sqlParameter)
        {
            throw new NotImplementedException();
        }

        internal static void ExecuteNonQuery(string insertChiTiet, SqlParameter sqlParameter1, SqlParameter sqlParameter2, SqlParameter sqlParameter3, SqlParameter sqlParameter4, SqlParameter sqlParameter5)
        {
            throw new NotImplementedException();
        }

        internal static void ExecuteNonQuery(string insertLS, SqlParameter sqlParameter1, SqlParameter sqlParameter2, SqlParameter sqlParameter3, SqlParameter sqlParameter4)
        {
            throw new NotImplementedException();
        }

        internal static void ExecuteNonQuery(string capNhatThuoc, SqlParameter sqlParameter1, SqlParameter sqlParameter2)
        {
            throw new NotImplementedException();
        }

    }
}