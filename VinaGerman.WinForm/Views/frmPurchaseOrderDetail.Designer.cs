namespace VinaGerman.Views
{
    partial class frmPurchaseOrderDetail
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.ChildGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChildArticleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryArticleLookupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colChildQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemoveLoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.DataGrid = new DevExpress.XtraGrid.GridControl();
            this.MasterGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasterArticleNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRealQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterPayDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepositoryDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colRemoveOrderline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.cboEmployee = new DevExpress.XtraEditors.LookUpEdit();
            this.cboStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.cboArea = new DevExpress.XtraEditors.LookUpEdit();
            this.cboIndustry = new DevExpress.XtraEditors.LookUpEdit();
            this.cboBusiness = new DevExpress.XtraEditors.LookUpEdit();
            this.cboCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.txtOrderDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOrderNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ChildGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryArticleLookupEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryDateEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIndustry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusiness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ChildGridView
            // 
            this.ChildGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChildArticleNo,
            this.colChildQuantity,
            this.colRemoveLoan});
            this.ChildGridView.GridControl = this.DataGrid;
            this.ChildGridView.Name = "ChildGridView";
            this.ChildGridView.OptionsBehavior.AutoPopulateColumns = false;
            this.ChildGridView.OptionsDetail.ShowDetailTabs = false;
            this.ChildGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.ChildGridView.OptionsView.ShowGroupPanel = false;
            this.ChildGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.ChildGridView_CellValueChanged);
            // 
            // colChildArticleNo
            // 
            this.colChildArticleNo.Caption = "Hàng hóa";
            this.colChildArticleNo.ColumnEdit = this.RepositoryArticleLookupEdit;
            this.colChildArticleNo.FieldName = "ArticleId";
            this.colChildArticleNo.Name = "colChildArticleNo";
            this.colChildArticleNo.Visible = true;
            this.colChildArticleNo.VisibleIndex = 0;
            // 
            // RepositoryArticleLookupEdit
            // 
            this.RepositoryArticleLookupEdit.AutoHeight = false;
            this.RepositoryArticleLookupEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryArticleLookupEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ArticleNo", "Mã hàng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Miêu tả"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit", "Đơn vị")});
            this.RepositoryArticleLookupEdit.DisplayMember = "Description";
            this.RepositoryArticleLookupEdit.ImmediatePopup = true;
            this.RepositoryArticleLookupEdit.Name = "RepositoryArticleLookupEdit";
            this.RepositoryArticleLookupEdit.NullText = "";
            this.RepositoryArticleLookupEdit.ValueMember = "ArticleId";
            this.RepositoryArticleLookupEdit.EditValueChanged += new System.EventHandler(this.RepositoryArticleLookupEdit_EditValueChanged);
            // 
            // colChildQuantity
            // 
            this.colChildQuantity.Caption = "Số lượng";
            this.colChildQuantity.FieldName = "Quantity";
            this.colChildQuantity.Name = "colChildQuantity";
            this.colChildQuantity.Visible = true;
            this.colChildQuantity.VisibleIndex = 1;
            // 
            // colRemoveLoan
            // 
            this.colRemoveLoan.Caption = "Delete";
            this.colRemoveLoan.ColumnEdit = this.RepositoryButtonEdit;
            this.colRemoveLoan.Name = "colRemoveLoan";
            this.colRemoveLoan.OptionsColumn.AllowSize = false;
            this.colRemoveLoan.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRemoveLoan.Visible = true;
            this.colRemoveLoan.VisibleIndex = 2;
            this.colRemoveLoan.Width = 20;
            // 
            // RepositoryButtonEdit
            // 
            this.RepositoryButtonEdit.AutoHeight = false;
            this.RepositoryButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::VinaGerman.Properties.Resources.remove, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.RepositoryButtonEdit.Name = "RepositoryButtonEdit";
            this.RepositoryButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.RepositoryButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.RepositoryButtonEdit_ButtonClick);
            // 
            // DataGrid
            // 
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.ChildGridView;
            gridLevelNode1.RelationName = "ChildView";
            this.DataGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.DataGrid.Location = new System.Drawing.Point(0, 154);
            this.DataGrid.MainView = this.MasterGridView;
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RepositoryArticleLookupEdit,
            this.RepositoryDateEdit,
            this.RepositoryButtonEdit});
            this.DataGrid.Size = new System.Drawing.Size(870, 407);
            this.DataGrid.TabIndex = 2;
            this.DataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.MasterGridView,
            this.ChildGridView});
            // 
            // MasterGridView
            // 
            this.MasterGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasterArticleNo,
            this.colMasterQuantity,
            this.colRealQuantity,
            this.colMasterPrice,
            this.colMasterPayDate,
            this.colRemoveOrderline});
            this.MasterGridView.GridControl = this.DataGrid;
            this.MasterGridView.Name = "MasterGridView";
            this.MasterGridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.MasterGridView.OptionsBehavior.AutoPopulateColumns = false;
            this.MasterGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.MasterGridView.OptionsDetail.ShowDetailTabs = false;
            this.MasterGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.MasterGridView.OptionsView.ShowGroupPanel = false;
            this.MasterGridView.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.MasterGridView_MasterRowGetRelationName);
            this.MasterGridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.MasterGridView_RowUpdated);
            // 
            // colMasterArticleNo
            // 
            this.colMasterArticleNo.Caption = "Hàng hóa";
            this.colMasterArticleNo.ColumnEdit = this.RepositoryArticleLookupEdit;
            this.colMasterArticleNo.FieldName = "ArticleId";
            this.colMasterArticleNo.Name = "colMasterArticleNo";
            this.colMasterArticleNo.Visible = true;
            this.colMasterArticleNo.VisibleIndex = 0;
            this.colMasterArticleNo.Width = 142;
            // 
            // colMasterQuantity
            // 
            this.colMasterQuantity.Caption = "Số lượng chứng từ";
            this.colMasterQuantity.FieldName = "Quantity";
            this.colMasterQuantity.Name = "colMasterQuantity";
            this.colMasterQuantity.Visible = true;
            this.colMasterQuantity.VisibleIndex = 1;
            this.colMasterQuantity.Width = 142;
            // 
            // colRealQuantity
            // 
            this.colRealQuantity.Caption = "Số lượng thực";
            this.colRealQuantity.FieldName = "RealQuantity";
            this.colRealQuantity.Name = "colRealQuantity";
            this.colRealQuantity.Visible = true;
            this.colRealQuantity.VisibleIndex = 2;
            this.colRealQuantity.Width = 142;
            // 
            // colMasterPrice
            // 
            this.colMasterPrice.Caption = "Giá";
            this.colMasterPrice.FieldName = "Price";
            this.colMasterPrice.Name = "colMasterPrice";
            this.colMasterPrice.Visible = true;
            this.colMasterPrice.VisibleIndex = 3;
            this.colMasterPrice.Width = 142;
            // 
            // colMasterPayDate
            // 
            this.colMasterPayDate.Caption = "Ngày thanh toán";
            this.colMasterPayDate.ColumnEdit = this.RepositoryDateEdit;
            this.colMasterPayDate.FieldName = "PayDate";
            this.colMasterPayDate.Name = "colMasterPayDate";
            this.colMasterPayDate.Visible = true;
            this.colMasterPayDate.VisibleIndex = 4;
            this.colMasterPayDate.Width = 142;
            // 
            // RepositoryDateEdit
            // 
            this.RepositoryDateEdit.AutoHeight = false;
            this.RepositoryDateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryDateEdit.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepositoryDateEdit.Name = "RepositoryDateEdit";
            // 
            // colRemoveOrderline
            // 
            this.colRemoveOrderline.Caption = "Delete";
            this.colRemoveOrderline.ColumnEdit = this.RepositoryButtonEdit;
            this.colRemoveOrderline.Name = "colRemoveOrderline";
            this.colRemoveOrderline.Visible = true;
            this.colRemoveOrderline.VisibleIndex = 5;
            this.colRemoveOrderline.Width = 25;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnPrint);
            this.groupControl2.Controls.Add(this.btnClose);
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Controls.Add(this.cboEmployee);
            this.groupControl2.Controls.Add(this.cboStatus);
            this.groupControl2.Controls.Add(this.cboArea);
            this.groupControl2.Controls.Add(this.cboIndustry);
            this.groupControl2.Controls.Add(this.cboBusiness);
            this.groupControl2.Controls.Add(this.cboCustomer);
            this.groupControl2.Controls.Add(this.txtOrderDate);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.txtOrderNumber);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(870, 154);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Thông tin phiếu nhập hàng";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(756, 111);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "In ấn";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(756, 62);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(756, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboEmployee
            // 
            this.cboEmployee.Location = new System.Drawing.Point(133, 118);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmployee.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Họ Tên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Phone", "Điện thoại")});
            this.cboEmployee.Properties.DisplayMember = "FullName";
            this.cboEmployee.Properties.NullText = "Chọn nhân viên";
            this.cboEmployee.Properties.ReadOnly = true;
            this.cboEmployee.Properties.ValueMember = "ContactId";
            this.cboEmployee.Size = new System.Drawing.Size(209, 20);
            this.cboEmployee.TabIndex = 8;
            // 
            // cboStatus
            // 
            this.cboStatus.Location = new System.Drawing.Point(467, 118);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Trạng thái")});
            this.cboStatus.Properties.DisplayMember = "Value";
            this.cboStatus.Properties.NullText = "Trạng thái";
            this.cboStatus.Properties.ValueMember = "Key";
            this.cboStatus.Size = new System.Drawing.Size(209, 20);
            this.cboStatus.TabIndex = 8;
            // 
            // cboArea
            // 
            this.cboArea.Location = new System.Drawing.Point(467, 89);
            this.cboArea.Name = "cboArea";
            this.cboArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArea.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Tên khách hàng")});
            this.cboArea.Properties.DisplayMember = "Description";
            this.cboArea.Properties.NullText = "Nhập vùng khách hàng";
            this.cboArea.Properties.ValueMember = "AreaId";
            this.cboArea.Size = new System.Drawing.Size(209, 20);
            this.cboArea.TabIndex = 8;
            // 
            // cboIndustry
            // 
            this.cboIndustry.Location = new System.Drawing.Point(467, 59);
            this.cboIndustry.Name = "cboIndustry";
            this.cboIndustry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboIndustry.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Tên khách hàng")});
            this.cboIndustry.Properties.DisplayMember = "Description";
            this.cboIndustry.Properties.NullText = "Nhập ngành nghề";
            this.cboIndustry.Properties.ValueMember = "IndustryId";
            this.cboIndustry.Size = new System.Drawing.Size(209, 20);
            this.cboIndustry.TabIndex = 8;
            // 
            // cboBusiness
            // 
            this.cboBusiness.Location = new System.Drawing.Point(467, 30);
            this.cboBusiness.Name = "cboBusiness";
            this.cboBusiness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBusiness.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Tên khách hàng")});
            this.cboBusiness.Properties.DisplayMember = "Description";
            this.cboBusiness.Properties.NullText = "Nhập lĩnh vực";
            this.cboBusiness.Properties.ValueMember = "BusinessId";
            this.cboBusiness.Size = new System.Drawing.Size(209, 20);
            this.cboBusiness.TabIndex = 8;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Location = new System.Drawing.Point(133, 89);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyCode", "Mã khách hàng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Tên khách hàng"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Phone", "Điện thoại"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TaxCode", "Mã số thuế")});
            this.cboCustomer.Properties.DisplayMember = "Description";
            this.cboCustomer.Properties.NullText = "Nhập mã khách hàng";
            this.cboCustomer.Properties.ValueMember = "CompanyId";
            this.cboCustomer.Size = new System.Drawing.Size(209, 20);
            this.cboCustomer.TabIndex = 8;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.EditValue = null;
            this.txtOrderDate.Location = new System.Drawing.Point(133, 59);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOrderDate.Size = new System.Drawing.Size(209, 20);
            this.txtOrderDate.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(369, 121);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(53, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Trạng thái:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(369, 92);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(86, 13);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Vùng khách hàng:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(369, 62);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Ngành nghề:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(369, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Lĩnh vực:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(19, 121);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 13);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Nhân viên:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(19, 92);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Khách hàng:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ngày nhập:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Enabled = false;
            this.txtOrderNumber.Location = new System.Drawing.Point(133, 30);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(209, 20);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số phiếu nhập:";
            // 
            // frmPurchaseOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 561);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.groupControl2);
            this.Name = "frmPurchaseOrderDetail";
            this.Text = "Phiếu nhập hàng";
            this.Shown += new System.EventHandler(this.frmPurchaseOrderDetail_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ChildGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryArticleLookupEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepositoryDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIndustry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBusiness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtOrderNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.GridControl DataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView MasterGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView ChildGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colChildArticleNo;
        private DevExpress.XtraGrid.Columns.GridColumn colChildQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterArticleNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepositoryArticleLookupEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterPayDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit RepositoryDateEdit;
        private DevExpress.XtraEditors.DateEdit txtOrderDate;
        private DevExpress.XtraEditors.LookUpEdit cboCustomer;
        private DevExpress.XtraEditors.LookUpEdit cboEmployee;
        private DevExpress.XtraEditors.LookUpEdit cboArea;
        private DevExpress.XtraEditors.LookUpEdit cboIndustry;
        private DevExpress.XtraEditors.LookUpEdit cboBusiness;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LookUpEdit cboStatus;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn colRealQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colRemoveLoan;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit RepositoryButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colRemoveOrderline;
    }
}