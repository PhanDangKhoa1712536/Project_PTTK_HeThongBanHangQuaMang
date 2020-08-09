using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        public int maChiTietHoaDon { get; set; }
        public int maHang { get; set; }
        public int maHoaDon { get; set; }
        public int soLuong { get; set; }
        public ChiTietHoaDonDTO(int maChiTietHoaDon, int maHang, int maHoaDon, int soLuong)
        {
            this.maChiTietHoaDon = maChiTietHoaDon;
            this.maHang = maHang;
            this.maHoaDon = maHoaDon;
            this.soLuong = soLuong;
        }
    }
}
