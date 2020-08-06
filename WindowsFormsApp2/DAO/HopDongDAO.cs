using DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
                    (int)dr["MAHANG"], dr["TENDOITAC"].ToString(), (DateTime)dr["NGAYKYHOPDONG"],
                    (DateTime)dr["NGAYHETHAN"], dr["THONGTINVITRIDANG"].ToString(), dr["NOIDUNG"].ToString());

                dtqcS.Add(dtqc);
            }
            return dtqcS;
        }
    }
}
