using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    public enum ProfileType
    {
        Service = 0, // corridors, toilets, etc
        Research = 1, // laboratories, material repositories, etc
        Military = 2, // armories, barracks, etc.
        Generic = 3 // living quarters, mess halls, etc.
    }
}
