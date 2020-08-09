using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LichSuQuangCaoDAO
    {
        private DataProvider dp;

        public LichSuQuangCaoDAO()
        {
            this.dp = new DataProvider();
        }

        public void ThemLichSu(int MaLS, int MaKH, int MaMH)
        {
            string query = "INSERT INTO dbo.LICHSUQUANGCAO(MALSQC, MAKH, MAHANG) VALUES (@mals, @makh, @mamh)";
            List<SqlParameter> values = new List<SqlParameter>();
            values.Add(new SqlParameter("@mals", MaLS));
            values.Add(new SqlParameter("@makh", MaKH));
            values.Add(new SqlParameter("@mamh", MaMH));

            dp.ExecuteNonQuery(query, values);
        }

        public int LayMaLichSu()
        {
            String query = "SELECT * FROM dbo.LICHSUQUANGCAO";
            DataTable dt = this.dp.ExecuteQuery(query);

            List<LichSuQuangCaoDTO> lsS = new List<LichSuQuangCaoDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                LichSuQuangCaoDTO ls = new LichSuQuangCaoDTO((int)dr["MALSQC"], (int)dr["MAKH"], (int)dr["MAHANG"]);

                lsS.Add(ls);
            }

            return Int32.Parse(lsS[lsS.Count - 1].maLSQC.ToString());
        }
    }
}
