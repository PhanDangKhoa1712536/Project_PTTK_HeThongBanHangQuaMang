using System;

namespace DTO
{
    public class DonTraHangDTO
    {
        public int maDonTra { get; set; }
        public int maNVLap { get; set; }
        public int maNCC { get; set; }
        public DateTime ngayLap { get; set; }
        public DonTraHangDTO(int maDonTra, int maNVLap, int maNCC, DateTime ngayLap)
        {
            this.maDonTra = maDonTra;
            this.maNVLap = maNVLap;
            this.maNCC = maNCC;
            this.ngayLap = ngayLap;
        }
        public DonTraHangDTO()
        {

        }
    }
}
