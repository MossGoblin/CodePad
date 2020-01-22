using System;
using System.Collections.Generic;
using System.Text;

namespace T3EventMockUp
{
    public class Tank
    {
        private Stack<Layer> layerStack;
        private Random rnd;
        public int TankID { get; private set; }
        public Tank()
        {
            rnd = new Random();
            layerStack = new Stack<Layer>();
            TankID = rnd.Next(100);

        }

        public void AddLayer(Layer layer)
        {
            layerStack.Push(layer);
            // REPORT TANK UPDATED
            EventManager.FireEvent(EventType.TankUpdated, new EventData($"Tank updated : {TankID}.Addition"));
            // REPORT LAYER ADDED
            EventManager.FireEvent(EventType.LayerAdded, new EventData($"Layer added : {layer.layerId}"));
        }
        public void AddNewLayer()
        {
            Layer newLayer = Factory.ProduceLayer(layerStack.Count);
            layerStack.Push(newLayer);
            // REPORT TANK UPDATED
            EventManager.FireEvent(EventType.TankUpdated, new EventData($"Tank updated : {TankID}.Addition"));
            // REPORT LAYER ADDED
            EventManager.FireEvent(EventType.LayerAdded, new EventData($"New layer added : {newLayer.layerId}"));
        }

        public Layer RemoveLayer()
        {
            if (layerStack.Count <= 0)
            {
                return null;
            }
            Layer oldLayer = layerStack.Pop();
            // REPORT TANK UPDATED
            EventManager.FireEvent(EventType.TankUpdated, new EventData($"Tank updated : {TankID}.Removal"));

            // REPORT LAYER REMOVED
            EventManager.FireEvent(EventType.LayerAdded, new EventData($"Layer removed : {oldLayer.layerId}"));
            return oldLayer;
        }
    }
}
