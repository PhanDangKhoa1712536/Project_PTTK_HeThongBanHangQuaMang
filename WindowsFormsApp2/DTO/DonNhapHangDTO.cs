using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonNhapHangDTO
    {
        public int maDonNhap { get; set; }
        public int maNhanVien { get; set; }
        public int maNhaCungCap { get; set; }
        public int tongLuongHang { get; set; }
        public string lyDoNhap { get; set; }
        public DateTime ngayNhap { get; set; }
        public bool trangThaiXacNhan { get; set; }
        public DonNhapHangDTO(int maDonNhap, int maNhanVien, int maNhaCungCap,
            int tongLuongHang, string lyDoNhap, DateTime ngayNhap, bool trangThaiXacNhan)
        {
            this.maDonNhap = maDonNhap;
            this.maNhanVien = maNhanVien;
            this.maNhaCungCap = maNhaCungCap;
            this.tongLuongHang = tongLuongHang;
            this.lyDoNhap = lyDoNhap;
            this.ngayNhap = ngayNhap;
            this.trangThaiXacNhan = trangThaiXacNhan;
        }
    }
}
