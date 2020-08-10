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
        public ChiTietHoaDonDTO KhoiTao(int MaHD, int MaHang, string TenHang, int SoLuong, float DonGia)
        {
            return new ChiTietHoaDonDTO(0, MaHang, TenHang, MaHD, SoLuong, DonGia);
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

        public float TinhTongHoaDon(List<ChiTietHoaDonDTO> List_CT)
        {
            float ret = 0;
            foreach (ChiTietHoaDonDTO i in List_CT)
            {
                ret += i.DonGia;
            }
            return ret;
        }
        // thay vì đọc thông tin từ giỏ hàng thì hàm sẽ thực hiện KHởi tạo 1 list những chi tiết hóa đơn dummy;
        public List<ChiTietHoaDonDTO> DocChiTietTuGioHang(int MaHD)
        {
            List<ChiTietHoaDonDTO> ret = new List<ChiTietHoaDonDTO>();
            ret.Add(KhoiTao(MaHD, 0, "MI AN LIEN INDOMIE VI SUON 200GR", 5, 30));
            ret.Add(KhoiTao(MaHD, 1, "GANG TAY CAO SU CASUMINA 2C", 5, 20));
            ret.Add(KhoiTao(MaHD, 2, "DAU GOI TRESSEME 500ML", 5, 15));
            return ret;
        }

    }
}
