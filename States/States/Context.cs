using System;
using System.Collections.Generic;
using System.Text;

namespace States
{
    public class Context
    {
        public int fPrint { get; private set; }
        public int numberOfAgents { get; private set; }
        public int sizeOfAgents { get; private set; }
        public int numberOfAssets { get; private set; }
        public Context(int nAgents, int sAgents, int nAssets)
        {
            this.numberOfAgents = nAgents;
            this.sizeOfAgents = sAgents;
            this.numberOfAssets = nAssets;
            fPrint = GetFPrint();
        }

        private int GetFPrint()
        {
            return numberOfAssets + sizeOfAgents * 10 + numberOfAgents * 1000;
        }
    }
}
