using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using BUS;
using DTO;
using Presentation;

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
                frmMain.DangNhap_button.Text = "Logged in as " + nhanVienDTO.tenNhanVien;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
