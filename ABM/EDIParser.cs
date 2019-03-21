using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ABM
{
    public class EdiParser
    {
        private const string _header = "UNA:+.?";

        public static List<EDIResult> loadFromString(string data)
        {
            // clean data
            data = data.Replace("\r", "").Replace("\n", "").Trim();
            // remove header
            if (data.IndexOf(_header) > -1)
            {
                data = data.Substring(data.IndexOf(_header) + _header.Length).Trim();
            }
       
            List<EDIResult> retval = new List<EDIResult>();
            // iterate through segments, find elements and evaluate consecutive segments
            List<EdiSegment> rawSegments = splitSegments(data);
            //separates LOC segments 
            List<List<EdiSegment>> transportLocSegments = splitIntoLocSegments(rawSegments);

            foreach (List<EdiSegment> segments in transportLocSegments)
            {
                EDIResult consigment = new EDIResult();
                foreach (EdiSegment segment in segments)
                {
                    consigment.GlobalIdentifier = segment._qualififier;
                    consigment.DataElements = segment.GetElement(0)+"&";
                    consigment.DataElements += segment.GetElement(1);
                    break;

                }
                retval.Add(consigment);
            } // !foreach(transportLocSegments)

            return retval;
        } 

        private static List<EdiSegment> splitSegments(string rawData)
        {
            List<string> tempElements = rawData.Split(new char[] { '\'' }).ToList();

            List<EdiSegment> retval = new List<EdiSegment>();
            foreach (string element in tempElements)
            {
                if (element.IndexOf("+") == -1)
                {
                    continue;
                }

                int pos = element.IndexOf("+");
                string token = element.Substring(0, pos).Trim();
                List<string> data = element.Substring(pos + 1).Split(new char[] { ':', '+' }).ToList();

                retval.Add(new EdiSegment(token, data));
            }

            return retval;
        } // !_SplitIntoSegments()


        private static List<List<EdiSegment>> splitIntoLocSegments(List<EdiSegment> rawSegments)
        {
            List<List<EdiSegment>> retval = new List<List<EdiSegment>>();

            for (int i = 0; i < rawSegments.Count; i++)
            {
               
                if (String.Equals(rawSegments[i]._qualififier, "LOC", StringComparison.InvariantCultureIgnoreCase))
                {
                    List<EdiSegment> segments = new List<EdiSegment>();
                   
                    EdiSegment dtElementsFiltred = new EdiSegment(rawSegments[i]._qualififier, rawSegments[i]._dataElements.Take(2).ToList());
                  
                    segments.Add(dtElementsFiltred);
                    retval.Add(segments);
                }
            } // !for(i)

            return retval;
        } // !_SplitIntoTransportStatusSegments()
    }
}
