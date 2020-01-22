using System;
using System.Collections.Generic;
using System.Text;

namespace T3EventMockUp
{
    public static class Reporter
    {
        static Reporter()
        {
        }
        
        // public delegate void EventListener(EventType eventType);


        // register listeners
        public static void RegisterListeners()
        {
            EventManager.RegisterListener(EventType.LayerCreated, OnLayerCreated);
            EventManager.RegisterListener(EventType.LayerCreated, OnLayerAdded);
            EventManager.RegisterListener(EventType.LayerCreated, OnLayerRemoved);
            EventManager.RegisterListener(EventType.TankCreated, OnTankCreated);
            EventManager.RegisterListener(EventType.TankUpdated, OnTankUpdated);
        }

        public static void OnLayerCreated(EventData eventData)
        {
            Console.WriteLine($"report: {eventData.DataInfo}");
        }

        public static void OnLayerAdded(EventData eventData)
        {
            Console.WriteLine($"report: {eventData.DataInfo}");
        }
        public static void OnLayerRemoved(EventData eventData)
        {
            Console.WriteLine($"report: {eventData.DataInfo}");
        }

        public static void OnTankUpdated(EventData eventData)
        {
            Console.WriteLine($"report: {eventData.DataInfo}");
        }
        public static void OnTankCreated(EventData eventData)
        {
            Console.WriteLine($"report: {eventData.DataInfo}");
        }
    }
}
