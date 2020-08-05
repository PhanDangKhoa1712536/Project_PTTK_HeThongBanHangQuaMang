using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietBangThongKeGopYDTO
    {
        public int maChiTietBangThongKe { get; set; }
        public int maBangThongKe { get; set; }
        public int maGopY { get; set; }
        ChiTietBangThongKeGopYDTO(int maChiTietBangThongKe, int maBangThongKe, int maGopY)
        {
            this.maChiTietBangThongKe = maChiTietBangThongKe;
            this.maBangThongKe = maBangThongKe;
            this.maGopY = maGopY;
        }
    }
}
