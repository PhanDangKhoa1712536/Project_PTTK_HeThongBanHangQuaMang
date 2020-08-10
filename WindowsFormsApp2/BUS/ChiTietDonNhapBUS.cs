using DAO;
using DTO;
using System;

namespace BUS
{
    public class ChiTietDonNhapBUS
    {
        ChiTietDonNhapDAO chiTietDonNhapDAO;
        public ChiTietDonNhapBUS()
        {
            this.chiTietDonNhapDAO = new ChiTietDonNhapDAO();
        }
        public Boolean Insert(ChiTietDonNhapDTO chiTietDonNhap)
        {
            return chiTietDonNhapDAO.Insert(chiTietDonNhap);
        }
    }
}
