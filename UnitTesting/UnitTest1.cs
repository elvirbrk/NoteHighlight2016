using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoteHighlightAddin;
using GenerateHighlightContent;
using System.Xml.Linq;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string htmlCode = "";
            string[] pos = new string[] { "", "" };
            HighLightParameter param = new HighLightParameter();
            XElement outline = new XElement("");
            

            AddIn addIn = new AddIn();

            addIn.InsertHighLightCode(htmlCode, pos, param, outline, false, false);
        }
    }
}
