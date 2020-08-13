using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class HangDAO
    {
        private readonly DataProvider dp;

        public HangDAO()
        {
            this.dp = new DataProvider();
        }

        public List<HangDTO> Utility_getSaleBetween(DateTime d1, DateTime d2)
        {
            String query = "SELECT H.MAHANG, H.TENHANG, ISNULL(SUM(SOLUONG), 0) AS [DABAN] FROM CHITIETHOADON C RIGHT JOIN HANG H " +
                "ON H.MAHANG = C.MAHANG JOIN HOADONBANHANG HD ON HD.MAHOADON = C.MAHOADON " +
                "AND HD.NGAYLAPHOADON BETWEEN @d1 AND @d2 " +
                "GROUP BY H.MAHANG, H.TENHANG " +
                "UNION ALL(SELECT H1.MAHANG, H1.TENHANG, 0 AS[DABAN] FROM HANG H1 " +
                "WHERE H1.MAHANG NOT IN(SELECT H2.MAHANG FROM CHITIETHOADON C2 JOIN HANG H2 " +
                "ON H2.MAHANG = C2.MAHANG JOIN HOADONBANHANG HD2 ON HD2.MAHOADON = C2.MAHOADON " +
                "AND HD2.NGAYLAPHOADON BETWEEN @d1 AND @d2 " +
                "GROUP BY H2.MAHANG) " +
                "GROUP BY H1.MAHANG, H1.TENHANG)";

            List<SqlParameter> dateRange = new List<SqlParameter>
            {
                new SqlParameter("@d1", d1),
                new SqlParameter("@d2", d2)
            };

            List<HangDTO> hangS = new List<HangDTO>();
            DataTable dt = dp.ExecuteQuery(query, dateRange);
            foreach (DataRow dr in dt.Rows)
            {
                HangDTO hang = new HangDTO
                {
                    maHang = int.Parse(dr["MAHANG"].ToString()),
                    tenHang = dr["TENHANG"].ToString(),
                    soLuongDaBan = (int)dr["DABAN"]
                };

                hangS.Add(hang);
            }
            return hangS;
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
