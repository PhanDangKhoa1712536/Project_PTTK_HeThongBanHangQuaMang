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
    public class ChiTietHangLoiDAO
    {
        readonly DataProvider dp;

        public ChiTietHangLoiDAO()
        {
            this.dp = new DataProvider();
        }

        public int MaChiTietHangLoi_AutoGen()
        {
            string query = "SELECT COUNT(*) FROM CHITIETHANGLOI";
            dp.connection.Open();
            SqlCommand command = new SqlCommand(query, dp.connection);
            int value = Convert.ToInt32(command.ExecuteScalar());
            dp.connection.Close();
            return value;
        }
        public void Insert_ChiTietHangLoi(int MaCTHangLoi,int MaHoaDon, int MaHangLoi)
        {
            string query = "SET IDENTITY_INSERT CHITIETHANGLOI ON; INSERT" +
                " INTO CHITIETHANGLOI(MACHITIETHANGLOI,MAHOADON,MAHANGLOI)" +
                " VALUES(@MaCTHangLoi, @MaHoaDon,@MaHangLoi);SET IDENTITY_INSERT CHITIETHANGLOI OFF;";
            List<SqlParameter> Inserted_values = new List<SqlParameter>
            {

                new SqlParameter("@MaCTHangLoi",MaCTHangLoi),
                new SqlParameter("@MaHoaDon",MaHoaDon),
                new SqlParameter("@MaHangLoi",MaHangLoi)
               

            };
            dp.ExecuteNonQuery(query, Inserted_values);

        }

    }


}
