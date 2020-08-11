using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class HangBUS
    {
        HangDAO hangDAO;
        public HangBUS()
        {
            hangDAO = new HangDAO();
        }

        public List<HangDTO> TimKiem(string keyword)
        {
            return hangDAO.DocMatHang(keyword);
        }

        public DataTable lapBangThongKe(DateTime d1, DateTime d2)
        {
            return hangDAO.Utility_getSaleBetween(d1, d2);
        }
    }
}
