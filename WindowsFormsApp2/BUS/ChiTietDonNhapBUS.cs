using DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace BUS
{
    public class ChiTietDonNhapBUS
    {
        private readonly ChiTietDonNhapDAO chiTietDonNhapDAO;
        public ChiTietDonNhapBUS()
        {
            this.chiTietDonNhapDAO = new ChiTietDonNhapDAO();
        }
        public List<ChiTietDonNhapDTO> LayDanhSachChiTietDonNhap(int maDonNhap)
        {
            return this.chiTietDonNhapDAO.getAllByMaDonNhap(maDonNhap);
        }
        public Boolean ThemChiTietDonNhap(ChiTietDonNhapDTO chiTietDonNhap)
        {
            return chiTietDonNhapDAO.Insert(chiTietDonNhap);
        }
    }
}
