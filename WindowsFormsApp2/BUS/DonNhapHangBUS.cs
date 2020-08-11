using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class DonNhapHangBUS
    {
        readonly DonNhapHangDAO donNhapHangDAO = new DonNhapHangDAO();
        public List<DonNhapHangDTO> getAll()
        {
            return donNhapHangDAO.getAll();
        }

        public int Insert(DonNhapHangDTO donNhapHang)
        {
            return this.donNhapHangDAO.Insert(donNhapHang);
        }

        public bool GuiChoNhaCungCap(DonNhapHangDTO donNhapHang)
        {
            return donNhapHangDAO.Update(donNhapHang);
        }
    }
}
