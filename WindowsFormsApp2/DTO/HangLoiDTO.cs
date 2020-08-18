namespace DTO
{
    public class HangLoiDTO
    {
        public int maHangLoi { get; set; }
        public int soLuong { get; set; }
        public HangLoiDTO(int maHangLoi, int soLuong)
        {
            this.maHangLoi = maHangLoi;
            this.soLuong = soLuong;
        }
        public HangLoiDTO()
        {

        }
    }

}
