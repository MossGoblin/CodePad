using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    public enum CompartmentType
    {
        Connection = 0, // only connects other compartments
        Storage = 1, // used to store movables
        Utility = 2, // used to enable or enhance actions
        Common = 3, // used to allow gathering of people
        Personal = 4 // used as personal space for single people or small groups
    }
}
