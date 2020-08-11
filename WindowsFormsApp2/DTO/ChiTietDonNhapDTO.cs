namespace DTO
{
    public class ChiTietDonNhapDTO
    {
        public int maChiTietDonNhap { get; set; }
        public int maDonNhap { get; set; }
        public int maHang { get; set; }
        public string tenHang { get; set; }
        public int soLuongNhap { get; set; }
        public ChiTietDonNhapDTO(int maChiTietDonNhap, int maDonNhap, int maHang, string tenHang, int soLuongNhap)
        {
            this.maChiTietDonNhap = maChiTietDonNhap;
            this.maDonNhap = maDonNhap;
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.soLuongNhap = soLuongNhap;
        }

        public ChiTietDonNhapDTO()
        {
        }
    }
}
