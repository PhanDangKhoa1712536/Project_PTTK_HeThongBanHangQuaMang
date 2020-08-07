using DTO;
using DAO;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHangBUS
    {
        public KhachHangDAO khachHangDAO;

        public KhachHangBUS()
        {
            khachHangDAO = new KhachHangDAO();
        }
        public bool KiemTraThongTinKH(string HoTen, string DiaChi, string Email)
        {
            // Kiem tra xem trong string HoTen co so khong hoac ki tu dac biet khong
            string hoten_pattern = "^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s\\W|_]+$";
            string diachi_pattern = "[0-9a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s\\W|_]+$";
            string email_pattern = "^[a-z][a-z0-9_\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$";
            if (!Regex.IsMatch(HoTen, hoten_pattern)) {
                return false;
            }
            if (!Regex.IsMatch(Email, email_pattern))
            {
                return false;
            }
            if (!Regex.IsMatch(DiaChi, diachi_pattern))
            {
                return false;
            }
            return true;
        }

        public bool ThemKhachHang_bus(KhachHangDTO KH)
        {
            try
            {
                khachHangDAO.ThemKhachHang_DAL(KH);
            }
            catch (Exception er)
            {
                return false;
            }
            return true;
        }

        public int SearchKH(string HoTen, string Email, string DiaChi)
        {
            List<KhachHangDTO> searched_result = new List<KhachHangDTO>();
            try
            {
                searched_result = khachHangDAO.TimKhachHang(HoTen, DiaChi, Email);
                // Kiem tra xem ket qua tra ve co bao nhieu ket qua
                if (searched_result.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return searched_result[0].maKH;
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }

        public KhachHangDTO KhoiTao(string HoTen, string Email, string DiaChi)
        {
            KhachHangDTO KH = new KhachHangDTO()

        }

    }
}
