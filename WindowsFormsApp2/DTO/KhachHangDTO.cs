using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public int maKhachHang { get; set; }
        public string tenKhachHang { get; set; }
        public string emailKhachHang { get; set; }
        public string diaChiKhachHang { get; set; }
        public bool trangThaiKhoaComment { get; set; }
        KhachHangDTO(int maKhachHang, string tenKhachHang, string emailKhachHang,
            string diaChiKhachHang, bool trangThaiKhoaComment)
        {
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.emailKhachHang = emailKhachHang;
            this.diaChiKhachHang = diaChiKhachHang;
            this.trangThaiKhoaComment = trangThaiKhoaComment;
    
        }
    }
}
