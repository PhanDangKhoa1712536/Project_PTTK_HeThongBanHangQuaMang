using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        public int maNhaCungCap { get; set; }
        public string tenNhaCungCap { get; set; }

        public NhaCungCapDTO(int maNhaCungCap, string tenNhaCungCap)
        {
            this.maNhaCungCap = maNhaCungCap;
            this.tenNhaCungCap = tenNhaCungCap;
        }
    }
}
