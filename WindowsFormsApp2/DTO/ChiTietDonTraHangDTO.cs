namespace DTO
{
    public class ChiTietDonTraHangDTO
    {
        public int maChiTietDonTra { get; set; }
        public int maDonTra { get; set; }
        public int maHangLoi { get; set; }
        public int soLuongTra { get; set; }
        public string lyDo { get; set; }
        public ChiTietDonTraHangDTO(int maChiTietDonTra, int maDonTra, int maHangLoi,
            int soLuongTra, string lyDo)
        {
            this.maChiTietDonTra = maChiTietDonTra;
            this.maDonTra = maDonTra;
            this.maHangLoi = maHangLoi;
            this.soLuongTra = soLuongTra;
            this.lyDo = lyDo;
        }
    }
}
