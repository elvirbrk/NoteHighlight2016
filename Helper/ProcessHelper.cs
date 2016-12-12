using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Helper
{
    public class ProcessHelper
    {
        #region -- Field and Property --

        public string WorkingDirectory { get; set; }

        public string FileName { get; set; }

        public string Arguments { get; set; }

        public bool IsWaitForInputIdle { get; set; }

        public ProcessWindowStyle WindowStyle { get; set; }

        /// <summary>
        /// 取得組件所在路徑
        /// Get Assembly Location
        /// </summary>
        public static string GetAssemblyLocationDirectory
        {
            get
            {
                string assemblyDirectory = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                return assemblyDirectory;
            }
        }


        #endregion

        #region -- Constructor --

        public ProcessHelper(string fileName):this(GetAssemblyLocationDirectory,fileName){}

        public ProcessHelper(string workingDirectory, string fileName)
        {
            WorkingDirectory = workingDirectory;
            FileName = fileName;
        }

        public ProcessHelper(string fileName, string[] arguments): this(GetAssemblyLocationDirectory, fileName, arguments){}

        public ProcessHelper(string workingDirectory, string fileName,string[] arguments)
        {
            WorkingDirectory = workingDirectory;
            FileName = fileName;
            Arguments = String.Join(" ", arguments);
        }

        #endregion

        public void ProcessStart()
        {
            using (Process p = new Process())
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.WorkingDirectory = WorkingDirectory;
                info.FileName = FileName;
                info.Arguments = Arguments;
                info.WindowStyle = WindowStyle;
                
                p.StartInfo = info;

                p.Start();
                if (IsWaitForInputIdle) p.WaitForInputIdle();
                if (!p.HasExited) p.WaitForExit();
            }
        }


        public static string GetDirectoryFromPath(string path)
        {
            string assemblyDirectory = Path.GetDirectoryName(path);
            return assemblyDirectory;

        }
    }
}
