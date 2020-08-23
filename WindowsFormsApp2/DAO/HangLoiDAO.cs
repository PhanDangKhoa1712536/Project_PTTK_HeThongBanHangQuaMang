using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;


namespace DAO
{
    public class HangLoiDAO
    {
        readonly DataProvider dp;

        public HangLoiDAO()
        {
            this.dp = new DataProvider();
        }

        public bool CheckExist_HangLoi(int MaHangLoi)
        {

            string query = "SELECT COUNT(MAHANGLOI) FROM HANGLOI WHERE MAHANGLOI ="+MaHangLoi+";";
            dp.connection.Open();
            SqlCommand command = new SqlCommand(query, dp.connection);
            Int32 count = Convert.ToInt32(command.ExecuteScalar());
            dp.connection.Close();
            if(count>0)
            {
                return true;
            }
            else
                {
                return false;
            }



         
        }
        public void Insert_HangLoi(int MaHangLoi, int SoLuong)
        {
            string query = "SET IDENTITY_INSERT HANGLOI ON;" +
                " INSERT INTO  HANGLOI(MAHANGLOI,SOLUONG) VALUES (@MaHangLoi, @SoLuong)   " +
                 "SET IDENTITY_INSERT HANGLOI OFF;";
            List<SqlParameter> Inserted_values = new List<SqlParameter>
            {
                new SqlParameter("@MaHangLoi",MaHangLoi),
                new SqlParameter("@SoLuong",SoLuong)
            };
            dp.ExecuteNonQuery(query, Inserted_values);   
        
        }

        public void Insert_HangLoi_Existed(int MaHang,int SoLuong)
        {
            string query = "UPDATE HANGLOI SET SOLUONG = SOLUONG + @SoLuong WHERE MAHANGLOI = @MaHangLoi";
            List<SqlParameter> Inserted_values = new List<SqlParameter>
            {
                new SqlParameter("@MaHangLoi",MaHang),
                new SqlParameter("@SoLuong",SoLuong)
            };
            dp.ExecuteNonQuery(query, Inserted_values);
        }
    }
}
