using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS
{
    public class HangBUS
    {
        private readonly HangDAO hangDAO;
        public HangBUS()
        {
            hangDAO = new HangDAO();
        }

        public List<HangDTO> TimKiem(string keyword)
        {
            if (keyword != "")
            {
                bool isNumeric = int.TryParse(keyword, out _);

                if (isNumeric)
                {
                    keyword = " WHERE MAHANG = " + keyword;
                }
                else
                {
                    keyword = " WHERE TENHANG = '" + keyword + "'";
                }
            }

            return hangDAO.DocMatHang(keyword);
        }

        public List<HangDTO> lapBangThongKeHangBan(DateTime d1, DateTime d2)
        {
            return hangDAO.getSaleInRange(d1, d2);
        }
    }
}
