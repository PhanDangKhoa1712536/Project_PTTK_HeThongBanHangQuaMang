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
    public class HopDongDAO
    {
        DataProvider dp;
        public HopDongDAO()
        {
            this.dp = new DataProvider();
        }
        public List<DoiTacQuangCaoDTO> docHopDong()
        {
            String query = "SELECT * FROM DOITACQUANGCAO WHERE NGAYHETHAN <= GETDATE();";
            DataTable dt = this.dp.ExecuteQuery(query);

            List<DoiTacQuangCaoDTO> dtqcS = new List<DoiTacQuangCaoDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                DoiTacQuangCaoDTO dtqc = new DoiTacQuangCaoDTO((int)dr["MADOITAC"],
                    dr["TENDOITAC"].ToString(), (DateTime)dr["NGAYKYHOPDONG"],
                    (DateTime)dr["NGAYHETHAN"], dr["THONGTINVITRIDANG"].ToString(), dr["NOIDUNG"].ToString());

                dtqcS.Add(dtqc);
            }
            return dtqcS;
        }

        public void XoaHopSong(int MaHD)
        {
            string query = "DELETE FROM dbo.DOITACQUANGCAO WHERE MADOITAC = @MaHD";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));

            dp.ExecuteNonQuery(query, Find_values);
        }

        public void CapNhatHopDong(int MaHD, DateTime ngayKy, DateTime ngayHet, String ttvt, String nd)
        {
            string query = "UPDATE dbo.DOITACQUANGCAO SET NGAYKYHOPDONG = @nk, NGAYHETHAN = @nh," +
                "THONGTINVITRIDANG = @tt, NOIDUNG = @nd WHERE MADOITAC = @mahd";
            List<SqlParameter> Find_values = new List<SqlParameter>();
            Find_values.Add(new SqlParameter("@MaHD", MaHD));
            Find_values.Add(new SqlParameter("@nk", ngayKy));
            Find_values.Add(new SqlParameter("@nh", ngayHet));
            Find_values.Add(new SqlParameter("@tt", ttvt));
            Find_values.Add(new SqlParameter("@nd", nd));

            dp.ExecuteNonQuery(query, Find_values);
        }
    }
}
