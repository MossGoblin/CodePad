using System;
using System.Collections.Generic;
using System.Text;

namespace Packer
{
    public class StorageSpace
    {
        public int[,] Grid { get; private set; }

        public StorageSpace(int width, int height)
        {
            Grid = new int[width, height];
        }
    }
}
