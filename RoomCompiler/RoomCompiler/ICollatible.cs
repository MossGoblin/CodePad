using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    interface ICollatible
    {
        // int area
        // string name
        // connectivity level
        // loot level

        int Area { get; set; }

        string Name { get; set; }

        CompartmentType Type { get; set; }

        ProfileType Profile { get; set; }

        int Connectivity { get; set; }

        float LootLevel { get; set; }

        int SecurityLevel { get; set; }

    }
}
