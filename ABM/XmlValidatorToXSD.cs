using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ABM
{
    public class XmlValidatorToXSD
    {
        static int numErrors = 0;
        static string msgError = "";

        public static int load(string pathXML,string pathXsd)
        {
           
          //  string path3 = Path.GetFullPath("../../../ABM/XSD/Question3.XSD");
            string _descendant;
            string _attributeName;
            string _expectedAtValue;

            if (!System.IO.File.Exists(pathXML))
            {
                throw new Exception(String.Format("File '{0}' does not exist", pathXML));
            }

                       
            var inteiro = new List<XmlNode>();


           
            StreamReader streamReader = new StreamReader(pathXML);
            string xml = streamReader.ReadToEnd();
         
            streamReader.Close();

            ResultDeliveryMethod result = Validate(pathXML, pathXsd);
            
            if (result == ResultDeliveryMethod.PASSED)
            {
                _descendant = "Declaration";
                _attributeName = "Command";
                _expectedAtValue = "DEFAULT";

                var valueFoundXml = LoadNodeValue(pathXML,xml, TypeNode.ELEMENT, _descendant, _attributeName, _expectedAtValue);

                if (valueFoundXml == _expectedAtValue)
                {
                    result = ResultDeliveryMethod.PASSED;
                }
                else
                {
                    result = ResultDeliveryMethod.COMMANDERROR;
                }
            }
            if (result == ResultDeliveryMethod.PASSED)
            {
                _descendant = "DeclarationHeader";
                _attributeName = "SiteID";
                _expectedAtValue = "DUB";

                var valueFoundXml = LoadNodeValue(pathXML,xml, TypeNode.ATTRIBUTE, _descendant, _attributeName, _expectedAtValue );

                if (valueFoundXml == _expectedAtValue)
                {
                    result = ResultDeliveryMethod.PASSED;
                }
                else
                {
                    result = ResultDeliveryMethod.SITEIDERROR;
                }
            }

            return (int)result;

        }


        private static string LoadNodeValue(string pathXml, string xml, TypeNode nodeType, string descendant, string attributeName, string expectedAtValue)
        {
            string attrValue = string.Empty;
            System.IO.TextReader tr = new System.IO.StringReader(xml);
            XElement doc = XElement.Load(tr);
           


            if (nodeType == TypeNode.ATTRIBUTE)
            {
                var temp = doc.Descendants(descendant);
                // .Where(p => p.Attribute(attributeName).Value == expectedAtValue);
            
                foreach (var item in temp.Elements(attributeName))
                {
                    var bb = item.Name;
                    attrValue = item.Value.Trim();
                }
                return attrValue;
            }
            else
            {
                var temp = doc.Descendants(descendant)
               .Select(p => p.FirstAttribute.Value);

                foreach (var item in temp)
                {
                    attrValue = item;
                }
                if (attrValue.ToUpper() == expectedAtValue)
                {
                    return attrValue;
                }
               
            }

            return attrValue;

        }
                                 
        public static ResultDeliveryMethod Validate(string pathxml, string fileName)
        {
                                 
            return Validate(pathxml, GetFileStream(fileName));
        }


        public static ResultDeliveryMethod Validate(string pathxml, Stream xsd)
        {
            ClearErrorMessage();
            try
            {
               
                XmlTextReader tr = new XmlTextReader(xsd);
                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add(null, tr);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(schema);
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += new ValidationEventHandler(ErrorHandler);
                XmlReader reader = XmlReader.Create(pathxml, settings);


                // Validate XML data
                while (reader.Read()) ;
                reader.Close();
                tr.Close();

                // exception if validation failed
                if (numErrors > 0)
                    throw new Exception(msgError);

                return ResultDeliveryMethod.PASSED;
            }
            catch (Exception ex)
            {
                var erro = ex.Message + ex.StackTrace;
            }
             return ResultDeliveryMethod.COMMANDERROR;

        }
    

    private static void ErrorHandler(object sender, ValidationEventArgs args)
    {
        msgError = msgError + "\r\n" + args.Message;
        numErrors++;
    }

    // if a validation error occurred, this will return the message
    public static string GetError()
    {
        return msgError;
    }

    private static void ClearErrorMessage()
    {
        msgError = "";
        numErrors = 0;
    }

    // returns a stream of the contents of the given filename
    private static Stream GetFileStream(string filename)
    {
        try
        {
            return new FileStream(filename, FileMode.Open);
        }
        catch (Exception ex)
            {
                var erro = ex.Message + ex.StackTrace;
                return null;
            }
        }
}  
}
