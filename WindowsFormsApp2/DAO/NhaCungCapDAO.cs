using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhaCungCapDAO
    {
        DataProvider dp;
        public NhaCungCapDAO()
        {
            this.dp = new DataProvider();
        }
        public List<NhaCungCapDTO> getAll()
        {
            String query = "SELECT * FROM NHACUNGCAP";
            DataTable dt = this.dp.ExecuteQuery(query);

            List<NhaCungCapDTO> nccS = new List<NhaCungCapDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO((int)dr["MANCC"], dr["TENNCC"].ToString());

                nccS.Add(ncc);
            }
            return nccS;
        }
    }
}
