using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HangDAO
    {
        private DataProvider dp;

        public HangDAO()
        {
            this.dp = new DataProvider();
        }

        public List<HangDTO> getAll()
        {
            String query = "SELECT * FROM HANG";
            DataTable dt = this.dp.ExecuteQuery(query);

            List<HangDTO> hangS = new List<HangDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                HangDTO hang = new HangDTO((int)dr["MAHANG"], (int)dr["MANVPHUTRACH"], (string)dr["TENHANG"],
                    (int)dr["SOLUONGCONLAI"], (float)dr["DONGIA"]);
                
                hangS.Add(hang);
            }
            return hangS;
        }
    }
}
