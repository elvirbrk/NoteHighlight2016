using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoteHighlightAddin;
using GenerateHighlightContent;
using System.Xml.Linq;
using System.Configuration;
using System.Linq;

namespace UnitTesting
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void FormatNewCode()
        {
            string htmlCode = Resource1.HTMLContent1;
            string[] pos = new string[] { "198.0", "950.3999633789062" };
            HighLightParameter param = new HighLightParameter();
            param.ShowLineNumber = true;
            param.HighlightColor = System.Drawing.Color.FromArgb(240, 240, 240);
            XElement outline = null;


            AddIn addIn = new AddIn();
            addIn.ns = @"http://schemas.microsoft.com/office/onenote/2013/onenote";


            //Arrange
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "Test.config" };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            HighLightSection config = configuration.GetSection("HighLightSection") as HighLightSection;


            XDocument output = addIn.InsertHighLightCode(htmlCode, pos, param, outline, config, false, false);

            Assert.AreEqual(Resource1.Output1, output.ToString(), false);
        }

        [TestMethod]
        public void FormatSelectedCode_AllSelected()
        {
            string htmlCode = Resource1.HTMLContent2;
            string[] pos = null;
            HighLightParameter param = new HighLightParameter();
            param.ShowLineNumber = true;
            param.HighlightColor = System.Drawing.Color.FromArgb(240, 240, 240);


            AddIn addIn = new AddIn();
            addIn.ns = @"http://schemas.microsoft.com/office/onenote/2013/onenote";

            var outline = XDocument.Parse(Resource1.Page2).Descendants(addIn.ns + "Outline")
                                   .Where(n => n.Attribute("selected") != null && (n.Attribute("selected").Value == "all" || n.Attribute("selected").Value == "partial"))
                                   .FirstOrDefault();

            //Arrange
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "Test.config" };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            HighLightSection config = configuration.GetSection("HighLightSection") as HighLightSection;


            XDocument output = addIn.InsertHighLightCode(htmlCode, pos, param, outline, config, false, false);

            Assert.AreEqual(Resource1.Output2, output.ToString(), false);
        }

        [TestMethod]
        public void FormatSelectedCode_WordSelected()
        {
        }

        [TestMethod]
        public void FormatSelectedCode_LineSelected()
        {
        }

        [TestMethod]
        public void FormatSelectedCode_PartialLineSelected()
        {
        }
    }
}
