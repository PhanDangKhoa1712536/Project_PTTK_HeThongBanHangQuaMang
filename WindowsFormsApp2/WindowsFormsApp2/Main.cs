using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace Presentation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load_DSNhaCungCap();
        }
        private void Load_DSNhaCungCap()
        {
            NhaCungCapBUS nhaCungCapBUS = new NhaCungCapBUS();
            List<NhaCungCapDTO> allNCC = nhaCungCapBUS.getAll();
            /*format column size*/
            grv_NhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grv_NhaCungCap.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            
            grv_NhaCungCap.Rows.Clear();
            for (int i = 0; i < allNCC.Count; i++)
            {
                this.grv_NhaCungCap.Rows.Add(
                    allNCC[i].maNCC,
                    allNCC[i].tenNCC);
            }
            this.grv_NhaCungCap.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HienThiDanhSachHopDong();
        }

        private void HienThiDanhSachHopDong()
        {
            HopDongBUS hopdongBUS = new HopDongBUS();
            List<DoiTacQuangCaoDTO> allDTQC = hopdongBUS.docHopDong();
            
            // grd_DSHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // grd_DSHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            grd_DSHD.Rows.Clear();
            for (int i = 0; i < allDTQC.Count; i++)
            {
                this.grd_DSHD.Rows.Add(
                    allDTQC[i].maDoiTac,
                    allDTQC[i].maHang,
                    allDTQC[i].tenDoiTac,
                    allDTQC[i].ngayKyHopDong,
                    allDTQC[i].ngayHetHan,
                    allDTQC[i].thongTinViTriDang,
                    allDTQC[i].noiDung);
            }
            this.grd_DSHD.ClearSelection();
        }
    }
}
