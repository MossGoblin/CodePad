using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    class StorageRoom : ICollatible
    {
        public string Name { get; set; }
        public int Area { get; set; }


        public StorageRoom(string name, int area)
        {
            Name = name;
            Area = area;

        }
    }
}
