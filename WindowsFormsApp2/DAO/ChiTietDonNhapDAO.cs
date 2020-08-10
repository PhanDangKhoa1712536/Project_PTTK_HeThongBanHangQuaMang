using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ChiTietDonNhapDAO
    {
        private DataProvider dp;

        public ChiTietDonNhapDAO()
        {
            dp = new DataProvider();
        }

        public List<ChiTietDonNhapDTO> SelectByID(int MaDonNhap)
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

        public Boolean Insert(ChiTietDonNhapDTO chiTietDonNhap)
        {
            string query = "INSERT INTO CHITIETDONNHAP(MADONNHAP, MAHANG, SOLUONGNHAP) VALUES (@MADONNHAP, @MAHANG, @SOLUONGNHAP)";
            List<SqlParameter> inserted_values = new List<SqlParameter>();
            inserted_values.Add(new SqlParameter("@MADONNHAP", chiTietDonNhap.maDonNhap));
            inserted_values.Add(new SqlParameter("@MAHANG", chiTietDonNhap.maHang));
            inserted_values.Add(new SqlParameter("@SOLUONGNHAP", chiTietDonNhap.soLuongNhap));

            return dp.ExecuteNonQuery(query, inserted_values);
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
