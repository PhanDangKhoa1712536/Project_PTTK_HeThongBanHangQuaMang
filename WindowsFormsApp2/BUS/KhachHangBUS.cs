using DAO;
using DTO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//using DAO;
//using DTO;

namespace BUS
{
    public class KhachHangBUS
    {
        public KhachHangDAO khachHangDAO;

        public KhachHangBUS()
        {
            khachHangDAO = new KhachHangDAO();
        }
        public KhachHangDTO KhoiTao(string HoTen, string Email, string DiaChi)
        {
            KhachHangDTO KH = new KhachHangDTO(0, HoTen, Email, DiaChi, false);
            return KH;
        }

        public int CreateMaKH()
        {
            return khachHangDAO.DocMaKHMoiNhat() + 1;
        }

        public bool KiemTraThongTinKH(string HoTen, string DiaChi, string Email)
        {
            // Kiem tra xem trong string HoTen co so khong hoac ki tu dac biet khong
            //string hoten_pattern = "^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s\\W|_]+$";
            //string diachi_pattern = "[0-9a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s\\W|_]+$";
            //string email_pattern = "^[a-z][a-z0-9_\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$";
            //if (!Regex.IsMatch(HoTen, hoten_pattern)) {
            //    return false;
            //}
            //if (!Regex.IsMatch(Email, email_pattern))
            //{
            //    return false;
            //}
            //if (!Regex.IsMatch(DiaChi, diachi_pattern))
            //{
            //    return false;
            //}
            //return true;

            if (HoTen != "" && DiaChi != "" && Email != "")
            {
                return true;
            }
            else return false;
        }

    public void ThemKhachHang_bus(KhachHangDTO KH)
        {
            khachHangDAO.ThemKhachHang_DAL(KH);
        }

        // Search khách hàng theo hoten, diachi, email
        public int SearchKH(string HoTen, string Email)
        {
            List<int> searched_result = new List<int>();
                searched_result = khachHangDAO.TimKhachHang(HoTen, Email);
                // Kiem tra xem ket qua tra ve co bao nhieu ket qua
                if (searched_result.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return searched_result[0];
                }
        }

        // Search khachHang theo MaKH
        public KhachHangDTO TimKhachHangTheoMaKH(int MaKH)
        {
            return khachHangDAO.TimKhachHang_MaKH(MaKH);
        }

       

        public KhachHangDTO SearchKH_Name(string Hoten)
        {
            return khachHangDAO.TimKH_TraHang(Hoten);
        }


        public List<KhachHangDTO> LayDSKHQuangCao(int MaMH, Stack<string> DSXoa)
        {
            string strXoa = "";

            if (DSXoa.Count != 0)
            {
                strXoa = "AND MAKH NOT IN (";
                Stack<string> clone = new Stack<string>(DSXoa);

                while (clone.Count > 1)
                {
                    strXoa += clone.Pop() + ",";
                }
                strXoa += clone.Pop() + ")";
            }

            return khachHangDAO.DocKHQuangCao(MaMH, strXoa);
        }
    }
}
