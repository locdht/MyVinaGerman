using DevExpress.Utils.Text;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VinaGerman.Utilities
{
    internal partial class CustomMessageBoxForm : DevExpress.XtraEditors.XtraForm
    {
        const int WND_CTRL_GAP = 12;
        const int BUTTON_GAP = 6;

        const int LABEL_PADDING_BOTTOM = 8;
        const int LABEL_PADDING_RIGHT = 10;
        const int LABEL_MAX_W = 550;
        const int LABEL_MIN_W = 150;
        const int LABEL_MIN_H = 48;

        const int LABEL_BUTTON_GAP = 22;
        const int BUTTON_GROUP_GAP = 25;

        public string Message { get; private set; }
        public string Caption { get; private set; }
        public Exception SystemException { get; private set; }

        public CustomMessageBoxForm(string text, string caption, Exception ex)
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

            Message = text;
            Caption = caption;
            SystemException = ex;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Text = Caption;
            lbMsg.Text = Message;

            btnViewDetails.Enabled = (this.SystemException != null);
            if (this.SystemException != null)
            {
                txtException.Text = GetExceptionMessage(this.SystemException);
            }


            // get text size
            Size sz = GetTextSize(this.CreateGraphics(), lbMsg.Appearance.Font, this.Message, LABEL_MAX_W);

            // label height
            if (sz.Height <= LABEL_MIN_H) // nếu text chứa vừa trong label hiện tại
            {
                lbMsg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
                lbMsg.Appearance.Options.UseTextOptions = true;
            }
            else // tăng chiều cao label cho phù hợp với text
            {
                lbMsg.Height = sz.Height + LABEL_PADDING_BOTTOM;
            }

            // label width
            int label_W = LABEL_MIN_W;
            if (sz.Width > label_W) label_W = sz.Width + LABEL_PADDING_RIGHT;
            if (label_W > LABEL_MAX_W) label_W = LABEL_MAX_W;

            lbMsg.Width = label_W;

            // window width
            int window_W = lbMsg.Left + label_W + WND_CTRL_GAP;

            // buttons location

            //int lbBottom = lbMsg.Top + lbMsg.Height;
            //int pbBottom = pbIcon.Top + pbIcon.Height;
            //int buttonsTop = (pbBottom < lbBottom ? lbBottom : pbBottom) + LABEL_BUTTON_GAP;
            int buttonsTop = lbMsg.Top + lbMsg.Height + LABEL_BUTTON_GAP;
            btnOK.Top = btnViewDetails.Top = buttonsTop;

            //int center_X = window_W / 2;
            btnOK.Left = (window_W - (btnOK.Width + BUTTON_GAP + btnViewDetails.Width)) / 2;
            btnViewDetails.Left = btnOK.Left + btnOK.Width + BUTTON_GAP;

            // group location
            groupSys.Top = buttonsTop + btnOK.Height + BUTTON_GROUP_GAP;

            // window size
            int window_H = groupSys.Top;
            this.ClientSize = new Size(window_W, window_H);

            SetWindowLocation();
        }

        //protected override void OnResizeBegin(EventArgs e)
        //{
        //    this.SuspendLayout();
        //    base.OnResizeBegin(e);
        //}

        //protected override void OnResizeEnd(EventArgs e)
        //{
        //    this.ResumeLayout();
        //    base.OnResizeEnd(e);
        //}

        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);
        //    this.Update();
        //}

        private static Size GetTextSize(Graphics g, Font font, string text, int maxWidth)
        {
            return TextUtils.GetStringSize(g, text, font, new StringFormat(), maxWidth);
        }

        bool showDetails = false;

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            int clientH = groupSys.Top;

            if (!showDetails)
            {
                btnViewDetails.Text = "Ẩn chi tiết <<";

                groupSys.Height = 260;
                groupSys.Top = btnOK.Top + btnOK.Height + BUTTON_GROUP_GAP;

                clientH += groupSys.Height + WND_CTRL_GAP;
            }
            else
            {
                btnViewDetails.Text = "&Hiện chi tiết >>";
            }

            // window size
            this.ClientSize = new Size(this.ClientSize.Width, clientH);
            SetWindowLocation();

            showDetails = !showDetails;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Set window top, left.
        /// </summary>
        private void SetWindowLocation()
        {
            int window_L = (Screen.FromControl(this).Bounds.Width - this.Width) / 2;
            int window_T = (Screen.FromControl(this).Bounds.Height - this.Height) / 2;
            this.Location = new Point(window_L, window_T);
        }

        private static string GetExceptionMessage(Exception ex)
        {
            StringBuilder builder = new StringBuilder();

            Exception cur = ex;
            int level = 0;

            while (cur != null)
            {
                builder.Append(string.Empty.PadRight(level * 5, '-'));
                if (level > 0) 
                    builder.Append(" ");

                builder.AppendLine(cur.Message);

                cur = cur.InnerException;
                level++;
            }

            return builder.ToString();
        }
    }
}