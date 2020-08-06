using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHangLoiDTO
    {
        public int maChiTietHangLoi { get; set; }
        public int maHoaDon { get; set; }
        public int maHangLoi { get; set; }
        public ChiTietHangLoiDTO(int maChiTietHangLoi, int maHoaDon, int maHangLoi)
        {
            this.maChiTietHangLoi = maChiTietHangLoi;
            this.maHoaDon = maHoaDon;
            this.maHangLoi = maHangLoi;
        }
    }
}
