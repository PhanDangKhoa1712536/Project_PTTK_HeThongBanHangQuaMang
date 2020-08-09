using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GopYDAO
    {
        DataProvider dp;
        public GopYDAO()
        {
            dp = new DataProvider();
        }
        public List<GopYDTO> getAll()
        {
            String query = "SELECT * FROM GOPY";
            DataTable dt = this.dp.ExecuteQuery(query);

            List<GopYDTO> lstGopY = new List<GopYDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    GopYDTO gopy = new GopYDTO((int)dr["MAGOPY"], (int)dr["MAHANG"], (int)dr["MAKH"], dr["NOIDUNG"].ToString(),
                        (DateTime)dr["NGAYGOPY"], (bool)dr["FLAGXAU"], (DateTime)dr["NGAYCHINHSUARECORD"]);
                    lstGopY.Add(gopy);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return lstGopY;
        }
    }
}
