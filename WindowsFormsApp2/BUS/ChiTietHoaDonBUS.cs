using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        public ChiTietHoaDonDAO chiTietHoaDonDAO;

        public ChiTietHoaDonBUS()
        {
            chiTietHoaDonDAO = new ChiTietHoaDonDAO();
        }
        public ChiTietHoaDonDTO KhoiTao(int MaHD, int MaHang, int SoLuong)
        {
            return new ChiTietHoaDonDTO(0, MaHD, MaHang, SoLuong);
        }
        public void ThemChiTietDon_bus(ChiTietHoaDonDTO CT)
        {
            chiTietHoaDonDAO.ThemChiTietHoaDon(CT);
        }

        public void XoaCT(int MaHD)
        {
            chiTietHoaDonDAO.XoaChiTietHD(MaHD);
        }
        public List<ChiTietHoaDonDTO> LoadCTHoaDon(int MaHD)
        {
            return chiTietHoaDonDAO.DocChiTietHoaDon(MaHD);
        }

    }
}
