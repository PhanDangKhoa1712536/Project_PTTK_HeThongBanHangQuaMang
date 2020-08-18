using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DonTraHangBUS
    {
        private readonly DonTraHangDAO donTraHangDAO = new DonTraHangDAO();

        public int MaDon_autoGen()
        {
            return donTraHangDAO.MaDonTraHang_AutoGen();
        }

        public void ThemDonTraHang(int MaDonTra, int maNVLap, int maNCC, DateTime ngayLap)
        {
            donTraHangDAO.Insert_traHang(MaDonTra, maNVLap,maNCC,ngayLap);
        }
    }
}
