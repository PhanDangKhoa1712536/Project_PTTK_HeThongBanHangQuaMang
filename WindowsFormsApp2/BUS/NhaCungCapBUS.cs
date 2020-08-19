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

        public List<NhaCungCapDTO> LayDanhSachNCC()
        {
            return nhaCungCapDAO.getAll();
        }
        public List<NhaCungCapDTO> TimBangTuKhoa(string keyword)
        {
            return nhaCungCapDAO.getByKeyword(keyword);
        }

        public string TimTenTheoMaDonNhap(string idDonNhap)
        {
            return nhaCungCapDAO.getTenNCCbyIDDonNhap(idDonNhap);
        }
    }
}
