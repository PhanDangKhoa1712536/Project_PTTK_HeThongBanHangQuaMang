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
    class HoaDonBanHangDAO
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
    }
}