using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABM;

namespace ABM_UnitTest
{
    [TestClass]
    public class unitTestEdiParse
    {
        [TestMethod]
        public void TestMethod1()
        {
            string edifactString = @"UNA:+.? 
                                    'UNB + UNOC:3 + 2021000969 + 4441963198 + 180525:1225 + 3VAL2MJV6EH9IX + KMSV7HMD + CUSDECU - IE++1++1'
                                    UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'
                                    BGM + ZEM:::EX + 09SEE7JPUV5HC06IC6 + Z'
                                    LOC + 17 + IT044100+555'
                                    LOC + 18 + SOL+456'
                                    LOC + 35 + SE'
                                    LOC + 36'
                                    LOC + 116 + SE003033'
                                    DTM + 9:20090527:102'
                                    DTM + 268:20090626:102'
                                    DTM + 182:20090527:102'";

            var tes = EdiParser.loadFromString(edifactString);

            

        }
    }
}
