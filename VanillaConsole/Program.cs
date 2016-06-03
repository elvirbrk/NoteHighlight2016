using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.OneNote;
using System.Xml.Linq;

namespace VanillaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // skipping error checking, just demonstrating using these APIs
            var app = new Application();

            // get the hierarchy
            string xmlHierarchy;
            app.GetHierarchy(null, HierarchyScope.hsPages, out xmlHierarchy);

            Console.WriteLine("Hierarchy:\n" + xmlHierarchy);

            // now find the first page, print out its ID
            var xdoc = XDocument.Parse(xmlHierarchy);
            var ns = xdoc.Root.Name.Namespace;
            var pageId = xdoc.Descendants(ns + "Page").First().Attribute("ID").Value;
            Console.WriteLine("First Page ID: " + pageId);

            // get the page content, print it out
            string xmlPage;
            app.GetPageContent(pageId, out xmlPage);
            Console.WriteLine("Page XML:\n" + xmlPage);

            // sample - this is how to update content - normally you would modify the xml.
            app.UpdatePageContent(xmlPage);

            // bonus - if there are any images, get the binary content of the first one
            var xPage = XDocument.Parse(xmlPage);
            var xImage = xPage.Descendants(ns + "Image").FirstOrDefault();
            if (xImage != null)
            {
                var xImageCallbackID = xImage.Elements(ns + "CallbackID").First();
                var imageId = xImageCallbackID.Attribute("callbackID").Value;
                string base64Out;
                app.GetBinaryPageContent(pageId, imageId, out base64Out);

                Console.WriteLine("Image found, base64 data is:\n" + base64Out);
            }
        }
    }
}
