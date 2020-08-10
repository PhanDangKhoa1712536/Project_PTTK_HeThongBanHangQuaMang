using System;

namespace DTO
{
    public class BangThongKeGopYDTO
    {
        public int maBangThongKe { get; set; }
        public int maNVLap { get; set; }
        public DateTime ngayLap { get; set; }
        public BangThongKeGopYDTO(int maBangThongKe, int maNVLap, DateTime ngayLap)
        {
            this.maBangThongKe = maBangThongKe;
            this.maNVLap = maNVLap;
            this.ngayLap = ngayLap;
        }
    }
}
