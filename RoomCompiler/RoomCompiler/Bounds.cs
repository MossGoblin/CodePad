using System;
using System.Collections.Generic;
using System.Text;

namespace RoomCompiler
{
    public struct Bounds
    {
        public int NameCounter;
        public int MinArea;
        public int MaxArea;
        public int[] AllowedTypes;
        public int[] AllowedProfiles;
        public int MaxConnectivity;
        public float MinLootLevel;
        public float MaxLootLevel;
        public int MinSecurityLevel;
        public int MaxSecurityLevel;

        public Bounds(int nameCounter, int minArea, int maxArea, int[] allowedTypes, int[] allowedProfiles, int maxConnectivity, float minLootLevel, float maxLootLevel, int minSecurityLevel, int maxSecurityLevel)
        {
            NameCounter = nameCounter;
            MinArea = minArea;
            MaxArea = maxArea;
            AllowedTypes = allowedTypes;
            AllowedProfiles = allowedProfiles;
            MaxConnectivity = maxConnectivity;
            MinLootLevel = minLootLevel;
            MaxLootLevel = maxLootLevel;
            MinSecurityLevel = minSecurityLevel;
            MaxSecurityLevel = maxSecurityLevel;
        }
    }
}
