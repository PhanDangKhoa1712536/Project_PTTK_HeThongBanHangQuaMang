using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangLoiDTO
    {
        public int maHangLoi { get; set; }
        public int maHoaDon { get; set; }
        public string tenHang { get; set; }
        public int soLuong { get; set; }
        public HangLoiDTO(int maHangLoi, int maHoaDon, string tenHang, int soLuong)
        {
            this.maHangLoi = maHangLoi;
            this.maHoaDon = maHoaDon;
            this.tenHang = tenHang;
            this.soLuong = soLuong;
        }
    }
}
