using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Helper
{
    public static class StringExtension
    {
        public static string TemplateSubstitute(this string input, object data)
        {
            var type = data.GetType();
            return Regex.Replace(input, @"\{(\w+)\}", m =>
            {
                var name = m.Groups[1].Value;
                var prop = type.GetProperty(name);
                if (prop != null)
                {
                    // 找到屬性，傳回屬性值執行字串替換
                    return prop.GetValue(data, null).ToString();
                }
                else
                {
                    // 在物件中找不到符合名稱的屬性，回傳原值不處理
                    return m.Value;
                }
            });
        }
    }
}
