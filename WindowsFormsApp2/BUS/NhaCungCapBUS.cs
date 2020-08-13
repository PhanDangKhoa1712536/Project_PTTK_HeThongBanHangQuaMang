using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{

    public class NhaCungCapBUS
    {
        private readonly NhaCungCapDAO nhaCungCapDAO;
        public NhaCungCapBUS()
        {
            nhaCungCapDAO = new NhaCungCapDAO();
        }

        public List<NhaCungCapDTO> getAll()
        {
            return nhaCungCapDAO.getAll();
        }
        public List<NhaCungCapDTO> timNCC(string keyword)
        {
            return nhaCungCapDAO.getByKeyword(keyword);
        }

    }
}
