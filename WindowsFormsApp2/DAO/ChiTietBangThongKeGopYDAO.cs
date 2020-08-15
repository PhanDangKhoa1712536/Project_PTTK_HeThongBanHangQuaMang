using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ChiTietBangThongKeGopYDAO
    {
        DataProvider dp;
        public ChiTietBangThongKeGopYDAO()
        {
            dp = new DataProvider();
        }
        public Boolean Insert(ChiTietBangThongKeGopYDTO chiTietBangThongKeGopYDTO)
        {
            String query = "INSERT INTO CHITIETBANGTHONGKE (MABANGTHONGKE, MAGOPY) VALUES (@MABANGTHONGKE, @MAGOPY)";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@MABANGTHONGKE", chiTietBangThongKeGopYDTO.maBangThongKe));
            sqlParameters.Add(new SqlParameter("@MAGOPY", chiTietBangThongKeGopYDTO.maGopY));

            return this.dp.ExecuteNonQuery(query, sqlParameters);
        }
    }
}
