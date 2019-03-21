using System;
using System.Collections.Generic;
using System.Text;

namespace ABM
{
    public class EdiSegment
    {
        public string _qualififier { get; private set; }
        public List<string> _dataElements { get; set; }


        public EdiSegment(string qualifier, List<string> dataElements = null)
        {
            this._qualififier = qualifier;
            this._dataElements = dataElements;
        }

        public string GetElement(int index, string defaultValue = "")
        {
            if (index >= this._dataElements.Count)
            {
                return defaultValue;
            }
            else
            {
                return this._dataElements[index];
            }
        } // !GetElement()
    }
}
