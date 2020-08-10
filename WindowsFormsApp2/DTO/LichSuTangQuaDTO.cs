using System;

namespace DTO
{
    public class LichSuTangQuaDTO
    {
        public int maLichSu { get; set; }
        public int maKH { get; set; }
        public int soLuongGopYTot { get; set; }
        public DateTime ngayTang { get; set; }
        public string trangThaiTang { get; set; }
        public LichSuTangQuaDTO(int maLichSu, int maKH, int soLuongGopYTot,
            DateTime ngayTang, string trangThaiTang)
        {
            this.maLichSu = maLichSu;
            this.maKH = maKH;
            this.soLuongGopYTot = soLuongGopYTot;
            this.ngayTang = ngayTang;
            this.trangThaiTang = trangThaiTang;
        }
    }
}
