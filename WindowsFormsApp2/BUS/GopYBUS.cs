using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class GopYBUS
    {
        GopYDAO gopYDAO;

        public GopYBUS()
        {
            gopYDAO = new GopYDAO();
        }

        public List<GopYDTO> getAll()
        {
            return gopYDAO.getAll();
        }
    }
}
