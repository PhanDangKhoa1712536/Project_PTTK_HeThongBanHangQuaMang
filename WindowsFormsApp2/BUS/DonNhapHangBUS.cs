using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class DonNhapHangBUS
    {
        DonNhapHangDAO donNhapHangDAO = new DonNhapHangDAO();
        public List<DonNhapHangDTO> getAll()
        {
            return donNhapHangDAO.getAll();
        }
    }
}
