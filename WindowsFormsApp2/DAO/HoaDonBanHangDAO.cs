using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class HoaDonBanHangDAO
    {
        private DataProvider db;

        public HoaDonBanHangDAO()
        {
            db = new DataProvider();
        }
        //public int docmahdmoinhat()
        //{
        //    string query = "select mahd from hoadonbanhang where "
        //}
        public void ThemHoaDonBanHang(HoaDonBanHangDTO HD)
        {
            string query = "INSERT INTO HOADONBANHANG VALUES (@MaHD, @MaKH, @MaNVLap, @MaNVGiao, @MaNVXacThuc, @TongTien, @HinhThucThanhToan, @XacNhanDaThanhToan,@NgayGiaoHang, @SoTienThanhToan)";
            List<SqlParameter> Inserted_values = new List<SqlParameter>();
            Inserted_values.Add(new SqlParameter("@MaHD", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@MaKH", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@MaNVLap", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@MaNVGiao", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@MaNVXacThuc", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@TongTien", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@HinhThucThanhToan", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@XacNhanDaThanhToan", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@NgayGiaoHang", HD.maHoaDon));
            Inserted_values.Add(new SqlParameter("@SoTienThanhToan", HD.maHoaDon));

            db.ExecuteNonQuery(query, Inserted_values);
        }
        public int DocMaHDMoiNhat()
        {
            string query = "SELECT MAX(MAHOADON) FROM HOADONBANHANG";
            DataTable dt = db.ExecuteQuery(query);
            return (int)dt.Rows[0]["MAHOADON"];
        }

        public List<int> DocTatCaMaHD()
        {
            string query = "SELECT MAHOADON FROM HOADONBANHANG";
            DataTable dt = db.ExecuteQuery(query);
            List<int> ret = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                int temp = (int)dr["MAHOADON"];
                ret.Add(temp);
            }
            return ret;
        }
        public HoaDonBanHangDTO DocThongTinHD(int MaHD)
        {
            string query = "SELECT * FROM HOADONBANHANG WHERE MAHOADON = @MaHD";
            List<SqlParameter> find_values = new List<SqlParameter>();
            find_values.Add(new SqlParameter("@MaHD", MaHD));
            DataTable dt = db.ExecuteQuery(query, find_values);

            DataRow temp = dt.Rows[0];
            HoaDonBanHangDTO ret = new HoaDonBanHangDTO(MaHD, (int)temp["MAKH"], (int)temp["MANVLAP"], (int)temp["MANVGIAO"], (int)temp["MANVXACTHUC"], (float)temp["TONGTIEN"], (bool)temp["HINHTHUCTHANHTOAN"], (bool)temp["XACNHANDATHANHTOAN"], (DateTime)temp["NGAYGIAO"], (float)temp["SOTIENTHANHTOAN"]);
            return ret;
        }
        public void XoaHDBanHang(int MaHD)
        {
            string query = "DELETE FROM HOADONBANHANG WHERE MAHOADON = @MaHD";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            db.ExecuteNonQuery(query, Find_values);
        }

        public HoaDonBanHangDTO TimHoaDon_TraHang(int MaHD)
        {
            string query = "SELECT * FROM HOADONBANHANG WHERE MAHOADON = @MaHD";
            List<SqlParameter> find_values = new List<SqlParameter>();
            find_values.Add(new SqlParameter("@MaHD", MaHD));
            DataTable dt = db.ExecuteQuery(query, find_values);

            HoaDonBanHangDTO hoadonSearch = new HoaDonBanHangDTO();
            foreach (DataRow dr in dt.Rows)
            {
                hoadonSearch.maKH = (int)dr["MAKH"];
                hoadonSearch.maNVLap = (int)dr["MANVLAP"];
                hoadonSearch.maNVGiao = (int)dr["MANVGIAO"];
                hoadonSearch.maNVXacThuc = (int)dr["MANVXACTHUC"];
                hoadonSearch.tongTien = Convert.ToSingle(dr["TONGTIEN"]);
                hoadonSearch.hinhThucThanhToan = (bool)dr["HINHTHUCTHANHTOAN"];
                hoadonSearch.xacNhanDaThanhToan = (bool)dr["XACNHANDATHANHTOAN"];
                hoadonSearch.ngayGiao = (DateTime)dr["NGAYGIAO"];
                hoadonSearch.soTienThanhToan = Convert.ToSingle(dr["SOTIENTHANHTOAN"]);
                hoadonSearch.ngayLap = (DateTime)(dr["NGAYLAPHOADON"]);
            }

            return hoadonSearch;

        }
    }
}
