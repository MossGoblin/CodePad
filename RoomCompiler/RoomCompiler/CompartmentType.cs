using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    enum CompartmentType
    {
        Connection = 0, // only connects other compartments
        Storage = 2, // used to store movables
        Utility = 3, // used to enable or enhance actions
        Common = 4, // used to allow gathering of people
        Personal = 5 // used as personal space for single people or small groups
    }
}
