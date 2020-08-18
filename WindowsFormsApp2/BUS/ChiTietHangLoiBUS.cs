using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class ChiTietHangLoiBUS
    {
        private readonly ChiTietHangLoiDAO chiTietHangLoiDAO;
        
        public ChiTietHangLoiBUS()
        {
            chiTietHangLoiDAO = new ChiTietHangLoiDAO();
        }

        public int MaChiTietHangLoi()
        {
            return chiTietHangLoiDAO.MaChiTietHangLoi_AutoGen();
        }

        public void ThemChiTietHangLoi(int MaCTHangLoi,int MaHoaDon,int MaHangLoi)
        {
            chiTietHangLoiDAO.Insert_ChiTietHangLoi(MaCTHangLoi, MaHoaDon, MaHangLoi);
        }
    }
}
