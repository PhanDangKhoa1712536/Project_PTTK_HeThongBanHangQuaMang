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
        public int maNhanVienLap { get; set; }
        public DateTime ngayLap { get; set; }
        BangThongKeGopYDTO(int maBangThongKe, int maNhanVienLap, DateTime ngayLap)
        {
            this.maBangThongKe = maBangThongKe;
            this.maNhanVienLap = maNhanVienLap;
            this.ngayLap = ngayLap;
        }
    }
}
