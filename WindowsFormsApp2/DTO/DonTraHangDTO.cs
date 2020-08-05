using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonTraHangDTO
    {
        public int maDonTra { get; set; }
        public int maNhanVien { get; set; }
        public int maNhaCungCap { get; set; }
        public DateTime ngayLap { get; set; }
        DonTraHangDTO(int maDonTra, int maNhanVien, int maNhaCungCap, DateTime ngayLap)
        {
            this.maDonTra = maDonTra;
            this.maNhanVien = maNhanVien;
            this.maNhaCungCap = maNhaCungCap;
            this.ngayLap = ngayLap;
        }
    }
}
