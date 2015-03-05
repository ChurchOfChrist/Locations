using System;
using Locations.Core.Entities;

namespace Locations.DataAccessLayer.Context
{
    public static class EntitySeed
    {
        public static Church[] DefaultChurches = {
            new Church {WorshipDays = "First Church, First City", CreationDate = DateTime.Now, Lat =18.66966526847465, Lng = -69.8675537109375},
            new Church {WorshipDays = "Second Church, First City",  CreationDate = DateTime.Now, Lat =18.66966526847465, Lng = -69.8675537109375},
            new Church {WorshipDays = "Third Church, First City",   CreationDate = DateTime.Now, Lat =18.66966526847465, Lng = -69.8675537109375},
            new Church {WorshipDays = "First Church, Second City",  CreationDate = DateTime.Now},
            new Church {WorshipDays = "Second Church, Second City",CreationDate = DateTime.Now},
            new Church {WorshipDays = "Third Church, Second City", CreationDate = DateTime.Now},
            new Church {WorshipDays = "First Church, Third City", CreationDate = DateTime.Now},
            new Church {WorshipDays = "Second Church, Third City", CreationDate = DateTime.Now},
            new Church {WorshipDays = "Third Church, Third City", CreationDate = DateTime.Now}
        };

    }
}
