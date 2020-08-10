using System;

namespace DTO
{
    public class DoiTacQuangCaoDTO
    {
        public int maDoiTac { get; set; }
        public string tenDoiTac { get; set; }
        public DateTime ngayKyHopDong { get; set; }
        public DateTime ngayHetHan { get; set; }
        public string thongTinViTriDang { get; set; }
        public string noiDung { get; set; }
        public DoiTacQuangCaoDTO(int maDoiTac, string tenDoiTac,
            DateTime ngayKyHopDong, DateTime ngayHetHan, string thongTinViTriDang,
            string noiDung)
        {
            this.maDoiTac = maDoiTac;
            this.tenDoiTac = tenDoiTac;
            this.ngayKyHopDong = ngayKyHopDong;
            this.ngayHetHan = ngayHetHan;
            this.thongTinViTriDang = thongTinViTriDang;
            this.noiDung = noiDung;
        }
    }
}
