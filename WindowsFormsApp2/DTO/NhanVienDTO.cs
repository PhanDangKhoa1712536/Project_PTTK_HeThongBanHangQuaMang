using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int maNV { get; set; }
        public int loaiNV { get; set; }
        public string tenNhanVien { get; set; }
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }
        public NhanVienDTO(int maNV, int loaiNV, string tenNhanVien, string tenDangNhap, string matKhau)
        {
            this.maNV = maNV;
            this.loaiNV = loaiNV;
            this.tenNhanVien = tenNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }
    }
}
