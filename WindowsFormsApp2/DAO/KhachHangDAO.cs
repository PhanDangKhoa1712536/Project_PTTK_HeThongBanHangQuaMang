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
    public class KhachHangDAO
    {
        // Connect to DB
        private DataProvider db;
        
        public KhachHangDAO()
        {
            this.db = new DataProvider();
        }

        // DAL Fuction of KhachHang_DB

        public void ThemKhachHang_DAL(KhachHangDTO KH)
        {
            // cau query
            string query = "INSERT INTO KHACHHANG() VALUES (@maKH, @tenKH, @diaChiKH,@emailKH, @TrangThaiKhoaComment)";
            // Khoi tao List SQLParameter
            List<SqlParameter> Inserted_values = new List<SqlParameter>();
            Inserted_values.Add(new SqlParameter("@tenKH", KH.tenKH));
            Inserted_values.Add(new SqlParameter("@diaChiKH", KH.diaChiKH));
            Inserted_values.Add(new SqlParameter("@emailKH", KH.emailKH));
            Inserted_values.Add(new SqlParameter("@TrangThaiKhoaComment", KH.trangThaiKhoaComment));
            // Thuc hien cau query
            db.ExecuteNonQuery(query, Inserted_values);
        }

        public List<KhachHangDTO> TimKhachHang(string TenKH, string DiaChi, string Email)
        {
            // cau query
            string query = "SELECT * FROM KHACHHANG WHERE TENKH = @TenKH and DIACHIKH = @DiaChi and EMAILKH = @Email";

            // Khoi tao list SQL parameter
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@TenKh", TenKH));
            Find_values.Add(new SqlParameter("@DiaChi", DiaChi));
            Find_values.Add(new SqlParameter("@EmailKh", Email));
            // Thuc hien cau query
            DataTable dt = db.ExecuteQuery(query, Find_values);
            // Khoi tao list khach hang
            List<KhachHangDTO> ret = new List<KhachHangDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHangDTO temp = new KhachHangDTO((int)dr["MAKH"], dr["TENKH"].ToString(), dr["EMAILKH"].ToString(), dr["DIACHIKH"].ToString(), (bool)dr["TRANGTHAIKHOACOMMENT"]);
                ret.Add(temp);
            }
            return ret;
        }

        public KhachHangDTO TimKhachHang_MaKH(int MaKH)
        {
            string query = "SELECT * FROM KHACHHANG WHERE MAKH = @MaKH";
            List<SqlParameter> find_values = new List<SqlParameter>();
            find_values.Add(new SqlParameter("@MaKH", MaKH));
            DataTable dt = db.ExecuteQuery(query, find_values);
            KhachHangDTO ret = new KhachHangDTO(MaKH, dt.Rows[0]["TENKH"].ToString(), dt.Rows[0]["DIACHIKH"].ToString(), dt.Rows[0]["EMAILKH"].ToString(), (bool)dt.Rows[0]["TRANGTHAIKHOACOMMENT"]);
            return ret;
        }

        public int DocMaKHMoiNhat()
        {
            string query = "SELECT MAX(MAKH) FROM KHACHHANG";
            DataTable dt = db.ExecuteQuery(query);
            return (int)dt.Rows[0]["MAKH"];
        }

        // Tim khach hang theo ten su dung cho chuc nang Tra Hang (Tim theo ten khach hang)
        public KhachHangDTO TimKH_TraHang(string TenKH)
        {
            List<SqlParameter> VALUES = new List<SqlParameter>();
            VALUES.Add(new SqlParameter("@Ten", TenKH));
              
            string query = "SELECT * FROM KHACHHANG WHERE TENKH = @Ten";
            KhachHangDTO khachhang = new KhachHangDTO();
            DataTable dt = this.db.ExecuteQuery(query,VALUES);
            foreach (DataRow dr in dt.Rows)
            {
                khachhang.tenKH = dr["TENKH"].ToString();
                khachhang.emailKH = dr["EMAILKH"].ToString();
                khachhang.diaChiKH = dr["DIACHIKH"].ToString();
                khachhang.trangThaiKhoaComment = (bool)dr["TRANGTHAIKHOACOMMENT"];
            }
            
            return khachhang;


        }

    }
}

