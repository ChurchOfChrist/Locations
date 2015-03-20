using System;

namespace Locations.Core.Entities
{
    public class WorshipDay :Entity
    {
        public DayOfWeek Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }

    }
}