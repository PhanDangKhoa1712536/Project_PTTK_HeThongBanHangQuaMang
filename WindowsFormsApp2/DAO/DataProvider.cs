using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


//KHÔNG ĐỤNG VÀO ĐÂY
namespace DAO
{
    public class DataProvider
    {
        public SqlConnection connection { get; set; }
        public DataProvider()
        {
            String connString = System.IO.File.ReadAllText("DBconfig.txt");
            this.connection = new SqlConnection(connString);
        }

        // Command: SELECT
        public DataTable ExecuteQuery(String query, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection)
                {
                    CommandType = CommandType.Text
                };
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error execute query: " + ex.Message);
            }
            finally
            {
                this.connection.Close();
            }

            return dt;
        }

        // Command: INSERT/DELETE/UPDATE
        public bool ExecuteNonQuery(String query, List<SqlParameter> parameters = null)
        {
            bool flag = true;
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection)
                {
                    CommandType = CommandType.Text
                };
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                flag = false;
                throw new Exception("Error execute non query: " + ex.Message);
            }
            finally
            {
                this.connection.Close();
            }

            return flag;
        }

        public int ExecuteScalar(String query, List<SqlParameter> parameters = null)
        {
            try
            {
                this.connection.Open();
                SqlCommand cmd = new SqlCommand(query, this.connection)
                {
                    CommandType = CommandType.Text
                };
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error execute scalar: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
