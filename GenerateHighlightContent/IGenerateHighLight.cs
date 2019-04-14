using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GenerateHighlightContent
{
    public interface IGenerateHighLight
    {
        /// <summary> 產生HighLight Code </summary>
        /// <returns> 產出的檔案路徑 </returns>
        string GenerateHighLightCode(HighLightParameter parameter);
    }

    public class HighLightParameter
    {
        /// <summary> 內容 </summary>
        public string Content { get; set; }

        /// <summary> 語法類型 </summary>
        public string CodeType { get; set; }

        /// <summary> 高亮樣式 </summary>
        public string HighLightStyle { get; set; }

        /// <summary> 是否顯示行號 </summary>
        public bool ShowLineNumber { get; set; }

        /// <summary> 檔案名稱 </summary>
        public string FileName { get; set; }

        public Color HighlightColor { get; set; }

        public string Font { get; set; }

        public int FontSize { get; set; }
    }
}
