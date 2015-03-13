using System;

namespace Locations.Core.Entities
{
    public class WorshipDay :Entity
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Description { get; set; }

    }
}