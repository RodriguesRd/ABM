using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Collections.Generic;

namespace ABM
{
    public class ExtractXML
    {
        private const string _header = "UNA:+.?";

        public static List<XmlDocResult> LoadFromString(string xml, string descendant, string attributeName, List<string>itensToBeListed)
        {
            List<XmlDocResult> ItensFound = new List<XmlDocResult>();

            foreach (var item in itensToBeListed)
            {
                XmlDocResult docResul = new XmlDocResult();
                docResul.Identifier = item;
                docResul.value = LoadNodeValue(xml, descendant, attributeName, item);

                if (!string.IsNullOrEmpty(docResul.value))
                    ItensFound.Add(docResul);
            }
            //Create the XmlDocument
                       

            return ItensFound;
        }

        private static string LoadNodeValue(string pathXml, string descendant, string attributeName, string attributeValue)
        {
            XmlTextReader reader = new XmlTextReader(pathXml);
            XDocument doc = XDocument.Load(reader);

            var temp = doc.Descendants(descendant)
                    .Where(p => p.Attribute(attributeName).Value == attributeValue);
            string attrValue = string.Empty;
            foreach (var item in temp)
            {
                attrValue = item.Value.Trim();
            }
            return attrValue;
        }
    }
}
