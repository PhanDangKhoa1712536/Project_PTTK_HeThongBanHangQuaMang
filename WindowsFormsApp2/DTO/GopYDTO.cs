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
        public int maKH { get; set; }
        public string tenHang { get; set; }
        public string noiDung { get; set; }
        public DateTime ngayGopY { get; set; }
        public bool flagXau { get; set; }
        public DateTime ngayChinhSuaRecord { get; set; }
        public int flagTangQua { get; set; }
        public int flagXacNhanXoa { get; set; }



        public GopYDTO(int maGopY, int maHang, int maKH, string noiDung, DateTime ngayGopY,
            bool flagXau, DateTime ngayChinhSuaRecord, string tenHang)
        {
            this.maGopY = maGopY;
            this.maHang = maHang;
            this.maKH = maKH;
            this.noiDung = noiDung;
            this.ngayGopY = ngayGopY;
            this.flagXau = flagXau;
            this.ngayChinhSuaRecord = ngayChinhSuaRecord;
            this.tenHang = tenHang;
        }

        public GopYDTO(int maGopY, int maHang, int maKH, string noiDung, DateTime ngayGopY)
        {
            this.maGopY = maGopY;
            this.maHang = maHang;
            this.maKH = maKH;
            this.noiDung = noiDung;
            this.ngayGopY = ngayGopY;
        }

        public GopYDTO() { }


        public GopYDTO(int maGopY, bool flagXau)
        {
            this.maGopY = maGopY;
            this.flagXau = flagXau;
        }
    }
}
