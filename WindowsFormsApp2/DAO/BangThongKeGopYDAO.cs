using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class BangThongKeGopYDAO
    {
        readonly DataProvider dp;
        public BangThongKeGopYDAO()
        {
            dp = new DataProvider();
        }
        public int InsertBANGTHONGKE(BangThongKeGopYDTO bangThongKeGopYDTO)
        {
            String query = "INSERT INTO BANGTHONGKEGOPY (MANVLAP, NGAYLAP) OUTPUT INSERTED.MABANGTHONGKE VALUES (@MANVLAP, @NGAYLAP)";

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {

                // sqlParameters.Add(new SqlParameter("@MABANGTHONGKE", bangThongKeGopYDTO.maBangThongKe));
                new SqlParameter("@MANVLAP", bangThongKeGopYDTO.maNVLap),
                new SqlParameter("@NGAYLAP", bangThongKeGopYDTO.ngayLap)
            };

            var mabtk = this.dp.ExecuteScalar(query, sqlParameters);

            return mabtk;
        }

        public List<int> getBangThongKe()
        {
            string query = "SELECT MABANGTHONGKE FROM BANGTHONGKEGOPY";
            DataTable dt = dp.ExecuteQuery(query);
            List<int> mabangtk = new List<int>();
            foreach (DataRow dr in dt.Rows)
            {
                int temp = (int)dr["MABANGTHONGKE"];
                mabangtk.Add(temp);
            }
            return mabangtk;
        }

        public List<BangThongKeGopYDTO> getAllBangThongKeGopY()
        {
            String query = "SELECT * FROM BANGTHONGKEGOPY";
            DataTable dt = this.dp.ExecuteQuery(query);

            List<BangThongKeGopYDTO> lst = new List<BangThongKeGopYDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    BangThongKeGopYDTO bangThongKeGopYDTO = new BangThongKeGopYDTO((int)dr["MABANGTHONGKE"], (int)dr["MANVLAP"],(DateTime)dr["NGAYLAP"]);
                    lst.Add(bangThongKeGopYDTO);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return lst;

        }


    }


}