using System;
using System.Collections.Generic;
using System.Text;

namespace T3EventMockUp
{
    public class Event
    {
        public EventType eventType { get; private set; }
        public EventData eventData { get; private set; }
    }
}
