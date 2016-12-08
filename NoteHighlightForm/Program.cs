using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoteHighLightForm
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (args.Length != 2)
                throw new ArgumentException("This Form only accepts two parameters, the first of CodeType, the second to FileName.");
            
            var codeType = args[0];
            var fileName = args[1];
            CodeForm form = new CodeForm(codeType, fileName);
            Application.Run(form);
        }
    }
}
