using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinaGerman.Utilities
{
    public class Log
    {
        //System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
        public static void WriteLog(string snameprogram, object sCls, string MethodName, string strError)
        {
            try
            {
                string sDrive = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf(":"));
                if (snameprogram == null)
                    snameprogram = Application.ProductName;
                string sfile = DateTime.Now.ToString("yyyyMMdd") + "Log.log";
                if (snameprogram.ToLower() == "kyso")
                    snameprogram = "KySoDesktop";
                string sPath = Application.StartupPath + "\\Log";
                DirectoryInfo direc = new DirectoryInfo(sPath);
                if (!direc.Exists)
                    direc.Create();
                sPath = sPath + "\\" + sfile;

                StreamWriter log;

                if (!File.Exists(sPath))
                    log = new StreamWriter(sPath);
                else
                    log = File.AppendText(sPath);
                // Write to the file:
                string sCName = sCls.GetType().ToString();
                log.WriteLine("**************************Class==>" + sCName + "*************************");
                log.WriteLine("Time==>" + DateTime.Now);
                log.WriteLine("Method==>" + MethodName);
                log.WriteLine("Error msg==>" + strError);
                log.WriteLine();
                // Close the stream:
                log.Close();
            }
            catch { }
        }
        public static void WriteLog(object sCls, string MethodName, string strError)
        {
            try
            {
                string sDrive = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf(":"));

                string sname = Application.ProductName;
                string sfile = DateTime.Now.ToString("yyyyMMdd") + "Log.log";
                if (sname.ToLower() == "kyso")
                    sname = "KySoDesktop";
                string sPath = Application.StartupPath + "\\Log";
                DirectoryInfo direc = new DirectoryInfo(sPath);
                if (!direc.Exists)
                    direc.Create();
                sPath = sPath + "\\" + sfile;

                StreamWriter log;

                if (!File.Exists(sPath))
                    log = new StreamWriter(sPath);
                else
                    log = File.AppendText(sPath);
                // Write to the file:
                string sCName = sCls.GetType().ToString();
                log.WriteLine("**************************Class==>" + sCName + "*************************");
                log.WriteLine("Time==>" + DateTime.Now);
                log.WriteLine("Method==>" + MethodName);
                log.WriteLine("Error msg==>" + strError);
                log.WriteLine();
                // Close the stream:
                log.Close();
            }
            catch { }
        }
        public static void WriteLog(string MethodName, string strError)
        {
            try
            {
                string sDrive = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf(":"));
                string sname = Application.ProductName;
                if (sname.ToLower() == "kyso")
                    sname = "KySoDesktop";
                string sfile = DateTime.Now.ToString("yyyyMMdd") + "Log.log";
                string sPath = Application.StartupPath + "\\Log";
                DirectoryInfo direc = new DirectoryInfo(sPath);
                if (!direc.Exists)
                    direc.Create();
                sPath = sPath + "\\" + sfile;

                StreamWriter log;

                if (!File.Exists(sPath))
                    log = new StreamWriter(sPath);
                else
                    log = File.AppendText(sPath);

                // Write to the file:
                string sCName = "UnKnown Class";
                log.WriteLine("**************************Class==>" + sCName + "*************************");
                log.WriteLine("Time==>" + DateTime.Now);
                log.WriteLine("Method==>" + MethodName);
                log.WriteLine("Error msg==>" + strError);
                log.WriteLine();
                // Close the stream:
                log.Close();
            }
            catch { }
        }
        public static void WriteLog(Exception e)
        {
            try
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(e, true);
                StackFrame stf = trace.GetFrame(0);
                string sCName = ((System.Reflection.MemberInfo)(stf.GetMethod())).DeclaringType.FullName;
                string MethodName = stf.GetMethod().Name;
                int ix = stf.GetFileLineNumber();
                string sDrive = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf(":"));
                string sname = Application.ProductName;
                string sfile = DateTime.Now.ToString("yyyyMMdd") + "Log.log";
                if (sname.ToLower() == "kyso")
                    sname = "KySoDesktop";
                string sPath = Application.StartupPath + "\\Log";
                DirectoryInfo direc = new DirectoryInfo(sPath);
                if (!direc.Exists)
                    direc.Create();
                sPath = sPath + "\\" + sfile;

                StreamWriter log;

                if (!File.Exists(sPath))
                    log = new StreamWriter(sPath);
                else
                    log = File.AppendText(sPath);

                // Write to the file:
                string strError = e.Message;
                log.WriteLine("**************************Class==>" + sCName + "*************************");
                log.WriteLine("Time==>" + DateTime.Now);
                log.WriteLine("Method==>" + MethodName);
                log.WriteLine("Error msg==> Line number: " + ix.ToString() + ", Error excuting: " + strError);
                log.WriteLine();
                // Close the stream:
                log.Close();
            }
            catch { }
        }
    }
}
