using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
     public class ChiTietDonTraHangBUS
    {
        private readonly ChiTietDonTraDAO chiTietDonTraDAO = new ChiTietDonTraDAO();

        public int CTMaDon_autoGen()
        {
            return chiTietDonTraDAO.MaChiTietDonTraHang_AutoGen();
        }

        public void ThemChiTietDonTraHang(int MaChiTietDon, int MaDonTra, int MaHangLoi, int SoLuong, string LyDo)
        {
            chiTietDonTraDAO.Insert_ChiTietDonTra( MaChiTietDon,  MaDonTra,  MaHangLoi,  SoLuong, LyDo);
        }
    }
}
