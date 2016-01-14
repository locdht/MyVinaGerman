namespace VinaGerman.Views
{
    partial class frmPurchaseOrderManagement
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.GridPurchase = new DevExpress.XtraGrid.GridControl();
            this.gvPurchase = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsLKStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsHPLDel = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsHPOpen = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.rpsLoaiHang = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsLKStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsHPLDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsHPOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsLoaiHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.GridPurchase);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(737, 390);
            this.panelControl2.TabIndex = 1;
            // 
            // GridPurchase
            // 
            this.GridPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridPurchase.Location = new System.Drawing.Point(2, 2);
            this.GridPurchase.MainView = this.gvPurchase;
            this.GridPurchase.Name = "GridPurchase";
            this.GridPurchase.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsLoaiHang,
            this.rpsLKStatus,
            this.rpsHPLDel,
            this.rpsHPOpen});
            this.GridPurchase.Size = new System.Drawing.Size(733, 386);
            this.GridPurchase.TabIndex = 2;
            this.GridPurchase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPurchase});
            // 
            // gvPurchase
            // 
            this.gvPurchase.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn9,
            this.colOpen});
            this.gvPurchase.GridControl = this.GridPurchase;
            this.gvPurchase.Name = "gvPurchase";
            this.gvPurchase.OptionsView.ShowAutoFilterRow = true;
            this.gvPurchase.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Mã đơn đặt hàng";
            this.gridColumn1.FieldName = "OrderNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Tên công ty";
            this.gridColumn2.FieldName = "CustomerCompanyName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Chi nhánh";
            this.gridColumn3.FieldName = "LocationName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Lĩnh vực";
            this.gridColumn4.FieldName = "BusinessName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Nghành nghề";
            this.gridColumn5.FieldName = "IndustryName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Trạng thái";
            this.gridColumn8.ColumnEdit = this.rpsLKStatus;
            this.gridColumn8.FieldName = "OrderStatus";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // rpsLKStatus
            // 
            this.rpsLKStatus.AutoHeight = false;
            this.rpsLKStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpsLKStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Tình trạng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.rpsLKStatus.DisplayMember = "Ten";
            this.rpsLKStatus.Name = "rpsLKStatus";
            this.rpsLKStatus.NullText = "";
            this.rpsLKStatus.ValueMember = "Id";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "#";
            this.gridColumn9.ColumnEdit = this.rpsHPLDel;
            this.gridColumn9.FieldName = "OrderId";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // rpsHPLDel
            // 
            this.rpsHPLDel.Appearance.ForeColor = System.Drawing.Color.Red;
            this.rpsHPLDel.Appearance.Options.UseForeColor = true;
            this.rpsHPLDel.AutoHeight = false;
            this.rpsHPLDel.Caption = "Xóa";
            this.rpsHPLDel.Name = "rpsHPLDel";
            this.rpsHPLDel.Click += new System.EventHandler(this.rpsHPLDel_Click);
            // 
            // colOpen
            // 
            this.colOpen.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOpen.AppearanceCell.Options.UseFont = true;
            this.colOpen.AppearanceCell.Options.UseTextOptions = true;
            this.colOpen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOpen.Caption = "#";
            this.colOpen.ColumnEdit = this.rpsHPOpen;
            this.colOpen.FieldName = "OrderId";
            this.colOpen.Name = "colOpen";
            this.colOpen.Visible = true;
            this.colOpen.VisibleIndex = 7;
            // 
            // rpsHPOpen
            // 
            this.rpsHPOpen.Appearance.ForeColor = System.Drawing.Color.Red;
            this.rpsHPOpen.Appearance.Options.UseForeColor = true;
            this.rpsHPOpen.AutoHeight = false;
            this.rpsHPOpen.Caption = "Chi tiết";
            this.rpsHPOpen.Name = "rpsHPOpen";
            this.rpsHPOpen.Click += new System.EventHandler(this.rpsHPOpen_Click);
            // 
            // rpsLoaiHang
            // 
            this.rpsLoaiHang.AutoHeight = false;
            this.rpsLoaiHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpsLoaiHang.DisplayMember = "Description";
            this.rpsLoaiHang.Name = "rpsLoaiHang";
            this.rpsLoaiHang.NullText = "";
            this.rpsLoaiHang.ValueMember = "CategoryId";
            this.rpsLoaiHang.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ID";
            this.gridColumn6.FieldName = "CategoryId";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Loại hàng";
            this.gridColumn7.FieldName = "Description";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // frmPurchaseOrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 390);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmPurchaseOrderManagement";
            this.Text = "Danh sách  phiếu nhập hàng";
            this.Load += new System.EventHandler(this.frmPurchaseOrderManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsLKStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsHPLDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsHPOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsLoaiHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl GridPurchase;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPurchase;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpsLKStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpsHPLDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rpsLoaiHang;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rpsHPOpen;
        private DevExpress.XtraGrid.Columns.GridColumn colOpen;
    }
}