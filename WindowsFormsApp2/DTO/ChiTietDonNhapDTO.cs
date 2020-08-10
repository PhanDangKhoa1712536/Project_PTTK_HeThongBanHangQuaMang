namespace DTO
{
    public class ChiTietDonNhapDTO
    {
        public int maChiTietDonNhap { get; set; }
        public int maDonNhap { get; set; }
        public int maHang { get; set; }
        public int soLuongNhap { get; set; }
        public ChiTietDonNhapDTO(int maChiTietDonNhap, int maDonNhap, int maHang, int soLuongNhap)
        {
            this.maChiTietDonNhap = maChiTietDonNhap;
            this.maDonNhap = maDonNhap;
            this.maHang = maHang;
            this.soLuongNhap = soLuongNhap;
        }

        public ChiTietDonNhapDTO()
        {
        }
    }
}
