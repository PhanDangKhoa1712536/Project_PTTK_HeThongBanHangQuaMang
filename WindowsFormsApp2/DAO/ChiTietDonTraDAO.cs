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
    public class ChiTietDonTraDAO
    {
        private readonly DataProvider dp;

        public ChiTietDonTraDAO()
        {
            dp = new DataProvider();
        }

        public int MaChiTietDonTraHang_AutoGen()
        {
            string query = "SELECT COUNT(*) FROM CHITIETDONTRAHANG";
            dp.connection.Open();
            SqlCommand command = new SqlCommand(query, dp.connection);
            int value = Convert.ToInt32(command.ExecuteScalar());
            dp.connection.Close();
            return value;
        }
        public void Insert_ChiTietDonTra(int MaChiTietDon,int MaDonTra,int MaHangLoi,int SoLuong, string LyDo)
        {
            string query = "SET IDENTITY_INSERT CHITIETDONTRAHANG ON; INSERT" +
                " INTO CHITIETDONTRAHANG(MACHITIETDONTRA,MADONTRA,MAHANGLOI,SOLUONGTRA,LYDO)" +
                " VALUES(@MaCTDon,@MaDonTra,@MaHangLoi,@SoLuong,@LyDo);SET IDENTITY_INSERT CHITIETDONTRAHANG OFF;";
            List<SqlParameter> Inserted_values = new List<SqlParameter>
            {
                new SqlParameter("@MaCTDon",MaChiTietDon),
                new SqlParameter("@MaDonTra",MaDonTra),
                new SqlParameter("@MaHangLoi",MaHangLoi),
                new SqlParameter("@SoLuong",SoLuong),
                new SqlParameter("@LyDo",LyDo)
            };
            dp.ExecuteNonQuery(query, Inserted_values);
        }
    }
}
