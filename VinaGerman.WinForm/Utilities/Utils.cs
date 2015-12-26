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

    public class Common
    {
        public static string ConvertToUpperFirst(string strText)
        {
            string temp = string.Empty;
            temp = strText[0].ToString().ToUpper();
            strText = temp + strText.Substring(1);
            return strText;
        }
        public static String ReadNumber(String sNumber)
        {
            String sRet = "";
            string s = sNumber;
            if (s != "")
            {
                s = xoasokhong(s);
                switch (s.Length)
                {
                    case 1: sRet = OneNumber(s) + " đồng"; break;
                    case 2: sRet = TwoNumber(s) + " đồng"; break;
                    case 3: sRet = ThreeNumber(s) + " đồng"; break;
                    default: sRet = MultiNumber(s, s.Length); break;
                }
            }
            else sRet = "Bạn phải nhập giá trị vào";

            return sRet;
        }
        public static string xoasokhong(string tam)
        {
            while (tam[0] == '0')
            {
                if (tam.Length > 1) tam = tam.Substring(1, tam.Length - 1);
                else break;
            }
            return tam;
        }
        public static string OneNumber(string s)
        {
            switch (s)
            {
                case "0": return "không";
                case "1": return "một";
                case "2": return "hai";
                case "3": return "ba";
                case "4": return "bốn";
                case "5": return "năm";
                case "6": return "sáu";
                case "7": return "bảy";
                case "8": return "tám";
                case "9": return "chín";
            }
            return "không";
        }
        public static string TwoNumber(string bienso)
        {
            string biendoc = " mười ";
            if ((bienso.Substring(1, 1) == "0") && (bienso.Substring(0, 1) != "1")) biendoc = OneNumber(bienso.Substring(0, 1)) + " mươi ";
            if (bienso.Substring(1, 1) != "0")
                switch (bienso.Substring(1, 1))
                {
                    case "5":
                        if (bienso.Substring(0, 1) == "1") biendoc = " mười lăm";
                        else biendoc = OneNumber(bienso.Substring(0, 1)) + " mươi lăm";
                        break;
                    case "1":
                        if (bienso.Substring(0, 1) == "1") biendoc = " mười một";
                        else biendoc = OneNumber(bienso.Substring(0, 1)) + " mươi mốt";
                        break;
                    default:
                        if (bienso.Substring(0, 1) == "1") biendoc = " mười " + OneNumber(bienso.Substring(1, 1));
                        else biendoc = OneNumber(bienso.Substring(0, 1)) + " mươi " + OneNumber(bienso.Substring(1, 1));
                        break;
                }

            return biendoc;
        }
        public static string ThreeNumber(string bienso)
        {
            string biendoc = "trăm";
            if (bienso.Substring(1, 1) == "0")
            {
                if (bienso.Substring(2, 1) == "0") biendoc = OneNumber(bienso.Substring(0, 1)) + " trăm ";
                else biendoc = OneNumber(bienso.Substring(0, 1)) + " trăm lẻ " + OneNumber(bienso.Substring(2, 1));
            }
            else
            {
                biendoc = OneNumber(bienso.Substring(0, 1)) + " trăm " + TwoNumber(bienso.Substring(1, 2));
            }
            return biendoc;
        }
        public static string MultiNumber(string bienso, int dodai)
        {
            string biendoc = "", bientam = "";
            int i = 0;
            while ((dodai) > 3)
            {

                bientam = ThreeNumber(bienso.Substring(bienso.Length - 3, 3));
                bienso = bienso.Substring(0, bienso.Length - 3);
                biendoc = bientam + kieuchen(i) + biendoc;
                i++;
                if (i > 3) i = 1;
                if (dodai > 3) dodai = dodai - 3;
            }
            if (dodai == 1) biendoc = OneNumber(bienso) + kieuchen(i) + biendoc;
            if (dodai == 2) biendoc = TwoNumber(bienso) + kieuchen(i) + biendoc;
            if (dodai == 3) biendoc = ThreeNumber(bienso) + kieuchen(i) + biendoc;
            return biendoc;
        }
        public static string kieuchen(int tam)
        {
            switch (tam)
            {
                case 0: return " đồng ";
                case 1: return " nghìn ";
                case 2: return " triệu ";
                case 3: return " tỷ ";
            }
            return "";
        }
    }

}
