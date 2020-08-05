using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
