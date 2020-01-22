using System;
using System.Collections.Generic;
using System.Text;

namespace T3EventMockUp
{
    public static class Factory
    {
        public static Layer ProduceLayer(int index)
        {
            // REPORT LAYER CREATED
            EventManager.FireEvent(EventType.LayerCreated, new EventData($"New layer created @ {index}"));
            return new Layer(index);
        }

        public static Tank ProduceTank()
        {
            // REPORT TANK CREATED
            Tank newTank = new Tank();
            EventManager.FireEvent(EventType.TankCreated, new EventData($"New tank created @ {newTank.TankID}"));
            return newTank;
        }
    }
}
