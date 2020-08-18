using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class HopDongBUS
    {
        HopDongDAO hopdongDAO;
        public HopDongBUS()
        {
            hopdongDAO = new HopDongDAO();
        }

        public List<DoiTacQuangCaoDTO> DocHopDong()
        {
            return hopdongDAO.DocHopDong();
        }

        public bool KiemTraThongTin(DateTime ngayKy, DateTime ngayHet, String ttvt, String nd)
        {
            if (ngayKy == null || ngayHet == null || ttvt == "" || nd == "" || ngayHet <= ngayKy)
                return false;
            return true;
        }

        public void HuyHopDong(int MaHD)
        {
            hopdongDAO.XoaHopSong(MaHD);
        }

        public void CapNhatHopDong(int MaHD, DateTime ngayKy, DateTime ngayHet, String ttvt, String nd)
        {
            hopdongDAO.CapNhatHopDong(MaHD, ngayKy, ngayHet, ttvt, nd);
        }
    }
}
