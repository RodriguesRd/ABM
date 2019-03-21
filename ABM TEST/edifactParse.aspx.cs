using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABM;

namespace ABM_TEST
{
    public partial class edifactParse : System.Web.UI.Page
    {
        private const string HEADER = "UNA:+.?";
        private const string STANDARD_DATEFORMAT = "yyyyMMddHHmm";
        private const string SHORT_DATEFORMAT = "yyyyMMdd";

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void SendEdifact_Click(object sender, EventArgs e)
        {

            LoadTestMessage();


        }

        private  void LoadTestMessage()
        {
            

            string edifactString = @"UNA:+.? 
                                    'UNB + UNOC:3 + 2021000969 + 4441963198 + 180525:1225 + 3VAL2MJV6EH9IX + KMSV7HMD + CUSDECU - IE++1++1'
                                    UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'
                                    BGM + ZEM:::EX + 09SEE7JPUV5HC06IC6 + Z'
                                    LOC + 17 + IT044100'
                                    LOC + 18 + SOL'
                                    LOC + 35 + SE'
                                    LOC + 36 + TZ'
                                    LOC + 116 + SE003033'
                                    DTM + 9:20090527:102'
                                    DTM + 268:20090626:102'
                                    DTM + 182:20090527:102'";

           var EdiREsultList= EdiParser.LoadFromString(edifactString);
              string[] arr = EdiREsultList.Select(list => list.DataElements).ToArray();


           // var result2 = EdiREsultList.SelectMany(b => List<EDISegment>).Distinct();

            

            //IFTSTAParser[] myArray = new IFTSTAParser[EdiREsultList.Count];
            //int i = 0;
            ////foreach (IFTSTAParser item in EdiREsultList.ToList<)
            ////{
            ////    myArray[i++] = item;
            ////}
           
            //foreach (var item in EdiREsultList)
            //{
            //    for (int i = 0; i < item.Count; i++)
            //    {
            //        TxtResult.Text = item[i].Qualififier.ToString();
            //        TxtResult.Text += "{ " + item[i].DataElements[0] + "/" + item[i].DataElements[1]!=string.Empty? item[i].DataElements[1]:"Null"+"}"+ Environment.NewLine;
            //    }
                
            //}


        }

      
    }
}