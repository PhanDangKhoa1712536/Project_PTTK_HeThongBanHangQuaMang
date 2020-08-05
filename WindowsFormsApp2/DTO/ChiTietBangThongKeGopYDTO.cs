using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietBangThongKeGopYDTO
    {
        public int maChiTietBTK { get; set; }
        public int maBangThongKe { get; set; }
        public int maGopY { get; set; }
        public ChiTietBangThongKeGopYDTO(int maChiTietBTK, int maBangThongKe, int maGopY)
        {
            this.maChiTietBTK = maChiTietBTK;
            this.maBangThongKe = maBangThongKe;
            this.maGopY = maGopY;
        }
    }
}
