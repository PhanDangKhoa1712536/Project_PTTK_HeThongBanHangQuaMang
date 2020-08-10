using BUS;
using DTO;
using Presentation;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        NhanVienBUS nhanVienBUS;
        NhanVienDTO nhanVienDTO;
        private MainForm frmMain;
        public Login(MainForm frmMain)
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            this.frmMain = frmMain;
            nhanVienBUS = new NhanVienBUS();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPassword.Text;
            nhanVienDTO = nhanVienBUS.checkLogin(user, password);
            if (nhanVienDTO == null)
            {
                MessageBox.Show("Thông tin đăng nhập sai.");
            }
            else
            {
                frmMain.login_stats = true;
                frmMain.btnLogOut.Text = "Logged in as " + nhanVienDTO.tenNhanVien;
                frmMain.MaNV_login = nhanVienDTO.maNV;
                frmMain.btnLogOut.Show();
                frmMain.txtNhanVienNhapHang.Text = nhanVienDTO.maNV + ", " + nhanVienDTO.tenNhanVien;
                frmMain.btnDangNhap.Hide();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
