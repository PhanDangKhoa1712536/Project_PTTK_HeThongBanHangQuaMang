using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HopDongBUS
    {
        HopDongDAO hopdongDAO;
        public HopDongBUS()
        {
            hopdongDAO = new HopDongDAO();
        }

        public List<DoiTacQuangCaoDTO> docHopDong()
        {
            return hopdongDAO.docHopDong();
        }
    }
}
