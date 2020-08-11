using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class ChiTietDonNhapBUS
    {
        readonly ChiTietDonNhapDAO chiTietDonNhapDAO;
        public ChiTietDonNhapBUS()
        {
            this.chiTietDonNhapDAO = new ChiTietDonNhapDAO();
        }
        public List<ChiTietDonNhapDTO> getAllByMaDonNhap(int maDonNhap)
        {
            return this.chiTietDonNhapDAO.getAllByMaDonNhap(maDonNhap);
        }
        public Boolean Insert(ChiTietDonNhapDTO chiTietDonNhap)
        {
            return chiTietDonNhapDAO.Insert(chiTietDonNhap);
        }
    }
}
