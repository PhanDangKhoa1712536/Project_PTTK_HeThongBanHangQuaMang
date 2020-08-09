using DTO;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        private DataProvider db;
        
        public ChiTietHoaDonDAO()
        {
            db = new DataProvider();
        }

        public List<ChiTietHoaDonDTO> DocChiTietHoaDon(int MaHD)
        {
            string query = "SELECT CT.MACHITIETHOADON, CT.MAHANG, TENHANG, CT.SOLUONG, (HG.DONGIA * CT.SOLUONG) AS DONGIA FROM CHITIETHOADON CT INNER JOIN HANG HG ON CT.MAHOADON = @MaHD AND CT.MAHANG = HG.MAHANG";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            DataTable dt = db.ExecuteQuery(query, Find_values);
            List<ChiTietHoaDonDTO> ret = new List<ChiTietHoaDonDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietHoaDonDTO temp = new ChiTietHoaDonDTO((int)dr["MACHITIETHOADON"], (int)dr["MAHANG"], dr["TENHANG"].ToString(), MaHD, (int)dr["SOLUONG"], Convert.ToSingle(dr["DONGIA"]));
                ret.Add(temp);
            }
            return ret;
        }

        public void ThemChiTietHoaDon(ChiTietHoaDonDTO CT)
        {
            string query = "INSERT INTO CHITIETHOADON(MAHOADON, MAHANG, SOLUONG) VALUES (@MaHD, @MaHang, @SoLuong)";
            List<SqlParameter> inserted_values = new List<SqlParameter>();
            inserted_values.Add(new SqlParameter("@MaHD", CT.maHoaDon));
            inserted_values.Add(new SqlParameter("@MaHang", CT.maHang));
            inserted_values.Add(new SqlParameter("@SoLuong", CT.soLuong));

            db.ExecuteNonQuery(query, inserted_values);
        }

        public void XoaChiTietHD(int MaHD)
        {
            string query = "DELETE FROM CHITIETHOADON WHERE MAHOADON = @MaHD";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            db.ExecuteNonQuery(query, Find_values);
        }


    }
}
