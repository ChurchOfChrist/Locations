using System;
using Locations.Core.Entities;

namespace Locations.Core.ViewModels
{
    public class WorshipDayViewModel
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public string Description { get; set; }
        public WorshipDayViewModel(WorshipDay entity)
        {
            Day = entity.Day;
            Start = entity.Start;
            End = entity.End;
            Description = entity.Description;
        }

        public WorshipDayViewModel()
        {
            
        }

        public WorshipDay ToEntity()
        {
           return new WorshipDay
           {
               Day = Day,
               Start = Start,
               End = End,
               Description = Description,
           };
        }
    }
}