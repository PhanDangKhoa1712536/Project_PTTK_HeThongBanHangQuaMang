using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class NhanVienDAO
    {
        private DataProvider db;

        public NhanVienDAO()
        {
            db = new DataProvider();
        }
        public List<NhanVienDTO> getAll()
        {
            String query = "SELECT * FROM NHANVIEN";
            DataTable dt = this.db.ExecuteQuery(query);

            List<NhanVienDTO> nvS = new List<NhanVienDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO((int)dr["MANV"], (int)dr["LOAINV"],
                    dr["TENNHANVIEN"].ToString(), dr["TENDANGNHAP"].ToString(),
                    dr["MATKHAU"].ToString());
                nvS.Add(nv);
            }
            return nvS;
        }
        public NhanVienDTO getByUserPassword(string user, string password)
        {
            string query = "SELECT * FROM NHANVIEN WHERE TENDANGNHAP = '" + user + "' AND MATKHAU = '" + password + "'";
            using (DataTable dt = db.ExecuteQuery(query))
            {
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    return new NhanVienDTO((int)dr["MANV"], (int)dr["LOAINV"], dr["TENNV"].ToString(), dr["TENDANGNHAP"].ToString(), dr["MATKHAU"].ToString());
                }
            }
        }
        public List<int> DocMaNVGiaoHang()
        {
            // Cau Query
            string query = "SELECT MANV FROM NHANVIEN WHERE LOAINV = 5";
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
