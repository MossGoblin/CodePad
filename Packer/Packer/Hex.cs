using System;
using System.Collections.Generic;
using System.Text;

namespace Packer
{
    class Hex
    {
        public int posX { get; private set; }
        public int posY { get; private set; }
        public int posZ { get; private set; }

        public Hex(int r, int q)
        {
            posX = r;
            posY = q;
            posZ = - r - q;
        }

        public List<Hex> GetNbrs()
        {
            return new List<Hex>();
        }
    }
}
