using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    public interface ICollatible
    {
        // int area
        // string name
        // connectivity level
        // loot level

        string Name { get; set; }

        int Area { get; set; }

    }
}
