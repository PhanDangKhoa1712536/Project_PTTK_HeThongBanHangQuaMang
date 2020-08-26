using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GopYDAO
    {
        private readonly DataProvider dp;
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
                        (DateTime)dr["NGAYGOPY"], (bool)dr["FLAGXAU"], (DateTime)dr["NGAYCHINHSUARECORD"], dr["TENHANG"].ToString(), (bool)dr["FLAGTANGQUA"], (bool)dr["FLAGXACNHANXOA"]);
                    lstGopY.Add(gopy);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return lstGopY;
        }

        public List<GopYDTO> getByDate(DateTime FromDate, DateTime ToDate)
        {
            String query = "SELECT g.*,tenhang FROM GOPY g, hang h WHERE h.mahang=g.mahang and NGAYGOPY BETWEEN @FROMDATE AND @TODATE";
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@FROMDATE", FromDate),
                new SqlParameter("@TODATE", ToDate)
            };
            DataTable dt = this.dp.ExecuteQuery(query, sqlParameters);

            List<GopYDTO> lstGopY = new List<GopYDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    GopYDTO gopy = new GopYDTO((int)dr["MAGOPY"], (int)dr["MAHANG"], (int)dr["MAKH"], dr["NOIDUNG"].ToString(),
                        (DateTime)dr["NGAYGOPY"], (bool)dr["FLAGXAU"], (DateTime)dr["NGAYCHINHSUARECORD"], dr["TENHANG"].ToString(), (bool)dr["FLAGTANGQUA"], (bool)dr["FLAGXACNHANXOA"]);
                    lstGopY.Add(gopy);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return lstGopY;
        }

        public Boolean Update(GopYDTO gopYDTO)
        {
            String query = "UPDATE GOPY SET FlagXau = @flagXau WHERE MAGOPY = @maGopY";

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@flagXau", gopYDTO.DanhDauCommentXau),
                new SqlParameter("@maGopY", gopYDTO.MaGopY)
            };

            return this.dp.ExecuteNonQuery(query, sqlParameters);
        }


        public List<GopYDTO> getAllCommentXauByBangThongKe(int maBangThongKe)
        {
            String query = "SELECT g.*,tenhang FROM BANGTHONGKEGOPY b, CHITIETBANGTHONGKE c, GOPY g,Hang h WHERE b.MABANGTHONGKE=c.MABANGTHONGKE AND c.MAGOPY=g.MAGOPY AND g.FLAGXAU=1 AND g.MaHang=h.MaHang AND b.MABANGTHONGKE=@MABANGTHONGKE";
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@MABANGTHONGKE", maBangThongKe)
            };

            DataTable dt = this.dp.ExecuteQuery(query, sqlParameters);

            List<GopYDTO> lstGopY = new List<GopYDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    GopYDTO gopy = new GopYDTO((int)dr["MAGOPY"], (int)dr["MAHANG"], (int)dr["MAKH"], dr["NOIDUNG"].ToString(),
                        (DateTime)dr["NGAYGOPY"], (bool)dr["FLAGXAU"], (DateTime)dr["NGAYCHINHSUARECORD"], dr["TENHANG"].ToString(), (bool)dr["FLAGTANGQUA"], (bool)dr["FLAGXACNHANXOA"]);
                    lstGopY.Add(gopy);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return lstGopY;

        }

        public List<GopYDTO> getAllCommentTotByBangThongKe(int maBangThongKe)
        {
            String query = "SELECT g.*,tenhang FROM BANGTHONGKEGOPY b, CHITIETBANGTHONGKE c, GOPY g, HANG h WHERE h.MaHang=g.MaHang and b.MABANGTHONGKE=c.MABANGTHONGKE AND c.MAGOPY=g.MAGOPY AND g.FLAGXAU=0 AND b.MABANGTHONGKE=@MABANGTHONGKE";
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@MABANGTHONGKE", maBangThongKe)
            };

            DataTable dt = this.dp.ExecuteQuery(query, sqlParameters);

            List<GopYDTO> lstGopY = new List<GopYDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    GopYDTO gopy = new GopYDTO((int)dr["MAGOPY"], (int)dr["MAHANG"], (int)dr["MAKH"], dr["NOIDUNG"].ToString(),
                        (DateTime)dr["NGAYGOPY"], (bool)dr["FLAGXAU"], (DateTime)dr["NGAYCHINHSUARECORD"], dr["TENHANG"].ToString(), (bool)dr["FLAGTANGQUA"], (bool)dr["FLAGXACNHANXOA"]);
                    lstGopY.Add(gopy);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return lstGopY;
        }

        public Boolean UpdateTangQua(GopYDTO gopYDTO)
        {
            String query = "UPDATE GOPY SET FLAGTANGQUA = 1 WHERE MAGOPY = @maGopY";

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@maGopY", gopYDTO.MaGopY)
            };

            return this.dp.ExecuteNonQuery(query, sqlParameters);
        }

        public Boolean UpdateXacNhanXoaGopY(GopYDTO gopYDTO)
        {
            String query = "UPDATE GOPY SET FLAGXACNHANXOA = 1 WHERE MAGOPY = @maGopY";

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@maGopY", gopYDTO.MaGopY)
            };

            return this.dp.ExecuteNonQuery(query, sqlParameters);
        }


        public Boolean DeleteComment(GopYDTO gopYDTO)
        {
            String query = "DELETE FROM GOPY WHERE MAGOPY = @MAGOPY";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@MAGOPY", gopYDTO.MaGopY);
            sqlParameters.Add(parameter);

            return this.dp.ExecuteNonQuery(query, sqlParameters);
        }
    }

}
