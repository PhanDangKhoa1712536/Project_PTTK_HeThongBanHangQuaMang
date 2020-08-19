using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class DonNhapHangBUS
    {
        private readonly DonNhapHangDAO donNhapHangDAO = new DonNhapHangDAO();
        public List<DonNhapHangDTO> LayDanhSachDonNhapHang()
        {
            return donNhapHangDAO.getAll();
        }

        public int KhoiTaoDonNhapHang(DonNhapHangDTO donNhapHang)
        {
            return this.donNhapHangDAO.Insert(donNhapHang);
        }

        public bool GuiChoNhaCungCap(DonNhapHangDTO donNhapHang)
        {
            return donNhapHangDAO.Update(donNhapHang);
        }
    }
}
