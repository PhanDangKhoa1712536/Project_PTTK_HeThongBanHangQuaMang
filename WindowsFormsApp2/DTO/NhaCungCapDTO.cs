using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        public int maNCC { get; set; }
        public string tenNCC { get; set; }

        public NhaCungCapDTO(int maNCC, string tenNCC)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
        }
    }
}
