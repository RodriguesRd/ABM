﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABM;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ABM_UnitTest
{
    [TestClass]
    public class unitTestGetValueXml
    {
        [TestMethod]
        public void TestMethod1()
        {
            string xmlValido = @"<?xml version=""1.0"" encoding=""UTF - 8""?>
  <InputDocument>
      <DeclarationList>
        <Declaration Command = ""DEFAULT"" Version = ""5.13"" />
              <DeclarationHeader>
                <Jurisdiction> IE </Jurisdiction>
                <CWProcedure> IMPORT </CWProcedure>
                <DeclarationDestination> CUSTOMSWAREIE </DeclarationDestination>
                <DocumentRef> 71Q0019681 </DocumentRef>
                      <SiteID> DUB </SiteID>
                      <AccountCode> G0779837 </AccountCode>
                      <Reference RefCode = ""MWB"">
                          <RefText> 586133622 </RefText>
                        </Reference>
                        <Reference RefCode = ""KEY"">
                            <RefText> DUB16049 </RefText>
                          </Reference>
                          <Reference RefCode = ""CAR"">
                              <RefText> 71Q0019681 </RefText>
                                  </Reference>
                                  <Reference RefCode = ""COM"">
                                      <RefText> 71Q0019681 </RefText>
                                         </Reference>
                                         <Reference RefCode = ""SRC"">
                                            <RefText> ECUS </RefText>
                         </Reference>
                         <Reference RefCode = ""TRV"">
                            <RefText> 1 </RefText>
                          </Reference>
                          <Reference RefCode = ""CAS"">
                             <RefText> 586133622 </RefText>
                           </Reference>
                           <Reference RefCode = ""HWB"">
                              <RefText> 586133622 </RefText>
                            </Reference>
                            <Reference RefCode = ""UCR"">
                               <RefText> 586133622 </RefText>
                             </Reference>
                             <Country CodeType = ""NUM"" CountryType = ""Destination""> IE </Country>
                                <Country CodeType = ""NUM"" CountryType = ""Dispatch""> CN </Country>
                                 </DeclarationHeader>
                               </DeclarationList>
                             </InputDocument>";

            List<string> itensToBeListed = new List<string>{ "MWB", "TRV", "CAR" };
                       
       

            var result= ExtractXML.LoadFromString(xmlValido, "Reference", "RefCode", itensToBeListed);



        }
    }
}