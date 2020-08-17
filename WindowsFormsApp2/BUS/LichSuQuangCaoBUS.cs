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

        public void CapNhatLichSu(int MaKH, int MaMH)
        {
            lichSu.ThemLichSu(MaKH, MaMH);
        }
    }
}
