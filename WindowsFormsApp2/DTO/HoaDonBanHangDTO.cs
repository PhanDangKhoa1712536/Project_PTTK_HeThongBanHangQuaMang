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
        public int maKH { get; set; }
        public int maNVLap { get; set; }
        public int maNVGiao { get; set; }
        public int maNVXacThuc { get; set; }
        public float tongTien { get; set; }
        public bool hinhThucThanhToan { get; set; }
        public bool xacNhanDaThanhToan { get; set; }
        public DateTime ngayGiao { get; set; }
        public float soTienThanhToan { get; set; }
            
        public DateTime ngayLap { get; set; }
        public HoaDonBanHangDTO(int maHoaDon, int maKH, int maNVLap,
            int maNVGiao, int maNVXacThuc, float tongTien,
            bool hinhThucThanhToan, bool xacNhanDaThanhToan, DateTime ngayGiao, DateTime NgayLap,
            float soTienThanhToan)
        {
            this.maHoaDon = maHoaDon;
            this.maKH = maKH;
            this.maNVLap = maNVLap;
            this.maNVGiao = maNVGiao;
            this.maNVXacThuc = maNVXacThuc;
            this.tongTien = tongTien;
            this.ngayGiao = ngayGiao;
            this.soTienThanhToan = soTienThanhToan;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.xacNhanDaThanhToan = xacNhanDaThanhToan;
            this.ngayLap = NgayLap;
        }

        public HoaDonBanHangDTO(){ }
    }
}
