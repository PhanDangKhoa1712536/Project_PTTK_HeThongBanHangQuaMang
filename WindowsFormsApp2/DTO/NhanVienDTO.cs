using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int maNhanVien { get; set; }
        public int loaiNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }
        NhanVienDTO(int maNhanVien, int loaiNhanVien, string tenNhanVien, string tenDangNhap, string matKhau)
        {
            this.maNhanVien = maNhanVien;
            this.loaiNhanVien = loaiNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.tenNhanVien = tenNhanVien;
            this.matKhau = matKhau;
        }
    }
}
