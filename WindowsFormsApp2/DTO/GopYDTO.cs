using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GopYDTO
    {
        public int MaGopY { get; set; }
        public int MaHang { get; set; }
        public int MaKH { get; set; }
        public string TenHang { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayGopY { get; set; }
        public bool DanhDauCommentXau { get; set; }
        public DateTime NgayChinhSuaRecord { get; set; }
        public bool GhiNhanTangQua { get; set; }
        public bool GhiNhanXoa { get; set; }



        public GopYDTO(int maGopY, int maHang, int maKH, string noiDung, DateTime ngayGopY,
            bool flagXau, DateTime ngayChinhSuaRecord, string tenHang, bool flagTangQua, bool flagXacNhanXoa)
        {
            this.MaGopY = maGopY;
            this.MaHang = maHang;
            this.MaKH = maKH;
            this.NoiDung = noiDung;
            this.NgayGopY = ngayGopY;
            this.DanhDauCommentXau = flagXau;
            this.NgayChinhSuaRecord = ngayChinhSuaRecord;
            this.TenHang = tenHang;
            this.GhiNhanTangQua = flagTangQua;
            this.GhiNhanXoa = flagXacNhanXoa;
        }

        public GopYDTO(int maGopY, int maHang, int maKH, string noiDung, DateTime ngayGopY)
        {
            this.MaGopY = maGopY;
            this.MaHang = maHang;
            this.MaKH = maKH;
            this.NoiDung = noiDung;
            this.NgayGopY = ngayGopY;
        }

        public GopYDTO() { }


        public GopYDTO(int maGopY, bool flagXau)
        {
            this.MaGopY = maGopY;
            this.DanhDauCommentXau = flagXau;
        }
    }
}
