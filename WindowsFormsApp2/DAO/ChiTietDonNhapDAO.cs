using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietDonNhapDAO
    {
        private DataProvider dp;

        public ChiTietDonNhapDAO()
        {
            dp = new DataProvider();
        }

        public List<ChiTietDonNhapDTO> DocChiTietHoaDon(int MaDonNhap)
        {
            string query = "SELECT * FROM CHITIETDONNHAP WHERE MADONNHAP = @MADONNHAP";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MADONNHAP", MaDonNhap));

            DataTable dt = dp.ExecuteQuery(query, Find_values);
            List<ChiTietDonNhapDTO> ret = new List<ChiTietDonNhapDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietDonNhapDTO temp = new ChiTietDonNhapDTO((int)dr["MACHITIETDONNHAP"], (int)dr["MADONNHAP"], (int)dr["MAHANG"], (int)dr["SOLUONG"]);
                ret.Add(temp);
            }
            return ret;
        }

        public void ThemChiTietHoaDon(ChiTietDonNhapDAO CT)
        {
            //string query = "INSERT INTO CHITIETHOADON(MAHOADON, MAHANG, SOLUONG) VALUES (@MaHD, @MaHang, @SoLuong)";
            //List<SqlParameter> inserted_values = new List<SqlParameter>();
            //inserted_values.Add(new SqlParameter("@MaHD", CT.maHoaDon));
            //inserted_values.Add(new SqlParameter("@MaHang", CT.maHang));
            //inserted_values.Add(new SqlParameter("@SoLuong", CT.soLuong));

            //dp.ExecuteNonQuery(query, inserted_values);
        }

        public void XoaChiTietHD(int MaHD)
        {
            string query = "DELETE FROM CHITIETHOADON WHERE MAHOADON = @MaHD";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            dp.ExecuteNonQuery(query, Find_values);
        }
    }
}
