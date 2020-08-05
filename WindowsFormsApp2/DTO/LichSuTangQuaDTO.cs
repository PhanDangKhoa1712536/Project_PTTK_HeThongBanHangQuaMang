using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LichSuTangQuaDTO
    {
        public int maLichSu { get; set; }
        public int maKhachHang { get; set; }
        public int soLuongGopYTot { get; set; }
        public DateTime ngayTang { get; set; }
        public string trangThaiTang { get; set; }
        LichSuTangQuaDTO(int maLichSu, int maKhachHang, int soLuongGopYTot,
            DateTime ngayTang, string trangThaiTang)
        {
            this.maLichSu = maLichSu;
            this.maKhachHang = maKhachHang;
            this.soLuongGopYTot = soLuongGopYTot;
            this.ngayTang = ngayTang;
            this.trangThaiTang = trangThaiTang;
        }
    }
}
