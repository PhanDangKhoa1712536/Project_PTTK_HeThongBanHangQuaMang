using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DonNhapHangDAO
    {
        DataProvider dp;
        public DonNhapHangDAO()
        {
            this.dp = new DataProvider();
        }
        public List<DonNhapHangDTO> getAll()
        {
            string query = "SELECT MADONNHAP, MANV, MANCC, TONGLUONGHANG, LYDONHAP, NGAYNHAP, TRANGTHAIXACNHAN FROM DONNHAPHANG";
            DataTable dt = dp.ExecuteQuery(query);

            List<DonNhapHangDTO> donNhapHangS = new List<DonNhapHangDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                DonNhapHangDTO donNhapHang = new DonNhapHangDTO((int)dr["MADONNHAP"], (int)dr["MANV"], (int)dr["MANCC"],
                    (int)dr["TONGLUONGHANG"], dr["LYDONHAP"].ToString(),
                    (DateTime)dr["NGAYNHAP"], (bool)dr["TRANGTHAIXACNHAN"]);

                donNhapHangS.Add(donNhapHang);
            }
            return donNhapHangS;
        }
    }
}
