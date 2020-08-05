using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangDTO
    {
        public int maHang { get; set; }
        public int maNhanVienQuanLy { get; set; }
        public string tenHang { get; set; }
        public int soLuongConLai { get; set; }
        public float donGia { get; set; }
        HangDTO(int maHang, int maNhanVienQuanLy, string tenHang, 
            int soLuongConLai, float donGia)
        {
            this.maHang = maHang;
            this.maNhanVienQuanLy = maNhanVienQuanLy;
            this.tenHang = tenHang;
            this.soLuongConLai = soLuongConLai;
            this.donGia = donGia;
        }
    }
}
