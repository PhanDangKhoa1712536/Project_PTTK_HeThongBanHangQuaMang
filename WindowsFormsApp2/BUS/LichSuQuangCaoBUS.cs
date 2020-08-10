using DAO;

namespace BUS
{
    public class LichSuQuangCaoBUS
    {
        LichSuQuangCaoDAO lichSu;
        public LichSuQuangCaoBUS()
        {
            lichSu = new LichSuQuangCaoDAO();
        }

        public void CapNhatLichSu(int MaLS, int MaKH, int MaMH)
        {
            lichSu.ThemLichSu(MaLS, MaKH, MaMH);
        }

        public int LayMaLichSu()
        {
            return lichSu.LayMaLichSu();
        }
    }
}
