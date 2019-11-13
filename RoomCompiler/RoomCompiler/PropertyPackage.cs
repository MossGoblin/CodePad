using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    public struct PropertyPackage
    {
        string Name;

        int Area;

        CompartmentType Type;

        ProfileType Profile;

        int Connectivity;

        float LootLevel;

        int SecurityLevel;

        public PropertyPackage(string name, int area, CompartmentType type, ProfileType profile, int connectivity, float lootLevel, int securityLevel)
        {
            Name = name;
            Area = area;
            Type = type;
            Profile = profile;
            Connectivity = connectivity;
            LootLevel = lootLevel;
            SecurityLevel = securityLevel;
        }
    }
}
