using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class LichSuQuangCaoDAO
    {
        private readonly DataProvider dp;

        public LichSuQuangCaoDAO()
        {
            this.dp = new DataProvider();
        }

        public void ThemLichSu(int MaKH, int MaMH)
        {
            string query = "INSERT INTO dbo.LICHSUQUANGCAO(MAKH, MAHANG) VALUES (@makh, @mamh)";
            List<SqlParameter> values = new List<SqlParameter>
            {
                new SqlParameter("@makh", MaKH),
                new SqlParameter("@mamh", MaMH)
            };

            dp.ExecuteNonQuery(query, values);
        }
    }
}
