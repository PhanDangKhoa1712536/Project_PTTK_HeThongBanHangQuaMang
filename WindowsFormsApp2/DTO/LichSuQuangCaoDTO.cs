namespace DTO
{
    public class LichSuQuangCaoDTO
    {
        public int maLSQC { get; set; }
        public int maKH { get; set; }
        public int maHang { get; set; }
        public LichSuQuangCaoDTO(int maLSQC, int maKH, int maHang)
        {
            this.maLSQC = maLSQC;
            this.maKH = maKH;
            this.maHang = maHang;
        }
    }
}