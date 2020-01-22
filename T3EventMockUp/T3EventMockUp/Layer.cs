using System;
using System.Collections.Generic;
using System.Text;

namespace T3EventMockUp
{
    public class Layer
    {
        public int layerId { get; private set; }

        public Layer(int layerId)
        {
            this.layerId = layerId;
        }
    }
}
