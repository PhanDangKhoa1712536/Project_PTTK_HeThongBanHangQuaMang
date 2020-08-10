using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace Presentation
{
    public partial class MainForm : Form
    {
        Stack<string> maKH_Xoa = new Stack<string>();
        Stack<string> maHang_Add = new Stack<string>();

        public bool login_stats;
        private TabPage tmpComment, tmpNhapHang, tmpQuangCao, tmpTraHang, tmpXuLyMua;

        public MainForm()
        {
            InitForm();
            Load_DSNhaCungCap();
            Load_DSDonNhap();
            Load_DSComment();
            HienDSMatHang();
        }

        private void InitForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();

            tmpComment = tbComment;
            tmpNhapHang = tbNhapHang;
            tmpQuangCao = tbQuangCao;
            tmpTraHang = tbTraHang;
            tmpXuLyMua = tbXuLyMua;

            this.tabControl1.TabPages.Remove(this.tbComment);
            this.tabControl1.TabPages.Remove(this.tbNhapHang);
            this.tabControl1.TabPages.Remove(this.tbQuangCao);
            this.tabControl1.TabPages.Remove(this.tbTraHang);
            this.tabControl1.TabPages.Remove(this.tbXuLyMua);


            this.login_stats = false;
        }

        private void LoginCallback()
        {
            this.tabControl1.TabPages.Add(this.tmpNhapHang);
            this.tabControl1.TabPages.Add(this.tmpTraHang);
            this.tabControl1.TabPages.Add(this.tmpComment);
            this.tabControl1.TabPages.Add(this.tmpQuangCao);
            this.tabControl1.TabPages.Add(this.tmpXuLyMua);

        }


        private void Load_DSComment()
        {
            GopYBUS gopYBUS = new GopYBUS();

            List<GopYDTO> allGopY = gopYBUS.getAll();
            grvAllComments.DataSource = allGopY;
            //grvAllComments.Rows.Clear();
            //for (int i = 0; i < allGopY.Count; i++)
            //{
            //    this.grvAllComments.Rows.Add(
            //        allGopY[i].maGopY,
            //        allGopY[i].maHang,
            //        allGopY[i].maKH,
            //        allGopY[i].noiDung,
            //        allGopY[i].ngayGopY,
            //        allGopY[i].ngayChinhSuaRecord);
            //}
            //this.grvAllComments.ClearSelection();
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

        private void btnCloseMain_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void tnMinimizeMain_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Load_DSDonNhap()
        {
            DonNhapHangBUS donNhapHangBUS = new DonNhapHangBUS();
            List<DonNhapHangDTO> allDonNhapHang = donNhapHangBUS.getAll();
            /*format column size*/
            grv_DonNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grv_DonNhapHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            grv_DonNhapHang.Rows.Clear();
            for (int i = 0; i < allDonNhapHang.Count; i++)
            {
                this.grv_DonNhapHang.Rows.Add(
                    allDonNhapHang[i].maDonNhap,
                    allDonNhapHang[i].maNV,
                    allDonNhapHang[i].maNCC,
                    allDonNhapHang[i].tongLuongHang,
                    allDonNhapHang[i].lyDoNhap,
                    allDonNhapHang[i].ngayNhap,
                    allDonNhapHang[i].trangThaiXacNhan
                    );
            }
            this.grv_DonNhapHang.ClearSelection();
        }


        private void LoadKH()
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            InitForm();
        }

        private void btnXoaHopDong_Click(object sender, EventArgs e)
        {
            HopDongBUS hopdongBUS = new HopDongBUS();
            if (txtMaHD.Text != "")
            {
                int MaHD = Int32.Parse(txtMaHD.Text);
                hopdongBUS.huyHopDong(MaHD);
                HienThiDanhSachHopDong();

                txtMaHD.Clear();
                txtDoiTac.Clear();
                dtNgayKy.ResetText();
                dtNgayHetHan.ResetText();
                txtTTVT.Clear();
                txtNoiDung.Clear();
            }
            else
                MessageBox.Show("Khong co hop dong dang chon");
        }

        private void grd_DSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd_DSHD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grd_DSHD.CurrentRow.Selected = true;
                txtMaHD.Text = grd_DSHD.Rows[e.RowIndex].Cells["MaDT"].FormattedValue.ToString();
                txtDoiTac.Text = grd_DSHD.Rows[e.RowIndex].Cells["TenDoiTac"].FormattedValue.ToString();
                dtNgayKy.Text = grd_DSHD.Rows[e.RowIndex].Cells["NgayKyHopDong"].FormattedValue.ToString();
                dtNgayHetHan.Text = grd_DSHD.Rows[e.RowIndex].Cells["NgayHetHan"].FormattedValue.ToString();
                txtTTVT.Text = grd_DSHD.Rows[e.RowIndex].Cells["ThongTinViTriDang"].FormattedValue.ToString();
                txtNoiDung.Text = grd_DSHD.Rows[e.RowIndex].Cells["NoiDung"].FormattedValue.ToString();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            HopDongBUS hopdongBUS = new HopDongBUS();

            if (txtMaHD.Text != "")
            {
                int MaHD = Int32.Parse(txtMaHD.Text);
                DateTime NgayKy = dtNgayKy.Value;
                DateTime NgayHet = dtNgayHetHan.Value;
                String TTVT = txtTTVT.Text;
                String NoiDung = txtNoiDung.Text;

                if (hopdongBUS.kiemTraThongTin(NgayKy, NgayHet, TTVT, NoiDung))
                {
                    hopdongBUS.capNhatHopDong(MaHD, NgayKy, NgayHet, TTVT, NoiDung);
                    HienThiDanhSachHopDong();

                    txtMaHD.Clear();
                    txtDoiTac.Clear();
                    dtNgayKy.ResetText();
                    dtNgayHetHan.ResetText();
                    txtTTVT.Clear();
                    txtNoiDung.Clear();
                }
                else
                    MessageBox.Show("Vui long kiem tra lai thong tin");
            }
            else
                MessageBox.Show("Khong co hop dong dang chon");
        }

        private void dtimeThongKeHangStart_ValueChanged(object sender, EventArgs e)
        {
            HangBUS hangBUS = new HangBUS();
            grvThongKeHangBan.Rows.Clear();
            grvThongKeHangBan.Refresh();
            DataTable dt = hangBUS.lapBangThongKe(dtimeThongKeHangStart.Value, dtimeThongKeHangEnd.Value);
            foreach (DataRow dr in dt.Rows)
            {
                grvThongKeHangBan.Rows.Add(
                    dr["MAHANG"],
                    dr["TENHANG"].ToString(),
                    dr["DABAN"]);
                this.grvThongKeHangBan.ClearSelection();
            }
        }

        private void dtimeThongKeHangEnd_ValueChanged(object sender, EventArgs e)
        {
            HangBUS hangBUS = new HangBUS();
            grvThongKeHangBan.Rows.Clear();
            grvThongKeHangBan.Refresh();
            DataTable dt = hangBUS.lapBangThongKe(dtimeThongKeHangStart.Value, dtimeThongKeHangEnd.Value);
            foreach (DataRow dr in dt.Rows)
            {
                grvThongKeHangBan.Rows.Add(
                    dr["MAHANG"],
                    dr["TENHANG"].ToString(),
                    dr["DABAN"]);
                this.grvThongKeHangBan.ClearSelection();
            }
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
                    allDTQC[i].tenDoiTac,
                    allDTQC[i].ngayKyHopDong,
                    allDTQC[i].ngayHetHan,
                    allDTQC[i].thongTinViTriDang,
                    allDTQC[i].noiDung);
            }
            this.grd_DSHD.ClearSelection();
        }

        private void grd_HangQuangCao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grd_HangQuangCao.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grd_HangQuangCao.CurrentRow.Selected = true;
                txtHangDangChon.Text = grd_HangQuangCao.Rows[e.RowIndex].Cells["MaHang"].FormattedValue.ToString();

                maKH_Xoa.Clear();
                Load_DSKHQuangCao();
            }
        }

        private void DangNhap_button_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                this.LoginCallback();
            }
        }

        private void grd_KHQC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKHXoa.Text = grd_KHQC.Rows[e.RowIndex].Cells["MaKH"].FormattedValue.ToString();
        }

        private void btn_XoaKhachHang_Click(object sender, EventArgs e)
        {
            if (txtKHXoa.Text != "")
            {
                maKH_Xoa.Push(txtKHXoa.Text);
                txtKHXoa.Clear();
                Load_DSKHQuangCao();
            }
            else
            {
                MessageBox.Show("Vui long chon khach hang");
            }
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            if (maKH_Xoa.Count > 0)
            {
                maKH_Xoa.Pop();
                Load_DSKHQuangCao();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienDSMatHang();
        }

        private void btnGuiTinNhan_Click(object sender, EventArgs e)
        {
            LichSuQuangCaoBUS lichSu = new LichSuQuangCaoBUS();
            int MaLS = lichSu.LayMaLichSu();
            foreach (DataGridViewRow item in grd_KHQC.Rows)
            {
                MaLS += 1;
                lichSu.CapNhatLichSu(MaLS, Int32.Parse(item.Cells[0].Value.ToString()), Int32.Parse(txtHangDangChon.Text));
            }
            MessageBox.Show("Gui tin nhan thanh cong");
            maKH_Xoa.Clear();
            Load_DSKHQuangCao();
        }

        private void grvThongKeHangBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HangBUS hangBUS = new HangBUS();
            if (grvThongKeHangBan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grvThongKeHangBan.CurrentRow.Selected = true;
                string mahang = grvThongKeHangBan.Rows[e.RowIndex].Cells["COLMAHANG"].FormattedValue.ToString();

                List<HangDTO> hangByID = hangBUS.TimKiem(mahang);
                if (!maHang_Add.Contains(hangByID[0].maHang.ToString()))
                {
                    maHang_Add.Push(hangByID[0].maHang.ToString());
                    grvChiTietDonNhap.Rows.Add(
                        hangByID[0].maHang,
                        hangByID[0].tenHang,
                        1
                        );
                }
                else
                {
                    MessageBox.Show("Đã tồn tại hàng trong đơn");
                }

            }
        }

        private void grvChiTietDonNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int currvalue = int.Parse(txtTongSoLuongHangNhap.Text);
            currvalue += 1;
            txtTongSoLuongHangNhap.Text = currvalue.ToString();
            //int sum = 0;
            //sum = sum + Convert.ToInt32(grvChiTietDonNhap.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //int currvalue = int.Parse(txtTongSoLuongHangNhap.Text);
            //currvalue += sum;
            //txtTongSoLuongHangNhap.Text = currvalue.ToString();
        }

        private void grvChiTietDonNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (login_stats == false)
            {
                return;
            }
            int newlyAdded = Convert.ToInt32(grvChiTietDonNhap.Rows[e.RowIndex].Cells["COLSOLUONG"].Value.ToString()) - 1;

            int currvalue = int.Parse(txtTongSoLuongHangNhap.Text);

            currvalue += newlyAdded;
            txtTongSoLuongHangNhap.Text = currvalue.ToString();
        }

        private void btnAddDonNhap_Click(object sender, EventArgs e)
        {
            DonNhapHangDTO donNhapHangDTO = new DonNhapHangDTO();
            donNhapHangDTO.maNV = int.Parse(txtNhanVienNhapHang.Text.Split(',')[0]);
            donNhapHangDTO.tongLuongHang = int.Parse(txtTongSoLuongHangNhap.Text);
            donNhapHangDTO.lyDoNhap = txtLyDoNhapHang.Text;
            donNhapHangDTO.ngayNhap = dtPickNgayNhap.Value;
            DonNhapHangBUS donNhapBUS = new DonNhapHangBUS();
            int idDonNhap = donNhapBUS.Insert(donNhapHangDTO);

            foreach (DataGridViewRow row in grvChiTietDonNhap.Rows)
            {
                ChiTietDonNhapDTO chiTietDonNhapDTO = new ChiTietDonNhapDTO();
                int mahang = Convert.ToInt32(row.Cells["COLMAHANGCTDONNHAP"].Value);
                int soluongnhap = Convert.ToInt32(row.Cells["COLSOLUONG"].Value);
                chiTietDonNhapDTO.maDonNhap = idDonNhap;
                chiTietDonNhapDTO.maHang = mahang;
                chiTietDonNhapDTO.soLuongNhap = soluongnhap;
                ChiTietDonNhapBUS chiTietDonNhapBUS = new ChiTietDonNhapBUS();
                chiTietDonNhapBUS.Insert(chiTietDonNhapDTO);
            }
            MessageBox.Show("Thêm đơn nhập hàng thành công");
        }





        // Tra Hang 
        private void Nhap_THHoaDon_Click(object sender, EventArgs e)
        {
            int maHD = Int32.Parse(trahangMaHD_txtbox.Text);
            HoaDonBanHangBUS hoadonBus = new HoaDonBanHangBUS();
            HoaDonBanHangDTO hoadonSearch = hoadonBus.SearchHD_TraHang(maHD);
            this.dtGV_THHoaDon.Rows.Clear();
            this.dtGV_THHoaDon.Rows.Add(hoadonSearch.maKH, hoadonSearch.maNVLap, hoadonSearch.maNVGiao,
                hoadonSearch.maNVXacThuc, hoadonSearch.tongTien, hoadonSearch.hinhThucThanhToan,
                hoadonSearch.xacNhanDaThanhToan, hoadonSearch.ngayGiao,
                hoadonSearch.soTienThanhToan, hoadonSearch.ngayLap);
            this.dtGV_THHoaDon.ClearSelection();

        }
        private void Nhap_THKhach_Click(object sender, EventArgs e)
        {
            KhachHangBUS khBus = new KhachHangBUS();
            KhachHangDTO khSearch = khBus.SearchKH_Name(traHang_timKHtxtbox.Text);

            this.dtGV_TraHangKH.Rows.Clear();
            this.dtGV_TraHangKH.Rows.Add(khSearch.tenKH, khSearch.diaChiKH, khSearch.emailKH, khSearch.trangThaiKhoaComment);

            this.dtGV_TraHangKH.ClearSelection();

        }


        private void HienDSMatHang()
        {
            HangBUS hang = new HangBUS();
            List<HangDTO> allHang = hang.TimKiem(txtTimKiem.Text);
            /*format column size*/
            grd_HangQuangCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grd_HangQuangCao.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            grd_HangQuangCao.Rows.Clear();
            for (int i = 0; i < allHang.Count; i++)
            {
                grd_HangQuangCao.Rows.Add(
                    allHang[i].maHang,
                    allHang[i].tenHang,
                    allHang[i].soLuongConLai,
                    allHang[i].donGia);
            }
            this.grd_HangQuangCao.ClearSelection();
        }

        private void Load_DSKHQuangCao()
        {
            KhachHangBUS khachHang = new KhachHangBUS();
            List<KhachHangDTO> allKHQC;
            allKHQC = khachHang.LayDSKHQuangCao(Int32.Parse(txtHangDangChon.Text), maKH_Xoa);

            grd_KHQC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grd_KHQC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            grd_KHQC.Rows.Clear();
            for (int i = 0; i < allKHQC.Count; i++)
            {
                this.grd_KHQC.Rows.Add(
                    allKHQC[i].maKH,
                    allKHQC[i].tenKH);
            }
            this.grd_KHQC.ClearSelection();
        }
    }
}
