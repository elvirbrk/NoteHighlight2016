using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoteHighLightForm
{
    public class HtmlFragment
    {
        static string To8DigitString(int x)
        {
            return String.Format("{0,8}", x);
        }

        public static void CopyToClipboard(string htmlFragment)
        {
            CopyToClipboard(htmlFragment, null, null);
        }

        public static void CopyToClipboard(string htmlFragment, string title, Uri sourceUrl)
        {
            if (title == null) title = "From Clipboard";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            string header =
                            @"Format:HTML Format
                            Version:1.0
                            StartHTML:<<<<<<<1
                            EndHTML:<<<<<<<2
                            StartFragment:<<<<<<<3
                            EndFragment:<<<<<<<4
                            StartSelection:<<<<<<<3
                            EndSelection:<<<<<<<3
                            ";

            string pre =
                    @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">
                    <HTML><HEAD><TITLE>" + title + @"</TITLE>
                    <meta http-equiv=""content-type"" content=""text/html; charset=" + Encoding.UTF8.WebName + @""" />
                    </HEAD><BODY><!--StartFragment-->";

            string post = @"<!--EndFragment--></BODY></HTML>";

            sb.Append(header);
            if (sourceUrl != null)
            {
                sb.AppendFormat("SourceURL:{0}", sourceUrl);
            }
            int startHTML = sb.Length;

            sb.Append(pre);
            int fragmentStart = sb.Length;

            sb.Append(htmlFragment);
            int fragmentEnd = sb.Length;

            sb.Append(post);
            int endHTML = sb.Length;

            // Backpatch offsets
            sb.Replace("<<<<<<<1", To8DigitString(startHTML));
            sb.Replace("<<<<<<<2", To8DigitString(endHTML));
            sb.Replace("<<<<<<<3", To8DigitString(fragmentStart));
            sb.Replace("<<<<<<<4", To8DigitString(fragmentEnd));

            // Finally copy to clipboard.
            Clipboard.Clear();
            DataObject obj = new DataObject();
            obj.SetData(DataFormats.Html, new System.IO.MemoryStream(Encoding.UTF8.GetBytes(sb.ToString())));
            Clipboard.SetDataObject(obj, true);
        }
    }
}
