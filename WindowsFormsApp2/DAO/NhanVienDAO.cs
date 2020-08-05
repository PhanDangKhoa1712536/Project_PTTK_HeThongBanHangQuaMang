using DTO;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class NhanVienDAO
    {
        private DataProvider db;
        
        public NhanVienDAO()
        {
            db = new DataProvider();
        }

        public List<int> DocMaNVGiaoHang()
        {
            // Cau Query
            string query = "SELECT MANV FROM NHANVIEN";
            // Thuc Hien Cau Query
            DataTable dt = db.ExecuteQuery(query);
            // Khoi tao list MaNV tra ve
            List<int> ret = new List<int>();
            // Doc tung dong trong ket qua tra ve va them vao list
            foreach (DataRow dr in dt.Rows)
            {
                ret.Add((int)dr["MANV"]);
            }
            return ret;
        }
    }
}
