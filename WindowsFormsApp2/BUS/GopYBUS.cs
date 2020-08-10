using DAO;
using DTO;
using System.Collections.Generic;

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
