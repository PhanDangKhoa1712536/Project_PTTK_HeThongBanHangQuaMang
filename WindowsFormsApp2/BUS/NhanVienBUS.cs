using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    class NhanVienBUS
    {
        NhanVienDAO nhanVienDAO;
        NhanVienBUS()
        {
            this.nhanVienDAO = new NhanVienDAO();
        }

        List<NhanVienDTO> getAll()
        {
            return nhanVienDAO.getAll();
        }
    }
}
