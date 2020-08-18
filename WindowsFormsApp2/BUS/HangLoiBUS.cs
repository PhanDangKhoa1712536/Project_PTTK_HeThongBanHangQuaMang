using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class HangLoiBUS
    {
        private readonly HangLoiDAO hangLoiDAO;

        public HangLoiBUS()
        {
            hangLoiDAO = new HangLoiDAO();
        }

        public bool KiemTraTonTai(int MaHangLoi)
        {
            return hangLoiDAO.CheckExist_HangLoi(MaHangLoi);
        }

        public void ThemSoLuong(int MaHangLoi,int SoLuong)
        {
            hangLoiDAO.Insert_HangLoi_Existed(MaHangLoi, SoLuong);
        }

        public void ThemHangLoi(int MaHangLoi,int SoLuong)
        {
            hangLoiDAO.Insert_HangLoi(MaHangLoi, SoLuong);
        }
    }
}
