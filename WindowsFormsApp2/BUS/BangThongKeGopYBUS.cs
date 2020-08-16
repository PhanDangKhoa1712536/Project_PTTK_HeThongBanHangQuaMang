using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class BangThongKeGopYBUS
    {
        public BangThongKeGopYDAO bangThongKeGopYDAO;

        public BangThongKeGopYBUS()
        {
            this.bangThongKeGopYDAO = new BangThongKeGopYDAO();
        }

        public int insert(int mabangthongke, int maNV, DateTime date)
        {
            BangThongKeGopYDTO bangThongKeGopYDTO = new BangThongKeGopYDTO
            {
                maBangThongKe = mabangthongke,
                maNVLap = maNV,
                ngayLap = date
            };
            return bangThongKeGopYDAO.InsertBANGTHONGKE(bangThongKeGopYDTO);
        }

        public List<int> getMaBangTK()
        {
            return this.bangThongKeGopYDAO.getBangThongKe();
        }
    }
}
