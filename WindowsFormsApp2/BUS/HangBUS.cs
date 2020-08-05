using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HangBUS
    {
        HangDAO hangDAO;
        public HangBUS()
        {
            hangDAO = new HangDAO();
        }

        public List<HangDTO> getAll()
        {
            return hangDAO.getAll();
        }
    }
}
