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
    class ChiTietHoaDonDAO
    {
        private DataProvider db;
        
        public ChiTietHoaDonDAO()
        {
            db = new DataProvider();
        }
        public List<ChiTietHoaDonDTO> DocChiTietDonHang(int MaHD)
        {
            string query = "SELECT * FROM CHITIETHOADON WHERE MAHD = @MaHD";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            DataTable dt = db.ExecuteQuery(query, Find_values);
            List<ChiTietHoaDonDTO> ret = new List<ChiTietHoaDonDTO>();
            foreach(DataRow dr in dt.Rows)
            {
                ChiTietHoaDonDTO temp = new ChiTietHoaDonDTO((int)dr["MACHITIETHOADON"], (int)dr["MAHANG"], (int)dr["MAHD"], (int)dr["SOLUONG"]);
                ret.Add(temp);
            }
            return ret;
        }
        
      
    }
}
