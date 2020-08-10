using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class DonNhapHangBUS
    {
        DonNhapHangDAO donNhapHangDAO = new DonNhapHangDAO();
        public List<DonNhapHangDTO> getAll()
        {
            return donNhapHangDAO.getAll();
        }

        public int Insert(DonNhapHangDTO donNhapHang)
        {
            return this.donNhapHangDAO.Insert(donNhapHang);
        }
    }
}
