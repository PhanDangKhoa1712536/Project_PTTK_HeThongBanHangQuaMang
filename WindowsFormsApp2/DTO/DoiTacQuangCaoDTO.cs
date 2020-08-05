﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DoiTacQuangCaoDTO
    {
        public int maDoiTac { get; set; }
        public int maHang { get; set; }
        public string tenDoiTac { get; set; }
        public DateTime ngayKyHopDong { get; set; }
        public DateTime ngayHetHan { get; set; }
        public string thongTinViTriDang { get; set; }
        public string noiDung { get; set; }
        public DoiTacQuangCaoDTO(int maDoiTac, int maHang, string tenDoiTac, 
            DateTime ngayKyHopDong, DateTime ngayHetHan, string thongTinViTriDang,
            string noiDung)
        {
            this.maDoiTac = maDoiTac;
            this.maHang = maHang;
            this.tenDoiTac = tenDoiTac;
            this.ngayKyHopDong = ngayKyHopDong;
            this.ngayHetHan = ngayHetHan;
            this.thongTinViTriDang = thongTinViTriDang;
            this.noiDung = noiDung;
        }
    }
}
