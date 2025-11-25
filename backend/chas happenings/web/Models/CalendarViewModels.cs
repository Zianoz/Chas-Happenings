using System;
using System.Collections.Generic;

namespace chas_happenings.Models
{
    public class CalendarEventViewModel
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string TimeRange { get; set; } = "";
        public string Title { get; set; } = "";
        public string TypeName { get; set; } = "";
    }

    public class CalendarDayViewModel
    {
        public DateTime Date { get; set; }
        public List<CalendarEventViewModel> Events { get; set; } = new();
    }

    public class CalendarMonthViewModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public IList<CalendarDayViewModel> Days { get; set; } = new List<CalendarDayViewModel>();

        public string MonthTitle => new DateTime(Year, Month, 1).ToString("MMMM yyyy");
    }
}

