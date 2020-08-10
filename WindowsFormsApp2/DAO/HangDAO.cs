using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class HangDAO
    {
        private DataProvider dp;

        public HangDAO()
        {
            this.dp = new DataProvider();
        }

        public DataTable getSaleBetween(DateTime d1, DateTime d2)
        {
            String query = "SELECT H.MAHANG, H.TENHANG, SUM(SOLUONG) AS [DABAN] FROM CHITIETHOADON C RIGHT JOIN HANG H " +
                "ON H.MAHANG = C.MAHANG LEFT JOIN HOADONBANHANG HD ON HD.MAHOADON = C.MAHOADON AND HD.NGAYLAPHOADON BETWEEN " +
                "@d1 AND @d2 " +
                "GROUP BY H.MAHANG, H.TENHANG";

            List<SqlParameter> dateRange = new List<SqlParameter>();
            dateRange.Add(new SqlParameter("@d1", d1));
            dateRange.Add(new SqlParameter("@d2", d2));

            return this.dp.ExecuteQuery(query, dateRange);
        }

        public List<HangDTO> DocMatHang(string keyword)
        {
            String query = "SELECT * FROM HANG";
            if (keyword != "")
            {
                bool isNumeric = int.TryParse(keyword, out _);

                if (isNumeric)
                {
                    query += " WHERE MAHANG = " + keyword;
                }
                else
                {
                    query += " WHERE TENHANG = '" + keyword + "'";
                }
            }
            DataTable dt = this.dp.ExecuteQuery(query);

            List<HangDTO> hangS = new List<HangDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                HangDTO hang = new HangDTO((int)dr["MAHANG"], (int)dr["MANVPHUTRACH"], (string)dr["TENHANG"],
                    (int)dr["SOLUONGCONLAI"], (double)dr["DONGIA"]);

                hangS.Add(hang);
            }

            return hangS;
        }
    }
}
