using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class NhaCungCapDAO
    {
        private readonly DataProvider dp;
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

        public List<NhaCungCapDTO> getByKeyword(string keyword)
        {
            String query = "SELECT * FROM NHACUNGCAP WHERE MANCC LIKE '%"+ keyword + "%' OR TENNCC LIKE '%" + keyword + "%'";
            
            DataTable dt = this.dp.ExecuteQuery(query);

            List<NhaCungCapDTO> nccS = new List<NhaCungCapDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO((int)dr["MANCC"], dr["TENNCC"].ToString());

                nccS.Add(ncc);
            }
            return nccS;
        }

        public string getTenNCCbyIDDonNhap(string id)
        {
            string query = "SELECT TENNCC FROM DONNHAPHANG D JOIN NHACUNGCAP N ON N.MANCC = D.MANCC AND D.MADONNHAP = @MADONNHAP";
            List<SqlParameter> ids = new List<SqlParameter>
            {
                new SqlParameter("@MADONNHAP", id)
            };
            DataTable dt = dp.ExecuteQuery(query, ids);
            DataRow dr = dt.Rows[0];
            return dr["TENNCC"].ToString();
        }
    }
}
