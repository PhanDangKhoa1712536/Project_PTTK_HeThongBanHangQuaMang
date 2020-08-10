using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAO nhanVienDAO;
        public NhanVienBUS()
        {
            this.nhanVienDAO = new NhanVienDAO();
        }

        List<NhanVienDTO> getAll()
        {
            return nhanVienDAO.getAll();
        }

        public NhanVienDTO checkLogin(string user, string pass)
        {
            return nhanVienDAO.getByUserPassword(user, pass);
        }
        public List<int> LoadNVGH()
        {
            return nhanVienDAO.DocMaNVGiaoHang();
        }
    }
}
