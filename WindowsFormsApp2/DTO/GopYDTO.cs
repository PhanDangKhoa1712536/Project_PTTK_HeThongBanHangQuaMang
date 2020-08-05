using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GopYDTO
    {
        public int maGopY { get; set; }
        public int maHang { get; set; }
        public int maKhachHang { get; set; }
        public string noiDung { get; set; }
        public DateTime ngayGopY { get; set; }
        public bool flagXau { get; set; }
        public DateTime ngayChinhSuaRecord { get; set; }
        GopYDTO(int maGopY, int maHang, int maKhachHang, string noiDung, DateTime ngayGopY,
            bool flagXau, DateTime ngayChinhSuaRecord)
        {
            this.maGopY = maGopY;
            this.maHang = maHang;
            this.maKhachHang = maKhachHang;
            this.noiDung = noiDung;
            this.ngayGopY = ngayGopY;
            this.flagXau = flagXau;
            this.ngayChinhSuaRecord = ngayChinhSuaRecord;
        }
    }
}
