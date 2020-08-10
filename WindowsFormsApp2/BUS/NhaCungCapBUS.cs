using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{

    public class NhaCungCapBUS
    {
        NhaCungCapDAO nhaCungCapDAO;
        public NhaCungCapBUS()
        {
            nhaCungCapDAO = new NhaCungCapDAO();
        }

        public List<NhaCungCapDTO> getAll()
        {
            return nhaCungCapDAO.getAll();
        }
    }
}
