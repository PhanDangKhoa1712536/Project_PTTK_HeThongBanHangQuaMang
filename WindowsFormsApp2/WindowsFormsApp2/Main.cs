using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace Presentation
{
    public partial class MainForm : Form
    {
        private static readonly Stack<string> stacks = new Stack<string>();
        private readonly Stack<string> maKH_Xoa = stacks;
        private readonly List<string> maHang_Add = new List<string>();
        public NhanVienDTO nhanvienDTO;

        public bool login_stats;
        public int MaNV_login; // Mã của nhân viên hiện tại đang log vào, chưa log vào mặc định là -1
        private TabPage tmpComment, tmpNhapHang, tmpQuangCao, tmpTraHang, tmpXuLyMua;

        public MainForm()
        {
            InitForm();
            Load_DSDonNhap();
            //Load_DSComment();
            HienDSMatHang();
            Load_DSNVGiaoHang();
            Load_DSNhaCungCap();
            LoadMaBangThongKe();
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

            this.tabMain.TabPages.Remove(this.tbComment);
            this.tabMain.TabPages.Remove(this.tbNhapHang);
            this.tabMain.TabPages.Remove(this.tbQuangCao);
            this.tabMain.TabPages.Remove(this.tbTraHang);
            this.tabMain.TabPages.Remove(this.tbXuLyMua);

            dtimeThongKeHangStart.MaxDate = DateTime.Now;
            dtPickNgayNhap.MinDate = DateTime.Now;

            this.login_stats = false;
            this.MaNV_login = -1;
        }

        private void LoginCallback()
        {
            this.tabMain.TabPages.Add(this.tmpNhapHang);
            this.tabMain.TabPages.Add(this.tmpTraHang);
            this.tabMain.TabPages.Add(this.tmpComment);
            this.tabMain.TabPages.Add(this.tmpQuangCao);
            this.tabMain.TabPages.Add(this.tmpXuLyMua);

            this.tabMain.SelectedIndex = 1;
            InitHoaDonBanHang();
            Load_AllMaHD();
        }

     
        private void Load_DSNhaCungCap()
        {
            NhaCungCapBUS nhaCungCapBUS = new NhaCungCapBUS();
            List<NhaCungCapDTO> allNCC = nhaCungCapBUS.LayDanhSachNCC();
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
            DialogResult res = MessageBox.Show("               Thoát ứng dụng?", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void tnMinimizeMain_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Load_DSDonNhap()
        {
            DonNhapHangBUS donNhapHangBUS = new DonNhapHangBUS();
            List<DonNhapHangDTO> allDonNhapHang = donNhapHangBUS.LayDanhSachDonNhapHang();
            /*format column size*/
            grv_DonNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grv_DonNhapHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            grv_DonNhapHang.Rows.Clear();
            for (int i = 0; i < allDonNhapHang.Count; i++)
            {
                this.grv_DonNhapHang.Rows.Add(
                    allDonNhapHang[i].maDonNhap,
                    allDonNhapHang[i].tenNVLap,
                    allDonNhapHang[i].tongLuongHang,
                    allDonNhapHang[i].lyDoNhap,
                    allDonNhapHang[i].ngayNhap,
                    allDonNhapHang[i].trangThaiXacNhan
                    );
            }
            this.grv_DonNhapHang.ClearSelection();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("                    Đăng xuất?", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void btnXoaHopDong_Click(object sender, EventArgs e)
        {
            HopDongBUS hopdongBUS = new HopDongBUS();
            if (txtMaHD.Text != "")
            {
                int MaHD = Int32.Parse(txtMaHD.Text);
                hopdongBUS.HuyHopDong(MaHD);
                HienThiDanhSachHopDong();

                txtMaHD.Clear();
                txtDoiTac.Clear();
                dtNgayKy.ResetText();
                dtNgayHetHan.ResetText();
                txtTTVT.Clear();
                txtNoiDung.Clear();
                MessageBox.Show("Hủy hợp đồng thành công");
            }
            else
                MessageBox.Show("Không có hợp đồng nào được chọn");
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

                if (hopdongBUS.KiemTraThongTin(NgayKy, NgayHet, TTVT, NoiDung))
                {
                    hopdongBUS.CapNhatHopDong(MaHD, NgayKy, NgayHet, TTVT, NoiDung);
                    HienThiDanhSachHopDong();

                    txtMaHD.Clear();
                    txtDoiTac.Clear();
                    dtNgayKy.ResetText();
                    dtNgayHetHan.ResetText();
                    txtTTVT.Clear();
                    txtNoiDung.Clear();
                    MessageBox.Show("Cập nhật hợp đồng thành công");
                }
                else
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin");
            }
            else
                MessageBox.Show("Không có hợp đồng nào được chọn");
        }

        private void Load_BTKHangBan()
        {
            HangBUS hangBUS = new HangBUS();
            grvThongKeHangBan.Rows.Clear();
            grvThongKeHangBan.Refresh();
            List<HangDTO> allHang = hangBUS.lapBangThongKeHangBan(dtimeThongKeHangStart.Value, dtimeThongKeHangEnd.Value);
            for (int i = 0; i < allHang.Count; i++)
            {
                grvThongKeHangBan.Rows.Add(
                    allHang[i].maHang,
                    allHang[i].tenHang,
                    allHang[i].soLuongDaBan);
                this.grvThongKeHangBan.ClearSelection();
            }
        }

        private void dtimeThongKeHangStart_ValueChanged(object sender, EventArgs e)
        {
            dtimeThongKeHangEnd.MinDate = dtimeThongKeHangStart.Value;
            Load_BTKHangBan();
        }

        private void dtimeThongKeHangEnd_ValueChanged(object sender, EventArgs e)
        {
            Load_BTKHangBan();
        }


        private void HienThiDanhSachHopDong()
        {
            HopDongBUS hopdongBUS = new HopDongBUS();
            List<DoiTacQuangCaoDTO> allDTQC = hopdongBUS.DocHopDong();

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
                MessageBox.Show("Vui lòng chọn khách hàng");
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
            if (txtHangDangChon.Text != "")
            {
                LichSuQuangCaoBUS lichSu = new LichSuQuangCaoBUS();
                foreach (DataGridViewRow item in grd_KHQC.Rows)
                {
                    lichSu.CapNhatLichSu(Int32.Parse(item.Cells[0].Value.ToString()), Int32.Parse(txtHangDangChon.Text));
                }
                MessageBox.Show("Gửi tin nhắn thành công");
                maKH_Xoa.Clear();
                Load_DSKHQuangCao();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mặt hàng");
            }
        }

        private void ThemChiTietDonNhapUI(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                HangBUS hangBUS = new HangBUS();
                if (grvThongKeHangBan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    grvThongKeHangBan.CurrentRow.Selected = true;
                    string mahang = grvThongKeHangBan.Rows[e.RowIndex].Cells["COLMAHANG"].FormattedValue.ToString();

                    List<HangDTO> hangByID = hangBUS.TimKiem(mahang);
                    if (!maHang_Add.Contains(hangByID[0].maHang.ToString()))
                    {
                        maHang_Add.Add(hangByID[0].maHang.ToString());
                        grvChiTietDonNhapTab1.Rows.Add(
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void grvThongKeHangBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ThemChiTietDonNhapUI(sender, e);
        }

        private void grvChiTietDonNhap_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int currvalue = int.Parse(txtTongSoLuongHangNhap.Text);
            currvalue++;
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
            //int newlyAdded = Convert.ToInt32(grvChiTietDonNhapTab1.Rows[e.RowIndex].Cells["COLSOLUONG"].Value.ToString()) - 1;

            //int currvalue = int.Parse(txtTongSoLuongHangNhap.Text);

            //currvalue += newlyAdded;
            int sum = 0;
            for (int i = 0; i < grvChiTietDonNhapTab1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(grvChiTietDonNhapTab1.Rows[i].Cells["COLSOLUONG"].Value);
            }
            txtTongSoLuongHangNhap.Text = sum.ToString();
        }

        private void btnAddDonNhap_Click(object sender, EventArgs e)
        {
            if (txtLyDoNhapHang.Text == "" || txtLyDoNhapHang.Text == "*Vui lòng thêm lý do nhập hàng")
            {
                txtLyDoNhapHang.Text = "*Vui lòng thêm lý do nhập hàng";
                txtLyDoNhapHang.BackColor = Color.Red;
                
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Xác nhận lập đơn nhập hàng?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DonNhapHangDTO donNhapHangDTO = new DonNhapHangDTO
                        {
                            maNV = int.Parse(txtNhanVienNhapHang.Text.Split(',')[0]),
                            tongLuongHang = int.Parse(txtTongSoLuongHangNhap.Text),
                            lyDoNhap = txtLyDoNhapHang.Text,
                            ngayNhap = dtPickNgayNhap.Value
                        };
                        DonNhapHangBUS donNhapBUS = new DonNhapHangBUS();
                        int idDonNhap = donNhapBUS.KhoiTaoDonNhapHang(donNhapHangDTO);

                        foreach (DataGridViewRow row in grvChiTietDonNhapTab1.Rows)
                        {
                            ChiTietDonNhapDTO chiTietDonNhapDTO = new ChiTietDonNhapDTO();
                            int mahang = Convert.ToInt32(row.Cells["COLMAHANGCTDONNHAP"].Value);
                            int soluongnhap = Convert.ToInt32(row.Cells["COLSOLUONG"].Value);
                            chiTietDonNhapDTO.maDonNhap = idDonNhap;
                            chiTietDonNhapDTO.maHang = mahang;
                            chiTietDonNhapDTO.soLuongNhap = soluongnhap;
                            ChiTietDonNhapBUS chiTietDonNhapBUS = new ChiTietDonNhapBUS();
                            chiTietDonNhapBUS.ThemChiTietDonNhap(chiTietDonNhapDTO);
                        }
                        
                        MessageBox.Show("Thêm đơn nhập hàng thành công");

                        grvChiTietDonNhapTab1.Rows.Clear();
                        txtTongSoLuongHangNhap.Text = Convert.ToString(0);
                        maHang_Add.Clear();
                        txtLyDoNhapHang.Clear();
                        tabCtrlNhapHang.SelectedIndex = 1;
                        Load_DSDonNhap();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi thêm đơn nhập hàng " + ex.Message);
                    }
                }
            }
        }

        // ============================TRA HANG SECTION ================== //
        private void Nhap_THHoaDon_Click(object sender, EventArgs e)
        {
            if(trahangMaHD_txtbox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Hóa Đơn!");
                return;
            }
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
            if(traHang_timKHtxtbox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Khách Hàng!");
                return;
            }
            KhachHangBUS khBus = new KhachHangBUS();
            KhachHangDTO khSearch = khBus.SearchKH_Name(traHang_timKHtxtbox.Text);

            this.dtGV_TraHangKH.Rows.Clear();
            this.dtGV_TraHangKH.Rows.Add(khSearch.tenKH, khSearch.emailKH, khSearch.diaChiKH, khSearch.trangThaiKhoaComment);

            this.dtGV_TraHangKH.ClearSelection();

        }


        private void TaoPhieuTra_Click(object sender, EventArgs e)
        {
            DonTraHangBUS dontraBUS = new DonTraHangBUS();
            if(MaNV_TraHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Nhân Viên Trả Hàng!");
                return;
            }
            if(MaNCC_TraHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Nhà Cung Cấp!");
                return;
            }

            int maDon = dontraBUS.MaDon_autoGen();
            int maNVLAP = Int32.Parse(MaNV_TraHang.Text);
            int maNCC = Int32.Parse(MaNCC_TraHang.Text);
            DateTime NgayLap = ngayLap_TraHang.Value;

           

            try
            {
                dontraBUS.ThemDonTraHang(maDon, maNVLAP, maNCC, NgayLap);
                MessageBox.Show("Them Đơn Trả Hàng Thành Công");
                

            }
            catch(Exception er)
            {
                MessageBox.Show("Thêm đơn trả hàng thất bại!, Loi: " + er.Message);
                return;
            }

        }


        private void btnThemCTPhieuTraHang_Click(object sender, EventArgs e)
        {
            ChiTietDonTraHangBUS chiTietDonTraHangBUS = new ChiTietDonTraHangBUS();
            HangLoiBUS hangLoiBUS = new HangLoiBUS();
            ChiTietHangLoiBUS chiTietHangLoiBUS = new ChiTietHangLoiBUS();

            if(MaHangLoi_traHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Hàng Lỗi!");
                return;
            }
            if(soLuongHangLoi_traHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Số Lượng Hàng Lỗi!");
                return;
            }
            if (MaDonTra_TraHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Đơn Trả Hàng!");
                return;
            }
            if (MaHoaDon_TraHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Mã Hóa Đơn Trả Hàng!");
                return;
            }
            if (Lydo_TraHang.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Lý Do Trả Hàng!");
                return;
            }
            

            int maHangLoi = Int32.Parse(MaHangLoi_traHang.Text);
            int soLuongHangLoi = Int32.Parse(soLuongHangLoi_traHang.Text);
            int maDonTraHang = Int32.Parse(MaDonTra_TraHang.Text);
            int maHoaDon = Int32.Parse(MaHoaDon_TraHang.Text);

            int maCTdonTraHang = chiTietDonTraHangBUS.CTMaDon_autoGen();
            int maCTHangLoi = chiTietHangLoiBUS.MaChiTietHangLoi();
            string LyDo = Lydo_TraHang.Text;
            try
            {
                chiTietDonTraHangBUS.ThemChiTietDonTraHang(maCTdonTraHang,maDonTraHang,maHangLoi,soLuongHangLoi,LyDo);

               bool check = hangLoiBUS.KiemTraTonTai(maHangLoi);
                if(check == true)
                {
                    hangLoiBUS.ThemSoLuong(maHangLoi, soLuongHangLoi);
                }
                else
                {
                    hangLoiBUS.ThemHangLoi(maHangLoi, soLuongHangLoi);

                }

               chiTietHangLoiBUS.ThemChiTietHangLoi(maCTHangLoi, maHoaDon, maHangLoi);

                MessageBox.Show("Thêm Vào Chi Tiết Đơn Trả Hàng Thành Công");

            }
            catch(Exception er)
            {
                MessageBox.Show("Thêm đơn trả hàng thất bại!, Loi: " + er.Message);
                return;
            }


        }


        //==========================================================================/

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
        ///////////////////////
        // TAB XU LI MUA HANG
        ///////////////////////

        private void Load_DSNVGiaoHang()
        {
            NhanVienBUS NV_bus = new NhanVienBUS();
            List<int> list_NVGH = NV_bus.LoadNVGH();
            MaNVGiaoHangHDBan_comboBox.DataSource = list_NVGH;
        }

        private void InitHoaDonBanHang()
        {
            // CAC BUOC INIT CAN BAN (đọc mã hóa đơn, ngày lập hiện tại, gán mã nhân viên hiện tại vào)
            HoaDonBanHangBUS HD_bus = new HoaDonBanHangBUS();
            ChiTietHoaDonBUS CT_bus = new ChiTietHoaDonBUS();

            MaNVLapHDBan_textBox.Text = MaNV_login.ToString();
            int MaHD = HD_bus.CreateMaHD();
            MaHoaDonBan_textbox.Text = MaHD.ToString();
            NgayLapHDBan_textBox.Text = DateTime.Now.ToString();


            // Đọc thông tin chi tiết hóa đơn từ giỏ hàng
            List<ChiTietHoaDonDTO> GioHang = CT_bus.DocChiTietTuGioHang(MaHD);

            // Tính tổng hóa đơn và gán vào text box
            float TongTien = CT_bus.TinhTongHoaDon(GioHang);
            TongTienLap_textbox.Text = TongTien.ToString();

            // Tạo datatable để đổ data từ chi tiết hóa đơn từ giỏ hàng vào
            DataTable source = new DataTable();
            source.Columns.Add(new DataColumn("MA HANG", Type.GetType("System.Int32")));
            source.Columns.Add(new DataColumn("TEN HANG", Type.GetType("System.String")));
            source.Columns.Add(new DataColumn("SO LUONG MUA", Type.GetType("System.Int32")));
            source.Columns.Add(new DataColumn("DON GIA", Type.GetType("System.Single")));

            // Thêm từng dòng dữ liệu vào datatable
            foreach (ChiTietHoaDonDTO i in GioHang)
            {
                DataRow temp = source.NewRow();
                temp["MA HANG"] = i.maHang;
                temp["TEN HANG"] = i.TenHang;
                temp["SO LUONG MUA"] = i.soLuong;
                temp["DON GIA"] = i.DonGia;
                source.Rows.Add(temp);
            }
            // Bind Datatable vào DataGridView
            //var bindlingList = new BindingList<ChiTietHoaDonDTO>(CT_bus.DocChiTietTuGioHang(MaHD));
            //var source = new BindingSource(bindlingList, null);
            ChiTietHDBan_dataGridView.DataSource = source;
        }

        private void LapHoaDonBanHang_button_Click_1(object sender, EventArgs e)
        {
            HoaDonBanHangBUS HD_bus = new HoaDonBanHangBUS();
            ChiTietHoaDonBUS CT_bus = new ChiTietHoaDonBUS();
            KhachHangBUS KH_bus = new KhachHangBUS();

            // Đọc dữ liệu từ text box lên
            int MaHD = Int32.Parse(MaHoaDonBan_textbox.Text);
            //DateTime NgayLap = DateTime.Parse(NgayLapHDBan_textBox.Text);
            DateTime NgayGiao = NgayGiaoHang_dateTimePicker4.Value;

            string HoTen = HoTen_textBox.Text;
            string DiaChi = DiaChiKhach_textBox.Text;
            string Email = EmailKhachHang_textBox.Text;

            int MaNV = Int32.Parse(MaNVLapHDBan_textBox.Text);
            int MaNVGiao = Int32.Parse(MaNVGiaoHangHDBan_comboBox.Text);
            int TongTien = Int32.Parse(TongTienLap_textbox.Text);

            //KH_bus.KiemTraThongTinKH(HoTen, DiaChi, Email) == true
            // xử lí thông tin
            if (HD_bus.KiemTraNgayGiaoHang(NgayGiao) == true && KH_bus.KiemTraThongTinKH(HoTen, DiaChi, Email) == true) // kiểm tra tính đúng đắn thông tin của khách hàng và ngày giao
            {
                int MaKH = KH_bus.SearchKH(HoTen, Email);       // Kiểm tra xem có khách hàng nào có thông tin như trên trong db không
                if (MaKH == 0) //khong có khách hàng trong database
                {
                    try
                    {
                        MaKH = KH_bus.CreateMaKH(); // tạo 1 mã Khách hàng mới 
                        KhachHangDTO KH = KH_bus.KhoiTao(HoTen, Email, DiaChi);
                        KH_bus.ThemKhachHang_bus(KH);
                        MessageBox.Show("Them khach hang thanh cong!");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Them khach hang khong thanh cong, Loi:" + er.ToString());
                        return;
                    }
                }

                try
                {
                    // Khoi tạo hóa đơn 
                    HoaDonBanHangDTO HD = HD_bus.KhoiTao(NgayGiao, MaKH, MaNV, MaNVGiao, MaHD, TongTien);
                    HD_bus.LapHoaDonBanHang(HD);

                    // Đọc lại chi tiết từ giỏ hàng 
                    List<ChiTietHoaDonDTO> GioHang = CT_bus.DocChiTietTuGioHang(HD_bus.CreateMaHD()-1);
                    foreach (ChiTietHoaDonDTO CT in GioHang)
                    {
                        //MessageBox.Show("MaHoaDon:" + CT.maHoaDon.ToString() + "MaHang: " + CT.maHang.ToString() + "SoLuong:" + CT.soLuong.ToString());
                        CT_bus.ThemChiTietDon_bus(CT);
                    }
                    MessageBox.Show("Them Hóa đơn thành công!");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Thêm hóa đơn thất bại!, Loi: " + er.ToString());
                    return;
                }

                MaHoaDonBan_textbox.Text = HD_bus.CreateMaHD().ToString();
                NgayLapHDBan_textBox.Text = DateTime.Now.ToString();
                DiaChiKhach_textBox.Text = "";
                EmailKhachHang_textBox.Text = "";
                HoTen_textBox.Text = "";
                TongTienHoaDonXoa_textBox.Text = "";
                if (ChiTietHoaDonXoaHD_dataGridView.Rows.Count != 0)
                    ChiTietHDBan_dataGridView.DataSource = null;
                ChiTietHDBan_dataGridView.Refresh();
            }
            else
            {
                MessageBox.Show("Thong tin khách hàng sai qui cách hoặc ngày sai qui định!");
            }
        }

        public void sendNCC_UI()
        {
            string nhacungcap = grv_NhaCungCap[1, grv_NhaCungCap.CurrentRow.Index].Value.ToString();
            DialogResult result = MessageBox.Show("Xác nhận gửi cho nhà cung cấp " + nhacungcap + "?", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DonNhapHangBUS donNhapHangBUS = new DonNhapHangBUS();
                DonNhapHangDTO donNhapHangDTO = new DonNhapHangDTO
                {
                    maNCC = int.Parse(grv_NhaCungCap[0, grv_NhaCungCap.CurrentRow.Index].Value.ToString()),
                    maDonNhap = int.Parse(grv_DonNhapHang[0, grv_DonNhapHang.CurrentRow.Index].Value.ToString())
                };
                if (donNhapHangBUS.GuiChoNhaCungCap(donNhapHangDTO))
                {
                    MessageBox.Show("Gửi thành công");
                    Load_DSDonNhap();
                }
            }
        }

        private void btn_sendNCC_Click(object sender, EventArgs e)
        {
            sendNCC_UI();
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            int soluongXoa = int.Parse(grvChiTietDonNhapTab1[2, grvChiTietDonNhapTab1.CurrentRow.Index].Value.ToString());
            int tongSLMoi = int.Parse(txtTongSoLuongHangNhap.Text) - soluongXoa;
            txtTongSoLuongHangNhap.Text = tongSLMoi.ToString();
            maHang_Add.Remove(grvChiTietDonNhapTab1[0, grvChiTietDonNhapTab1.CurrentRow.Index].Value.ToString());
            grvChiTietDonNhapTab1.Rows.Remove(grvChiTietDonNhapTab1.CurrentRow);
        }

        private void HienThiNhaCungCapTheoTuKhoa(string keyword)
        {
            NhaCungCapBUS nhaCungCapBUS = new NhaCungCapBUS();
            List<NhaCungCapDTO> allNCC = nhaCungCapBUS.TimBangTuKhoa(keyword);
            grv_NhaCungCap.Rows.Clear();
            for (int i = 0; i < allNCC.Count; i++)
            {
                this.grv_NhaCungCap.Rows.Add(
                    allNCC[i].maNCC,
                    allNCC[i].tenNCC);
            }
            this.grv_NhaCungCap.ClearSelection();
        }

        private void txtTimNhaCungCap_TextChanged(object sender, EventArgs e)
        {
            HienThiNhaCungCapTheoTuKhoa(txtTimNhaCungCap.Text);
        }

        private void txtTongSoLuongHangNhap_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txtTongSoLuongHangNhap.Text) != 0)
            {
                btnAddDonNhap.Enabled = true;
                btnXoaChiTietDonNhapUI.Enabled = true;
            }
            else if (int.Parse(txtTongSoLuongHangNhap.Text) == 0)
            {
                btnAddDonNhap.Enabled = false; 
                btnXoaChiTietDonNhapUI.Enabled = false;
            }
        }

        /// <summary>
        /// thong ke
        /// </summary>
        private void LoadBangThongKeTot()
        {
            GopYBUS gopYBUS = new GopYBUS();
            List<GopYDTO> allTot = gopYBUS.getAllCommentTotByBangThongKe(Int32.Parse(cbMaThongKe.SelectedValue.ToString()));
            grvCmtTot.DataSource = allTot;

            grvCmtTot.Columns.Remove("GhiNhanXoa");

        }
        private void LoadBangThongKeXau()
        {
            GopYBUS gopYBUS = new GopYBUS();
            List<GopYDTO> allXau = gopYBUS.getAllCommentXauByBangThongKe(Int32.Parse(cbMaThongKe.SelectedValue.ToString()));
            grvCmtXau.DataSource = allXau;

            grvCmtXau.Columns.Remove("GhiNhanTangQua");

        }

        private void btnXuLyThongKe_Click(object sender, EventArgs e)
        {
            GopYBUS gopYBUS = new GopYBUS();
            var result = gopYBUS.getByDate(dTimeStartThongKeCmt.Value, dTimeEndThongKeCmt.Value);
            grvAllComments.Refresh();
            grvAllComments.DataSource = result;
            grvAllComments.Columns.Remove("GhiNhanTangQua");
            grvAllComments.Columns.Remove("GhiNhanXoa");
        }
        private void LoadMaBangThongKe()
        {
            BangThongKeGopYBUS bangThongKeGopYBUS = new BangThongKeGopYBUS();
            List<int> BTK = bangThongKeGopYBUS.getMaBangTK();
            /*format column size*/

            cbMaThongKe.DataSource = BTK;
            cbMaThongKe.DisplayMember = "MABANGTHONGKE";
            cbMaThongKe.ValueMember = "MABANGTHONGKE";
        }

        private void btnXacNhanThongKe_Click(object sender, EventArgs e)
        {
            BangThongKeGopYBUS bangThongKeGopYBUS = new BangThongKeGopYBUS();
            int mabangtk = bangThongKeGopYBUS.insert(0, int.Parse(txtNhanVienNhapHang.Text.Split(',')[0]), DateTime.Now);
            List<GopYDTO> data = (List<GopYDTO>)grvAllComments.DataSource;
            ChiTietBangThongKeGopYBUS chiTietBangThongKeGopYBUS = new ChiTietBangThongKeGopYBUS();
            if (data != null)
            {
                foreach (var item in data)
                {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                    if (item.MaGopY != null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                    {
                        chiTietBangThongKeGopYBUS.Insert(mabangtk, item.MaGopY);
                    }
                }
                LoadMaBangThongKe();
            }
            MessageBox.Show("Đã thêm vào bảng thống kê");
        }

        private void btnXuLyCmt_Click(object sender, EventArgs e)
        {
            LoadBangThongKeTot();
            LoadBangThongKeXau();
        }

        private void btnGhiNhanTangQua_Click(object sender, EventArgs e)
        {
            int rowIndex = grvCmtTot.CurrentCell.RowIndex;

            string maGopY = grvCmtTot.Rows[rowIndex].Cells["MAGOPY"].FormattedValue.ToString();
            int magopy = int.Parse(maGopY);
            GopYBUS gopYBUS = new GopYBUS();
            gopYBUS.UpdateTangQua(magopy);
            MessageBox.Show("Đã ghi nhận tặng quà");
            LoadBangThongKeTot();

        }

        private void btnXoaVaChan_Click(object sender, EventArgs e)
        {
            int rowIndex = grvCmtXau.CurrentCell.RowIndex;

            string maGopY = grvCmtXau.Rows[rowIndex].Cells["MAGOPY"].FormattedValue.ToString();
            int magopy = int.Parse(maGopY);
            GopYBUS gopYBUS = new GopYBUS();
            gopYBUS.UpdateXacNhanXoaGopY(magopy);
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            khachHangBUS.UpdateKhoaComment(magopy);
            MessageBox.Show("Đã ghi nhận xóa và ngăn khách hàng comment");
            LoadBangThongKeXau();
        }

        private void Load_DSCommentThongKe()
        {
            GopYBUS gopYBUS = new GopYBUS();

            List<GopYDTO> allGopY = gopYBUS.getByDate(dTimeStartThongKeCmt.Value, dTimeEndThongKeCmt.Value);
            
            grvAllComments.DataSource = null;
            grvAllComments.DataSource = allGopY;
            grvAllComments.Columns.Remove("GhiNhanTangQua");
            grvAllComments.Columns.Remove("GhiNhanXoa");

        }

        private void grvAllComments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GopYBUS gopYBUS = new GopYBUS();

            if (grvAllComments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grvAllComments.CurrentRow.Selected = true;
                bool flagxau = (bool)grvAllComments.Rows[e.RowIndex].Cells["DANHDAUCOMMENTXAU"].FormattedValue;
                string maGopY = grvAllComments.Rows[e.RowIndex].Cells["MAGOPY"].FormattedValue.ToString();
                if (flagxau == false)
                {
                    gopYBUS.UpdateCmtXauTot(int.Parse(maGopY), true);

                }
                else
                {
                    gopYBUS.UpdateCmtXauTot(int.Parse(maGopY), false);
                }
                Load_DSCommentThongKe();
            }
        }

       /// <summary>
       /// 
       /// </summary>
      
        private void txtLyDoNhapHang_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtLyDoNhapHang.BackColor = Color.White;
            this.txtLyDoNhapHang.SelectAll();
            this.txtLyDoNhapHang.Clear();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void txtSYSNAME_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void txtSYSNAME_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void txtSYSNAME_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void grv_NhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string tenNCC = grv_NhaCungCap.Rows[grv_NhaCungCap.CurrentRow.Index].Cells["COLTENNCC"].FormattedValue.ToString();

                btn_sendNCC.Text = "GỬI ĐƠN NHẬP HÀNG CHO NCC " + tenNCC;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void grv_DonNhapHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                grv_DonNhapHang[0, 0].Selected = true;
                grv_DonNhapHang.CurrentRow.Selected = true;
                grboxChiTietDonNhapHangTab2.Text = "CHI TIẾT ĐƠN NHẬP CỦA ĐƠN SỐ " + grv_DonNhapHang.SelectedRows[0].Cells["COLMADONNHAP"].FormattedValue.ToString();

                HienThiDSChiTietDonNhap();
                NhaCungCapBUS nccBus = new NhaCungCapBUS();
                string tenNCC = nccBus.TimTenTheoMaDonNhap(grv_DonNhapHang.SelectedRows[0].Cells["COLMADONNHAP"].FormattedValue.ToString());
                grv_NhaCungCap.ClearSelection();
                foreach (DataGridViewRow row in grv_NhaCungCap.Rows)
                {
                    if (grv_NhaCungCap[1, row.Index].Value.ToString() == tenNCC)
                    {
                        grv_NhaCungCap.Rows[row.Index].Selected = true;
                        btn_sendNCC.Text = "GỬI ĐƠN NHẬP HÀNG CHO NCC " + tenNCC;
                    }
                }

                if ((bool)grv_DonNhapHang.SelectedRows[0].Cells["COLTRANGTHAIXACNHAN"].Value == false)
                {
                    this.btn_sendNCC.Enabled = true;
                }
                else
                {
                    this.btn_sendNCC.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnKT_HD_Click(object sender, EventArgs e)
        {
            HienThiDanhSachHopDong();
            if (grd_DSHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có hợp đồng nào hết hạn");
            }
        }

        

        private void Load_AllMaHD()
        {
            HoaDonBanHangBUS HD_bus = new HoaDonBanHangBUS();
            List<int> List_HD = HD_bus.LoadMaHD();
            XoaHoaDon_comboBox.DataSource = List_HD;
        }
        private void XoaHoaDon_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HoaDonBanHangBUS HD_bus = new HoaDonBanHangBUS();
            ChiTietHoaDonBUS CT_bus = new ChiTietHoaDonBUS();
            KhachHangBUS KH_bus = new KhachHangBUS();

            // Đọc thông tin hóa đơn và tìm thông tin khách hàng với MaKH trong hóa đơn
            HoaDonBanHangDTO HD = HD_bus.LoadTTHoaDon(Int32.Parse(XoaHoaDon_comboBox.Text));
            KhachHangDTO KH = KH_bus.TimKhachHangTheoMaKH(HD.maKH);

            // Đổ các thông tin dữ liệu vào phần textbox
            MaDonXoaHD_textBox.Text = HD.maHoaDon.ToString();
            NgayLapXoaHD_textBox.Text = HD.ngayLap.ToString();
            NgayGiaoHangXoaHD_textBox.Text = HD.ngayGiao.ToString();

            HoTenXoaHD_textBox.Text = KH.tenKH;
            DiaChiXoaHD_textBox.Text = KH.diaChiKH;
            EmailXoaHD_textBox.Text = KH.emailKH;

            MaNVGiaoXoaHD_textBox.Text = HD.maNVGiao.ToString();
            MaNVLapXoaHD_textBox.Text = HD.maNVLap.ToString();
            TongTienHoaDonXoa_textBox.Text = HD.tongTien.ToString();
            if (HD.xacNhanDaThanhToan == false)
            {
                TrangThaiHoaDon_textBox.Text = "Chưa Thanh Toán";
            }
            else TrangThaiHoaDon_textBox.Text = "Đã Thanh Toán";

            //Đọc các chi tiết hóa đơn của hóa đơn 
            List<ChiTietHoaDonDTO> List_CT = CT_bus.LoadCTHoaDon(HD.maHoaDon);

            // Tạo datatable để đổ data từ chi tiết hóa đơn từ giỏ hàng vào
            DataTable source = new DataTable();
            source.Columns.Add(new DataColumn("MA HANG", Type.GetType("System.Int32")));
            source.Columns.Add(new DataColumn("TEN HANG", Type.GetType("System.String")));
            source.Columns.Add(new DataColumn("SO LUONG MUA", Type.GetType("System.Int32")));
            source.Columns.Add(new DataColumn("DON GIA", Type.GetType("System.Single")));

            // Thêm từng dòng dữ liệu vào datatable
            foreach (ChiTietHoaDonDTO i in List_CT)
            {
                DataRow temp = source.NewRow();
                temp["MA HANG"] = i.maHang;
                temp["TEN HANG"] = i.TenHang;
                temp["SO LUONG MUA"] = i.soLuong;
                temp["DON GIA"] = i.DonGia;
                source.Rows.Add(temp);
            }

            ChiTietHoaDonXoaHD_dataGridView.DataSource = source;
        }
        private void HienThiDSChiTietDonNhap()
        {
            ChiTietDonNhapBUS chiTietDonNhapBUS = new ChiTietDonNhapBUS();
            String mahang = new String(grboxChiTietDonNhapHangTab2.Text.Where(Char.IsDigit).ToArray());
            List<ChiTietDonNhapDTO> allChiTiet = chiTietDonNhapBUS.LayDanhSachChiTietDonNhap(int.Parse(mahang));
            grvChiTietDonNhapTab2.Rows.Clear();
            for (int i = 0; i < allChiTiet.Count; i++)
            {
                this.grvChiTietDonNhapTab2.Rows.Add(
                    allChiTiet[i].maHang,
                    allChiTiet[i].tenHang,
                    allChiTiet[i].soLuongNhap);
            }
            this.grvChiTietDonNhapTab2.ClearSelection();
        }
        private void XoaHoaDon_button_Click(object sender, EventArgs e)
        {
            HoaDonBanHangBUS HD_bus = new HoaDonBanHangBUS();
            ChiTietHoaDonBUS CT_bus = new ChiTietHoaDonBUS();

            // Đọc MaHD và trạng thái lên từ textbox
            int MaHD = Int32.Parse(MaDonXoaHD_textBox.Text);
            int TrangThai = (TrangThaiHoaDon_textBox.Text == "Đã Thanh Toán") ? 1 : 0;

            // Kiểm tra trạng thái của hóa đơn nếu đã thanh toán rồi thì không được phép xóa
            if (TrangThai == 0)
            {
                try
                {
                    CT_bus.XoaCT(MaHD);
                    HD_bus.XoaHD(MaHD);
                    MessageBox.Show("Đã Xóa Hóa Đơn Thành Công");

                }
                catch (Exception er)
                {
                    MessageBox.Show("Xóa Hóa đơn không thành công, lỗi: " + er.ToString());
                }
                finally
                {
                    // reset normal state
                    MaDonXoaHD_textBox.Text = "";
                    NgayLapXoaHD_textBox.Text = "";
                    NgayGiaoHangXoaHD_textBox.Text = "";

                    HoTenXoaHD_textBox.Text = "";
                    DiaChiXoaHD_textBox.Text = "";
                    EmailXoaHD_textBox.Text = "";

                    MaNVGiaoXoaHD_textBox.Text = "";
                    MaNVLapXoaHD_textBox.Text = "";
                    TongTienHoaDonXoa_textBox.Text = "";
                    TrangThaiHoaDon_textBox.Text = "";
                    
                    if (ChiTietHoaDonXoaHD_dataGridView.Rows.Count != 0) // Nếu lượng dòng trong Gridview != 0 thì mới clear
                        ChiTietHoaDonXoaHD_dataGridView.Rows.Clear();
                    ChiTietHoaDonXoaHD_dataGridView.Refresh();

                    Load_AllMaHD();
                }
            }
            else
            {
                MessageBox.Show("Hóa Đơn đã được thanh toán, không được phép xóa!");
            }
        }
        ///////////////////////
        // END TAB XU LI MUA HANG
        ///////////////////////




    }
}
