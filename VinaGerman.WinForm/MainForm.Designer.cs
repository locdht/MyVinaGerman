namespace VinaGerman
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonQuanLyNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDSPhongBan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDSChiNhanh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDSNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDSKhachHangNCC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDSNganhNghe = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDSLinhVuc = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLoaiHangHoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDSHangHoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDanhMucDinhLuongSX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLapPhieuNhapHang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonTraCuuPhieuNhapHang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLapPhieuBan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonTraCuuPhieuBanHang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLenhSX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonTraCuuLenhSX = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonBCHangTonKho = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonBCLaiLo = new DevExpress.XtraBars.BarButtonItem();
            this.rbHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbCongTy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbQuanLyDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbXuatNhapKho = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbSanXuat = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonQuanLyNguoiDung,
            this.barButtonThoat,
            this.barButtonDSPhongBan,
            this.barButtonDSChiNhanh,
            this.barButtonDSNhanVien,
            this.barButtonDSKhachHangNCC,
            this.barButtonDSNganhNghe,
            this.barButtonDSLinhVuc,
            this.barButtonLoaiHangHoa,
            this.barButtonDSHangHoa,
            this.barButtonDanhMucDinhLuongSX,
            this.barButtonLapPhieuNhapHang,
            this.barButtonTraCuuPhieuNhapHang,
            this.barButtonLapPhieuBan,
            this.barButtonTraCuuPhieuBanHang,
            this.barButtonLenhSX,
            this.barButtonTraCuuLenhSX,
            this.barButtonBCHangTonKho,
            this.barButtonBCLaiLo});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 21;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbHeThong,
            this.rbCongTy,
            this.rbQuanLyDanhMuc,
            this.rbXuatNhapKho,
            this.rbSanXuat,
            this.rbBaoCao});
            this.ribbon.Size = new System.Drawing.Size(1177, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonQuanLyNguoiDung
            // 
            this.barButtonQuanLyNguoiDung.Caption = "Quản lý người dùng";
            this.barButtonQuanLyNguoiDung.Glyph = global::VinaGerman.Properties.Resources.contact;
            this.barButtonQuanLyNguoiDung.Id = 1;
            this.barButtonQuanLyNguoiDung.LargeGlyph = global::VinaGerman.Properties.Resources.contact;
            this.barButtonQuanLyNguoiDung.Name = "barButtonQuanLyNguoiDung";
            // 
            // barButtonThoat
            // 
            this.barButtonThoat.Caption = "Thoát";
            this.barButtonThoat.Glyph = global::VinaGerman.Properties.Resources.remove;
            this.barButtonThoat.Id = 3;
            this.barButtonThoat.LargeGlyph = global::VinaGerman.Properties.Resources.remove;
            this.barButtonThoat.Name = "barButtonThoat";
            // 
            // barButtonDSPhongBan
            // 
            this.barButtonDSPhongBan.Caption = "Danh sách phòng ban";
            this.barButtonDSPhongBan.Glyph = global::VinaGerman.Properties.Resources.department;
            this.barButtonDSPhongBan.Id = 4;
            this.barButtonDSPhongBan.LargeGlyph = global::VinaGerman.Properties.Resources.department;
            this.barButtonDSPhongBan.Name = "barButtonDSPhongBan";
            this.barButtonDSPhongBan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonDSChiNhanh
            // 
            this.barButtonDSChiNhanh.Caption = "Danh sách chi nhánh";
            this.barButtonDSChiNhanh.Glyph = global::VinaGerman.Properties.Resources.location;
            this.barButtonDSChiNhanh.Id = 5;
            this.barButtonDSChiNhanh.LargeGlyph = global::VinaGerman.Properties.Resources.location;
            this.barButtonDSChiNhanh.Name = "barButtonDSChiNhanh";
            this.barButtonDSChiNhanh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonDSNhanVien
            // 
            this.barButtonDSNhanVien.Caption = "Danh sách nhân viên";
            this.barButtonDSNhanVien.Glyph = global::VinaGerman.Properties.Resources.contact;
            this.barButtonDSNhanVien.Id = 6;
            this.barButtonDSNhanVien.LargeGlyph = global::VinaGerman.Properties.Resources.contact;
            this.barButtonDSNhanVien.Name = "barButtonDSNhanVien";
            this.barButtonDSNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonDSKhachHangNCC
            // 
            this.barButtonDSKhachHangNCC.Caption = "Danh sách khách hàng - Nhà cung cấp";
            this.barButtonDSKhachHangNCC.Glyph = global::VinaGerman.Properties.Resources.company;
            this.barButtonDSKhachHangNCC.Id = 7;
            this.barButtonDSKhachHangNCC.LargeGlyph = global::VinaGerman.Properties.Resources.company;
            this.barButtonDSKhachHangNCC.Name = "barButtonDSKhachHangNCC";
            this.barButtonDSKhachHangNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonDSNganhNghe
            // 
            this.barButtonDSNganhNghe.Caption = "Danh sách ngành nghề";
            this.barButtonDSNganhNghe.Glyph = global::VinaGerman.Properties.Resources.industry;
            this.barButtonDSNganhNghe.Id = 8;
            this.barButtonDSNganhNghe.LargeGlyph = global::VinaGerman.Properties.Resources.industry;
            this.barButtonDSNganhNghe.Name = "barButtonDSNganhNghe";
            this.barButtonDSNganhNghe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonDSLinhVuc
            // 
            this.barButtonDSLinhVuc.Caption = "Danh sách lĩnh vực";
            this.barButtonDSLinhVuc.Glyph = global::VinaGerman.Properties.Resources.business;
            this.barButtonDSLinhVuc.Id = 9;
            this.barButtonDSLinhVuc.LargeGlyph = global::VinaGerman.Properties.Resources.business;
            this.barButtonDSLinhVuc.Name = "barButtonDSLinhVuc";
            this.barButtonDSLinhVuc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonLoaiHangHoa
            // 
            this.barButtonLoaiHangHoa.Caption = "Danh sách loại hàng hóa";
            this.barButtonLoaiHangHoa.Glyph = global::VinaGerman.Properties.Resources.category;
            this.barButtonLoaiHangHoa.Id = 10;
            this.barButtonLoaiHangHoa.LargeGlyph = global::VinaGerman.Properties.Resources.category;
            this.barButtonLoaiHangHoa.Name = "barButtonLoaiHangHoa";
            this.barButtonLoaiHangHoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonDSHangHoa
            // 
            this.barButtonDSHangHoa.Caption = "Danh sách hàng hóa";
            this.barButtonDSHangHoa.Glyph = global::VinaGerman.Properties.Resources.goods;
            this.barButtonDSHangHoa.Id = 11;
            this.barButtonDSHangHoa.LargeGlyph = global::VinaGerman.Properties.Resources.goods;
            this.barButtonDSHangHoa.Name = "barButtonDSHangHoa";
            this.barButtonDSHangHoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonDanhMucDinhLuongSX
            // 
            this.barButtonDanhMucDinhLuongSX.Caption = "Danh mục định lượng sản xuất";
            this.barButtonDanhMucDinhLuongSX.Glyph = global::VinaGerman.Properties.Resources.goods;
            this.barButtonDanhMucDinhLuongSX.Id = 12;
            this.barButtonDanhMucDinhLuongSX.LargeGlyph = global::VinaGerman.Properties.Resources.goods;
            this.barButtonDanhMucDinhLuongSX.Name = "barButtonDanhMucDinhLuongSX";
            this.barButtonDanhMucDinhLuongSX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonLapPhieuNhapHang
            // 
            this.barButtonLapPhieuNhapHang.Caption = "Lập phiếu nhập hàng";
            this.barButtonLapPhieuNhapHang.Glyph = global::VinaGerman.Properties.Resources.purchase_order;
            this.barButtonLapPhieuNhapHang.Id = 13;
            this.barButtonLapPhieuNhapHang.LargeGlyph = global::VinaGerman.Properties.Resources.purchase_order;
            this.barButtonLapPhieuNhapHang.Name = "barButtonLapPhieuNhapHang";
            // 
            // barButtonTraCuuPhieuNhapHang
            // 
            this.barButtonTraCuuPhieuNhapHang.Caption = "Tra cứu phiếu nhập hàng";
            this.barButtonTraCuuPhieuNhapHang.Glyph = global::VinaGerman.Properties.Resources.purchase_order;
            this.barButtonTraCuuPhieuNhapHang.Id = 14;
            this.barButtonTraCuuPhieuNhapHang.LargeGlyph = global::VinaGerman.Properties.Resources.purchase_order;
            this.barButtonTraCuuPhieuNhapHang.Name = "barButtonTraCuuPhieuNhapHang";
            // 
            // barButtonLapPhieuBan
            // 
            this.barButtonLapPhieuBan.Caption = "Lập phiếu bán";
            this.barButtonLapPhieuBan.Glyph = global::VinaGerman.Properties.Resources.sale_order;
            this.barButtonLapPhieuBan.Id = 15;
            this.barButtonLapPhieuBan.LargeGlyph = global::VinaGerman.Properties.Resources.sale_order;
            this.barButtonLapPhieuBan.Name = "barButtonLapPhieuBan";
            // 
            // barButtonTraCuuPhieuBanHang
            // 
            this.barButtonTraCuuPhieuBanHang.Caption = "Tra cứu phiếu bán hàng";
            this.barButtonTraCuuPhieuBanHang.Glyph = global::VinaGerman.Properties.Resources.sale_order;
            this.barButtonTraCuuPhieuBanHang.Id = 16;
            this.barButtonTraCuuPhieuBanHang.LargeGlyph = global::VinaGerman.Properties.Resources.sale_order;
            this.barButtonTraCuuPhieuBanHang.Name = "barButtonTraCuuPhieuBanHang";
            // 
            // barButtonLenhSX
            // 
            this.barButtonLenhSX.Caption = "Lệnh sản xuất";
            this.barButtonLenhSX.Id = 17;
            this.barButtonLenhSX.Name = "barButtonLenhSX";
            // 
            // barButtonTraCuuLenhSX
            // 
            this.barButtonTraCuuLenhSX.Caption = "Tra cứu lệnh sản xuất";
            this.barButtonTraCuuLenhSX.Id = 18;
            this.barButtonTraCuuLenhSX.Name = "barButtonTraCuuLenhSX";
            // 
            // barButtonBCHangTonKho
            // 
            this.barButtonBCHangTonKho.Caption = "Báo cáo hàng tồn kho";
            this.barButtonBCHangTonKho.Id = 19;
            this.barButtonBCHangTonKho.Name = "barButtonBCHangTonKho";
            this.barButtonBCHangTonKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDSPhongBan_ItemClick);
            // 
            // barButtonBCLaiLo
            // 
            this.barButtonBCLaiLo.Caption = "Báo cáo lãi lỗ";
            this.barButtonBCLaiLo.Id = 20;
            this.barButtonBCLaiLo.Name = "barButtonBCLaiLo";
            // 
            // rbHeThong
            // 
            this.rbHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rbHeThong.Name = "rbHeThong";
            this.rbHeThong.Text = "Hệ Thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonQuanLyNguoiDung);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonThoat, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // rbCongTy
            // 
            this.rbCongTy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.rbCongTy.Name = "rbCongTy";
            this.rbCongTy.Text = "Công Ty";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonDSPhongBan);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonDSChiNhanh, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonDSNhanVien, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // rbQuanLyDanhMuc
            // 
            this.rbQuanLyDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.rbQuanLyDanhMuc.Name = "rbQuanLyDanhMuc";
            this.rbQuanLyDanhMuc.Text = "Quản lý danh mục";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonDSKhachHangNCC);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonDSNganhNghe, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonDSLinhVuc, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonLoaiHangHoa, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonDSHangHoa, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonDanhMucDinhLuongSX, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // rbXuatNhapKho
            // 
            this.rbXuatNhapKho.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.rbXuatNhapKho.Name = "rbXuatNhapKho";
            this.rbXuatNhapKho.Text = " Xuất  nhập kho";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonLapPhieuNhapHang);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonTraCuuPhieuNhapHang, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonLapPhieuBan, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonTraCuuPhieuBanHang, true);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // rbSanXuat
            // 
            this.rbSanXuat.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.rbSanXuat.Name = "rbSanXuat";
            this.rbSanXuat.Text = "Sản xuất";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonLenhSX);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonTraCuuLenhSX, true);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // rbBaoCao
            // 
            this.rbBaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.rbBaoCao.Name = "rbBaoCao";
            this.rbBaoCao.Text = "Báo cáo";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonBCHangTonKho);
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonBCLaiLo, true);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 549);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1177, 31);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 580);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonQuanLyNguoiDung;
        private DevExpress.XtraBars.BarButtonItem barButtonThoat;
        private DevExpress.XtraBars.BarButtonItem barButtonDSPhongBan;
        private DevExpress.XtraBars.BarButtonItem barButtonDSChiNhanh;
        private DevExpress.XtraBars.BarButtonItem barButtonDSNhanVien;
        private DevExpress.XtraBars.BarButtonItem barButtonDSKhachHangNCC;
        private DevExpress.XtraBars.BarButtonItem barButtonDSNganhNghe;
        private DevExpress.XtraBars.BarButtonItem barButtonDSLinhVuc;
        private DevExpress.XtraBars.BarButtonItem barButtonLoaiHangHoa;
        private DevExpress.XtraBars.BarButtonItem barButtonDSHangHoa;
        private DevExpress.XtraBars.BarButtonItem barButtonDanhMucDinhLuongSX;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbCongTy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbQuanLyDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonLapPhieuNhapHang;
        private DevExpress.XtraBars.BarButtonItem barButtonTraCuuPhieuNhapHang;
        private DevExpress.XtraBars.BarButtonItem barButtonLapPhieuBan;
        private DevExpress.XtraBars.BarButtonItem barButtonTraCuuPhieuBanHang;
        private DevExpress.XtraBars.BarButtonItem barButtonLenhSX;
        private DevExpress.XtraBars.BarButtonItem barButtonTraCuuLenhSX;
        private DevExpress.XtraBars.BarButtonItem barButtonBCHangTonKho;
        private DevExpress.XtraBars.BarButtonItem barButtonBCLaiLo;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbXuatNhapKho;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbSanXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
    }
}