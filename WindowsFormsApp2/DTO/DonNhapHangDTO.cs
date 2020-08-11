using System;

namespace DTO
{
    public class DonNhapHangDTO
    {
        public int maDonNhap { get; set; }
        public int maNV { get; set; }
        public string tenNVLap { get; set; }
        public int maNCC { get; set; }
        public int tongLuongHang { get; set; }
        public string lyDoNhap { get; set; }
        public DateTime ngayNhap { get; set; }
        public bool trangThaiXacNhan { get; set; }
        public DonNhapHangDTO(int maDonNhap, int maNV, string tenNVLap, int maNCC,
            int tongLuongHang, string lyDoNhap, DateTime ngayNhap, bool trangThaiXacNhan)
        {
            this.maDonNhap = maDonNhap;
            this.maNV = maNV;
            this.tenNVLap = tenNVLap;
            this.maNCC = maNCC;
            this.tongLuongHang = tongLuongHang;
            this.lyDoNhap = lyDoNhap;
            this.ngayNhap = ngayNhap;
            this.trangThaiXacNhan = trangThaiXacNhan;
        }

        public DonNhapHangDTO()
        {
        }
    }
}
