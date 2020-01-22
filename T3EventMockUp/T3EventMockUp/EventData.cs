using System;
using System.Collections.Generic;
using System.Text;

namespace T3EventMockUp
{
    public class EventData
    {
        public string DataInfo { get; private set; }
        public EventData(string dataString)
        {
            DataInfo = dataString;
        }
    }
}
