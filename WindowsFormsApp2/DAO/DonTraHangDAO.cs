using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DAO
{
    public class DonTraHangDAO
    {
        readonly DataProvider dp;

        public DonTraHangDAO()
        {
            this.dp = new DataProvider();
        }

        public int MaDonTraHang_AutoGen()
        {
            string query = "SELECT COUNT(*) FROM DONTRAHANG";

            dp.connection.Open();
            SqlCommand command = new SqlCommand(query, dp.connection);
            int value = Convert.ToInt32(command.ExecuteScalar());
            dp.connection.Close();
            return value;
        }

        public void Insert_traHang(int MaDonTra, int maNVLap, int maNCC, DateTime ngayLap)
        {
            string query = "SET IDENTITY_INSERT DONTRAHANG ON; INSERT INTO DONTRAHANG(MADONTRA, MANVLAP,MANCC,NGAYLAP) VALUES (@MaDonTra,@MaNVLap,@MaNCC,@NgayLap);SET IDENTITY_INSERT DONTRAHANG OFF;";
            List<SqlParameter> Inserted_values = new List<SqlParameter>
            {

                new SqlParameter("@MaDonTra",MaDonTra),
                new SqlParameter("@MaNVLap", maNVLap),
                new SqlParameter("@MaNCC", maNCC),
                new SqlParameter("@NgayLap", ngayLap)


            };
            dp.ExecuteNonQuery(query, Inserted_values);

        }
    }
}
