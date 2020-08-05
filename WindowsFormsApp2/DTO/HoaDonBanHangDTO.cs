using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonBanHangDTO
    {
        public int maHoaDon { get; set; }
        public int maKhachHang { get; set; }
        public int maNhanVienLap { get; set; }
        public int maNhanVienGiao { get; set; }
        public int maNhanVienXacThuc { get; set; }
        public float tongTien { get; set; }
        public bool hinhThucThanhToan { get; set; }
        public bool xacNhanDaThanhToan { get; set; }
        public DateTime ngayGiaoHang { get; set; }
        public float soTienThanhToan { get; set; }
        HoaDonBanHangDTO(int maHoaDon, int maKhachHang, int maNhanVienLap,
            int maNhanVienGiao, int maNhanVienXacThuc, float tongTien,
            bool hinhThucThanhToan, bool xacNhanDaThanhToan, DateTime ngayGiaoHang,
            float soTienThanhToan)
        {
            this.maHoaDon = maHoaDon;
            this.maKhachHang = maKhachHang;
            this.maNhanVienLap = maNhanVienLap;
            this.maNhanVienGiao = maNhanVienGiao;
            this.maNhanVienXacThuc = maNhanVienXacThuc;
            this.tongTien = tongTien;
            this.ngayGiaoHang = ngayGiaoHang;
            this.soTienThanhToan = soTienThanhToan;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.xacNhanDaThanhToan = xacNhanDaThanhToan;
        }
    }
}
