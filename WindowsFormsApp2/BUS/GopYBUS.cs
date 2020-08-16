using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class GopYBUS
    {
        private readonly GopYDAO gopYDAO;

        public GopYBUS()
        {
            gopYDAO = new GopYDAO();
        }

        public List<GopYDTO> getAll()
        {
            return gopYDAO.getAll();
        }

        public List<GopYDTO> getByDate(DateTime fromDate, DateTime toDate)
        {
            return this.gopYDAO.getByDate(fromDate, toDate);
        }

        public Boolean Update(GopYDTO gopY)
        {
            return this.gopYDAO.Update(gopY);
        }

        public Boolean Update(int maGopY, bool flagXau)
        {
            GopYDTO gopYDTO = new GopYDTO(maGopY, flagXau);
            return this.gopYDAO.Update(gopYDTO);
        }

        public List<GopYDTO> getAllCommentXauByBangThongKe(int maBangThongKe)
        {
            return this.gopYDAO.getAllCommentXauByBangThongKe(maBangThongKe);
        }

        public List<GopYDTO> getAllCommentTotByBangThongKe(int maBangThongKe)
        {
            return this.gopYDAO.getAllCommentTotByBangThongKe(maBangThongKe);
        }


        public Boolean UpdateTangQua(GopYDTO gopY)
        {
            return this.gopYDAO.Update(gopY);
        }

        public Boolean UpdateTangQua(int maGopY)
        {
            GopYDTO gopYDTO = new GopYDTO
            {
                maGopY = maGopY
            };
            return this.gopYDAO.UpdateTangQua(gopYDTO);
        }

        public Boolean UpdateXacNhanXoaGopY(int maGopY)
        {
            GopYDTO gopYDTO = new GopYDTO
            {
                maGopY = maGopY
            };
            return this.gopYDAO.UpdateXacNhanXoaGopY(gopYDTO);
        }

        public Boolean DeleteComment(int maGopY)
        {
            GopYDTO gopYDTO = new GopYDTO
            {
                maGopY = maGopY
            };
            return this.gopYDAO.DeleteComment(gopYDTO);
        }
    }
}
