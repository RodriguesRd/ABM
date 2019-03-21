using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABM;
using System.IO;

namespace ABM_UnitTest
{
    [TestClass]
    public class unitTesWebService
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            string xmlString = @"<InputDocument>
	<DeclarationList>
		<Declaration Command=""DEFAULT"" Version=""5.13"">
            < DeclarationHeader >

                < Jurisdiction > IE </ Jurisdiction >

                < CWProcedure > IMPORT </ CWProcedure >

                            < DeclarationDestination > CUSTOMSWAREIE </ DeclarationDestination >

                < DocumentRef > 71Q0019681 </ DocumentRef >
   
                   < SiteID > DUB </ SiteID >
   
                   < AccountCode > G0779837 </ AccountCode >
   
               </ DeclarationHeader >
   
           </ Declaration >
   
       </ DeclarationList >
   </ InputDocument >";


            string path = Path.GetFullPath("../../../ABM/XML/Question3.xml");
            //string xsdFileName = @":\Users\personel\source\repos\ABM TEST\Document.xsd";
            string path3 = Path.GetFullPath("../../../ABM/XML/Question3.xml");
            string pathxsd = Path.GetFullPath("../../../ABM/XML/Question3.xsd");
            var b = XmlValidatorToXSD.load(path3, pathxsd);


        }
}
}
