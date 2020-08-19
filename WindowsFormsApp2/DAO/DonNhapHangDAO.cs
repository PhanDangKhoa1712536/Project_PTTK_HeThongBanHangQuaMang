using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DonNhapHangDAO
    {
        readonly DataProvider dp;
        public DonNhapHangDAO()
        {
            this.dp = new DataProvider();
        }
        public List<DonNhapHangDTO> getAll()
        {
            string query = "SELECT NHANVIEN.MANV, DONNHAPHANG.MANCC, DONNHAPHANG.MADONNHAP, TRANGTHAIXACNHAN, LYDONHAP, NHANVIEN.TENNV, TONGLUONGHANG, NGAYNHAP FROM DONNHAPHANG, NHANVIEN, NHACUNGCAP " +
                "WHERE DONNHAPHANG.MANCC = NHACUNGCAP.MANCC AND NHANVIEN.MANV = DONNHAPHANG.MANV";
            DataTable dt = dp.ExecuteQuery(query);

            List<DonNhapHangDTO> donNhapHangS = new List<DonNhapHangDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                DonNhapHangDTO donNhapHang = new DonNhapHangDTO((int)dr["MADONNHAP"], (int)dr["MANV"], dr["TENNV"].ToString(), (int)dr["MANCC"],
                    (int)dr["TONGLUONGHANG"], dr["LYDONHAP"].ToString(),
                    (DateTime)dr["NGAYNHAP"], (bool)dr["TRANGTHAIXACNHAN"]);
                
                donNhapHangS.Add(donNhapHang);
            }
            return donNhapHangS;
        }
        public int Insert(DonNhapHangDTO donNhap)
        {
            string query = "insert into donnhaphang(manv, mancc, tongluonghang, lydonhap, ngaynhap, trangthaixacnhan) output INSERTED.madonnhap values (@MANV,0,@TONGLUONGHANG,@LYDONHAP,@NGAYNHAP,0)";
            List<SqlParameter> Inserted_values = new List<SqlParameter>
            {
                new SqlParameter("@MANV", donNhap.maNV),
                new SqlParameter("@TONGLUONGHANG", donNhap.tongLuongHang),
                new SqlParameter("@LYDONHAP", donNhap.lyDoNhap),
                new SqlParameter("@NGAYNHAP", donNhap.ngayNhap)
            };

            return dp.ExecuteScalar(query, Inserted_values);
        }

        public bool Update(DonNhapHangDTO donNhap)
        {
            string query = "UPDATE DONNHAPHANG SET MANCC = @MANCC, TRANGTHAIXACNHAN = 1 WHERE MADONNHAP = @MADONNHAP";
            List<SqlParameter> updValue = new List<SqlParameter>
            {
                new SqlParameter("@MANCC", donNhap.maNCC),
                new SqlParameter("@MADONNHAP", donNhap.maDonNhap)
            };

            return dp.ExecuteNonQuery(query, updValue);
        }

    }
}
