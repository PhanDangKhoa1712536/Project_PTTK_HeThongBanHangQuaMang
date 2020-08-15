using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;


namespace BUS
{
    public class ChiTietBangThongKeGopYBUS
    {
        public ChiTietBangThongKeGopYDAO chiTietBangThongKeGopYDAO;

        public ChiTietBangThongKeGopYBUS()
        {
            chiTietBangThongKeGopYDAO = new ChiTietBangThongKeGopYDAO();
        }

        public Boolean Insert(int mabangthongke, int magopy)
        {
            ChiTietBangThongKeGopYDTO chiTietBangThongKeGopYDTO = new ChiTietBangThongKeGopYDTO(mabangthongke, magopy);

            return this.chiTietBangThongKeGopYDAO.Insert(chiTietBangThongKeGopYDTO);
        }
    }
}
