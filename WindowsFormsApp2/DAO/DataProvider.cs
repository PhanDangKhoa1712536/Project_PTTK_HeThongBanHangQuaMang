using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


//KHÔNG ĐỤNG VÀO ĐÂY
namespace DAO
{
    class DataProvider
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
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.CommandType = CommandType.Text;
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
                SqlCommand cmd = new SqlCommand(query, this.connection);
                cmd.CommandType = CommandType.Text;
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
    }
}
