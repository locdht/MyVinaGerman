namespace VinaGerman.Utilities
{
    partial class CustomMessageBoxForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBoxForm));
            this.lbMsg = new DevExpress.XtraEditors.LabelControl();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.btnViewDetails = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupSys = new DevExpress.XtraEditors.GroupControl();
            this.txtException = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSys)).BeginInit();
            this.groupSys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtException.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lbMsg.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbMsg.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbMsg.Location = new System.Drawing.Point(72, 12);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Padding = new System.Windows.Forms.Padding(3);
            this.lbMsg.Size = new System.Drawing.Size(443, 48);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "labelControl1";
            // 
            // pbIcon
            // 
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(12, 12);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(48, 48);
            this.pbIcon.TabIndex = 1;
            this.pbIcon.TabStop = false;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnViewDetails.Image")));
            this.btnViewDetails.Location = new System.Drawing.Point(95, 80);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 26);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "&Xem chi tiết >>";
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(14, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Đóng";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupSys
            // 
            this.groupSys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSys.AppearanceCaption.Font = new System.Drawing.Font("Candara", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupSys.AppearanceCaption.Options.UseFont = true;
            this.groupSys.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupSys.CaptionImage")));
            this.groupSys.Controls.Add(this.txtException);
            this.groupSys.Location = new System.Drawing.Point(12, 129);
            this.groupSys.Name = "groupSys";
            this.groupSys.Size = new System.Drawing.Size(500, 260);
            this.groupSys.TabIndex = 4;
            this.groupSys.Text = "Chi tiết lỗi hệ thống";
            // 
            // txtException
            // 
            this.txtException.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtException.Location = new System.Drawing.Point(2, 24);
            this.txtException.Name = "txtException";
            this.txtException.Properties.Appearance.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtException.Properties.Appearance.Options.UseFont = true;
            this.txtException.Properties.ReadOnly = true;
            this.txtException.Size = new System.Drawing.Size(496, 234);
            this.txtException.TabIndex = 0;
            this.txtException.UseOptimizedRendering = true;
            // 
            // CustomMessageBoxForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(527, 409);
            this.Controls.Add(this.groupSys);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.lbMsg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBoxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupSys)).EndInit();
            this.groupSys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtException.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbMsg;
        private System.Windows.Forms.PictureBox pbIcon;
        private DevExpress.XtraEditors.SimpleButton btnViewDetails;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupSys;
        private DevExpress.XtraEditors.MemoEdit txtException;
    }
}