namespace VinaGerman.Views
{
    partial class frmCompanyManagement
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GridCompany = new DevExpress.XtraGrid.GridControl();
            this.gvCompany = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rspCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.bandedGridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(946, 55);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(296, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(347, 27);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Danh sách khách hàng - nhà cung cấp";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnDong);
            this.panelControl3.Controls.Add(this.btnLuu);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 355);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(946, 51);
            this.panelControl3.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(812, 9);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(77, 34);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(729, 9);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(77, 34);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.groupControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 55);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(946, 300);
            this.xtraScrollableControl1.TabIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Red;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.GridCompany);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(946, 300);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "F2: Copy dòng, F3: Xóa dòng";
            // 
            // GridCompany
            // 
            this.GridCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridCompany.Location = new System.Drawing.Point(2, 20);
            this.GridCompany.MainView = this.gvCompany;
            this.GridCompany.Name = "GridCompany";
            this.GridCompany.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rspCheck});
            this.GridCompany.Size = new System.Drawing.Size(942, 278);
            this.GridCompany.TabIndex = 0;
            this.GridCompany.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCompany});
            // 
            // gvCompany
            // 
            this.gvCompany.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.bandedGridColumn8,
            this.bandedGridColumn9});
            this.gvCompany.GridControl = this.GridCompany;
            this.gvCompany.Name = "gvCompany";
            this.gvCompany.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvCompany.OptionsView.ShowAutoFilterRow = true;
            this.gvCompany.OptionsView.ShowGroupPanel = false;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn1.Caption = "Mã CTY";
            this.bandedGridColumn1.FieldName = "CompanyCode";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.VisibleIndex = 0;
            this.bandedGridColumn1.Width = 215;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn2.Caption = "Tên CTY";
            this.bandedGridColumn2.FieldName = "Description";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.VisibleIndex = 1;
            this.bandedGridColumn2.Width = 240;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "ID";
            this.bandedGridColumn3.FieldName = "CompanyId";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.VisibleIndex = 2;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn4.Caption = "MST";
            this.bandedGridColumn4.FieldName = "TaxCode";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.VisibleIndex = 3;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn5.Caption = "Địa chỉ";
            this.bandedGridColumn5.FieldName = "Address";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.VisibleIndex = 4;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn6.Caption = "Điện thoại";
            this.bandedGridColumn6.FieldName = "Phone";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.VisibleIndex = 5;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn7.Caption = "Website";
            this.bandedGridColumn7.FieldName = "Website";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.VisibleIndex = 6;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn8.Caption = "Khách hàng";
            this.bandedGridColumn8.ColumnEdit = this.rspCheck;
            this.bandedGridColumn8.FieldName = "IsCustomer";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            this.bandedGridColumn8.VisibleIndex = 7;
            // 
            // rspCheck
            // 
            this.rspCheck.AutoHeight = false;
            this.rspCheck.Name = "rspCheck";
            // 
            // bandedGridColumn9
            // 
            this.bandedGridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.bandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridColumn9.Caption = "Nhà cung cấp";
            this.bandedGridColumn9.ColumnEdit = this.rspCheck;
            this.bandedGridColumn9.FieldName = "IsSupplier";
            this.bandedGridColumn9.Name = "bandedGridColumn9";
            this.bandedGridColumn9.Visible = true;
            this.bandedGridColumn9.VisibleIndex = 8;
            // 
            // frmCompanyManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 406);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmCompanyManagement";
            this.Text = "Danh sách khách hàng - nhà cung cấp";
            this.Load += new System.EventHandler(this.frmCompanyManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rspCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GridCompany;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rspCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCompany;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn bandedGridColumn9;
    }
}