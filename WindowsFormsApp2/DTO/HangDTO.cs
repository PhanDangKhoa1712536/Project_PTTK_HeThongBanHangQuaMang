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
        public int maNVPhuTrach { get; set; }
        public string tenHang { get; set; }
        public int soLuongConLai { get; set; }
        public double donGia { get; set; }
        public HangDTO(int maHang, int maNVPhuTrach, string tenHang, 
            int soLuongConLai, double donGia)
        {
            this.maHang = maHang;
            this.maNVPhuTrach = maNVPhuTrach;
            this.tenHang = tenHang;
            this.soLuongConLai = soLuongConLai;
            this.donGia = donGia;
        }
    }
}
