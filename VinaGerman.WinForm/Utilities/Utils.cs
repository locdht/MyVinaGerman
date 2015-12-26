using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaGerman.Utilities
{
    public enum MessageBoxConfirmType
    {
        YesNo,
        YesNoCancel
    }
    public static class Utils
    {
        #region MessageBox

        /// <summary>
        /// MessageBox.Show() replacement.
        /// </summary>
        public static void ShowMsg(string msg)
        {
            XMsgBox(null, msg, false);
        }

        /// <summary>
        /// MessageBox.Show() replacement.
        /// </summary>
        public static void ShowError(string error, Exception ex = null)
        {
            //XMsgBox(null, error, true);
            CustomMessageBox.ShowError(error, "Thông báo", ex);
        }

        ///// <summary>
        ///// MessageBox.Show() replacement.
        ///// </summary>
        //public static void ShowErrorWithOwner(IWin32Window owner, string error)
        //{
        //    XMsgBox(owner, error, true);
        //}

        private static void XMsgBox(IWin32Window owner, string msg, bool error)
        {
            DialogResult[] buttons = { DialogResult.OK };
            Icon ico = error ? Global.WarningIcon : Global.InfoIcon;
            MessageBoxIcon beep = error ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information;

            //var feel = new UserLookAndFeel(owner);
            //feel.SetSkinStyle(Config.Skin);

            var feel = UserLookAndFeel.Default;

            Action action = () => XtraMessageBox.Show(feel, owner, msg, "Thông báo", buttons, ico, 0, beep);

            if (owner is Control)
            {
                var ctrl = owner as Control;
                if (ctrl.InvokeRequired)
                {
                    ctrl.Invoke(action);
                    return;
                }
            }

            action();
        }

        /// <summary>
        /// Show user-confirm message box.
        /// </summary>
        public static DialogResult ShowConfirmMsg(string msg, MessageBoxConfirmType type)
        {
            return ShowConfirmMsg(null, msg, type);
        }

        /// <summary>
        /// Show user-confirm message box with owner.
        /// </summary>
        public static DialogResult ShowConfirmMsg(IWin32Window owner, string msg, MessageBoxConfirmType type)
        {
            DialogResult[] buttons =
                type == MessageBoxConfirmType.YesNoCancel ?
                new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel } :
                new DialogResult[] { DialogResult.Yes, DialogResult.No };

            Icon ico = Global.QuestionIcon;
            const MessageBoxIcon beep = MessageBoxIcon.Question;

            //UserLookAndFeel feel = new UserLookAndFeel(owner);
            //feel.SetSkinStyle(Config.Skin);

            var feel = UserLookAndFeel.Default;

            return XtraMessageBox.Show(feel, owner, msg, "Thông báo", buttons, ico, 0, beep);
        }

        #endregion
    }
}
