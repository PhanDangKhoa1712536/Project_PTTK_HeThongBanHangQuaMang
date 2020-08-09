using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int maKH { get; set; }
        public string tenKH { get; set; }
        public string emailKH { get; set; }
        public string diaChiKH { get; set; }
        public bool trangThaiKhoaComment { get; set; }
        public KhachHangDTO(int maKH, string tenKH, string emailKH,
            string diaChiKH, bool trangThaiKhoaComment)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.emailKH = emailKH;
            this.diaChiKH = diaChiKH;
            this.trangThaiKhoaComment = trangThaiKhoaComment;
    
        }
        public KhachHangDTO() { }

        public KhachHangDTO(int maKH, string tenKH)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
        }
    }
}
