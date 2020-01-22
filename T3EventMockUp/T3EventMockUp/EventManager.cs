using System;
using System.Collections.Generic;
using System.Text;

namespace T3EventMockUp
{
    public static class EventManager
    {
        public delegate void EventListener(EventData eventData);
        
        public static Dictionary<EventType, HashSet<EventListener>> eventCollection;

        static EventManager()
        {
            eventCollection = new Dictionary<EventType, HashSet<EventListener>>();
        }

        public static void RegisterListener(EventType eventType, EventListener listener)
        {
            if (!eventCollection.ContainsKey(eventType))
            {
                eventCollection.Add(eventType, new HashSet<EventListener>());
            }
            eventCollection[eventType].Add(listener);
        }

        public static void FireEvent(EventType eventType, EventData eventData)
        {
            if (eventCollection.ContainsKey(eventType))
            {
                foreach (EventListener listener in eventCollection[eventType])
                {
                    listener(eventData);
                }
            }
        }
    }
}
