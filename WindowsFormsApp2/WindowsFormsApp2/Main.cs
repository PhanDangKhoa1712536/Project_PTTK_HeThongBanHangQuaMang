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
using Microsoft.Win32;
using WindowsFormsApp2;

namespace Presentation
{
    public partial class MainForm : Form
    {
        Stack<string> maKH_Xoa = new Stack<string>();
        public bool login_stats;
        public int MaNV_login; // Mã của nhân viên hiện tại đang log vào, chưa log vào mặc định là -1
        private TabPage tmpComment, tmpNhapHang, tmpQuangCao, tmpTraHang, tmpXuLyMua;
        
        public MainForm()
        {
            InitForm();
            Load_DSNhaCungCap();
            Load_DSDonNhap();
            Load_DSComment();
            HienDSMatHang();
            //init XU LY MUA HANG
            Load_DSNVGiaoHang();
            
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
            this.MaNV_login = -1;
        }

        private void LoginCallback()
        {
            this.tabControl1.TabPages.Add(this.tmpNhapHang);
            this.tabControl1.TabPages.Add(this.tmpTraHang);
            this.tabControl1.TabPages.Add(this.tmpComment);
            this.tabControl1.TabPages.Add(this.tmpQuangCao);
            this.tabControl1.TabPages.Add(this.tmpXuLyMua);
            InitHoaDonBanHang();
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
            grvThongKeHangBan.DataSource = hangBUS.lapBangThongKe(dtimeThongKeHangStart.Value, dtimeThongKeHangEnd.Value);
        }

        private void dtimeThongKeHangEnd_ValueChanged(object sender, EventArgs e)
        {
            HangBUS hangBUS = new HangBUS();
            grvThongKeHangBan.DataSource = hangBUS.lapBangThongKe(dtimeThongKeHangStart.Value, dtimeThongKeHangEnd.Value);
        }

        private void grvThongKeHangBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ChiTietDonNhapBUS chiTietDonNhapBUS;
            if (grvThongKeHangBan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grvThongKeHangBan.CurrentRow.Selected = true;
                
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



        // Tra Hang 
        private void Nhap_THHoaDon_Click(object sender, EventArgs e)
        {
            int maHD = Int32.Parse(trahangMaHD_txtbox.Text);
            HoaDonBanHangBUS hoadonBus = new HoaDonBanHangBUS();             
            HoaDonBanHangDTO hoadonSearch = hoadonBus.SearchHD_TraHang(maHD);
            this.dtGV_THHoaDon.Rows.Clear();
            this.dtGV_THHoaDon.Rows.Add(hoadonSearch.maKH, hoadonSearch.maNVLap, hoadonSearch.maNVGiao,
                hoadonSearch.maNVXacThuc, hoadonSearch.tongTien, hoadonSearch.hinhThucThanhToan,
                hoadonSearch.xacNhanDaThanhToan,hoadonSearch.ngayGiao,
                hoadonSearch.soTienThanhToan,hoadonSearch.ngayLap);
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

        private void LapHoaDonBanHang_button_Click(object sender, EventArgs e)
        {
            HoaDonBanHangBUS HD_bus = new HoaDonBanHangBUS();
            ChiTietHoaDonBUS CT_bus = new ChiTietHoaDonBUS();
            KhachHangBUS KH_bus = new KhachHangBUS();

            // Đọc dữ liệu từ text box lên
            int MaHD = Int32.Parse(MaNVLapHDBan_textBox.Text);
            DateTime NgayLap = DateTime.Parse(NgayLapHDBan_textBox.Text);
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
                    HoaDonBanHangDTO HD = HD_bus.KhoiTao(NgayGiao, NgayLap, MaKH, MaNV, MaNVGiao, MaHD, TongTien);
                    HD_bus.LapHoaDonBanHang(HD);

                    // Đọc lại chi tiết từ giỏ hàng 
                    List<ChiTietHoaDonDTO> GioHang = CT_bus.DocChiTietTuGioHang(MaHD);
                    foreach (ChiTietHoaDonDTO CT in GioHang)
                    {
                        CT_bus.ThemChiTietDon_bus(CT);
                    }
                    MessageBox.Show("Them Hóa đơn thành công!");
                }
                catch(Exception er)
                {
                    MessageBox.Show("Thêm hóa đơn thất bại!, Loi: " + er.ToString());
                }           
            }
            else
            {
                MessageBox.Show("Thong tin khách hàng sai qui cách!");
            }   
        }
        ///////////////////////
        // END TAB XU LI MUA HANG
        ///////////////////////
    }
}
