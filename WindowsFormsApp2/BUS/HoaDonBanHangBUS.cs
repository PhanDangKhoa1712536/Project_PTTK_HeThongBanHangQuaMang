using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO;
using DAO;

namespace BUS
{
    public class HoaDonBanHangBUS
    {
       public  HoaDonBanHangDAO hoaDonBanHangDAO;
       
        public HoaDonBanHangBUS()
        {
            hoaDonBanHangDAO = new HoaDonBanHangDAO();
        }
        public HoaDonBanHangDTO KhoiTao(DateTime NgayGiao,DateTime NgayLap, int MaKH, int MaNVLap, int MaNVGiao,int MaHD, float TongTien)
        {
            return new HoaDonBanHangDTO(MaHD, MaKH, MaNVLap, MaNVGiao,0, TongTien, false, false, NgayGiao,NgayLap,0);
        }

        public bool KiemTraTrangThaiHoaDon(HoaDonBanHangDTO HD)
        {
            return HD.xacNhanDaThanhToan;
        }
        public List<int> LoadMaHD()
        {
            return hoaDonBanHangDAO.DocTatCaMaHD();
        }
        public HoaDonBanHangDTO LoadTTHoaDon(int MaHD)
        {
            return hoaDonBanHangDAO.DocThongTinHD(MaHD);
        }
        public void XoaHD(int MaHD)
        {
            hoaDonBanHangDAO.XoaHDBanHang(MaHD);
        }
        public void LapHoaDonBanHang(HoaDonBanHangDTO HD)
        {
            hoaDonBanHangDAO.ThemHoaDonBanHang(HD);
        }
        public bool KiemTraNgayGiaoHang(DateTime NgayGiao)
        {
            return (NgayGiao >= DateTime.Now && NgayGiao.Day - DateTime.Now.Day <= 20);
        }
        public int CreateMaHD()
        {
            return hoaDonBanHangDAO.DocMaHDMoiNhat() + 1;
        }

        public HoaDonBanHangDTO SearchHD_TraHang(int MaHD)
        {
            return hoaDonBanHangDAO.TimHoaDon_TraHang(MaHD);
        }

        
    }
}
