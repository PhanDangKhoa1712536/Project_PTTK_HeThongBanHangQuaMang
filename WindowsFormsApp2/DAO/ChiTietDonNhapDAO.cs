﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ChiTietDonNhapDAO
    {
        private readonly DataProvider dp;

        public ChiTietDonNhapDAO()
        {
            dp = new DataProvider();
        }

        public List<ChiTietDonNhapDTO> getAllByMaDonNhap(int MaDonNhap)
        {
            string query = "select C.MACHITIETDONNHAP, C.MADONNHAP, H.MAHANG, H.TENHANG, C.SOLUONGNHAP from chitietdonnhap C, HANG H where C.MAHANG = H.MAHANG AND madonnhap = @MADONNHAP";
            List<SqlParameter> Find_values = new List<SqlParameter>
            {
                new SqlParameter("@MADONNHAP", MaDonNhap)
            };

            DataTable dt = dp.ExecuteQuery(query, Find_values);
            List<ChiTietDonNhapDTO> ret = new List<ChiTietDonNhapDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                ChiTietDonNhapDTO temp = new ChiTietDonNhapDTO((int)dr["MACHITIETDONNHAP"], (int)dr["MADONNHAP"], (int)dr["MAHANG"], dr["TENHANG"].ToString(), (int)dr["SOLUONGNHAP"]);
                ret.Add(temp);
            }
            return ret;
        }

        public Boolean Insert(ChiTietDonNhapDTO chiTietDonNhap)
        {
            string query = "INSERT INTO CHITIETDONNHAP(MADONNHAP, MAHANG, SOLUONGNHAP) VALUES (@MADONNHAP, @MAHANG, @SOLUONGNHAP)";
            List<SqlParameter> inserted_values = new List<SqlParameter>
            {
                new SqlParameter("@MADONNHAP", chiTietDonNhap.maDonNhap),
                new SqlParameter("@MAHANG", chiTietDonNhap.maHang),
                new SqlParameter("@SOLUONGNHAP", chiTietDonNhap.soLuongNhap)
            };

            return dp.ExecuteNonQuery(query, inserted_values);
        }
    }
}
