using System.Diagnostics;
using chas_happenings.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using chas_happenings.Models;
using Application.Interfaces.IServices;
using Application.DTOs.EvenDTOs;

namespace chas_happenings.Controllers.MVC
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventServices _eventServices;

        public HomeController(ILogger<HomeController> logger, IEventServices eventServices)
        {
            _logger = logger;
            _eventServices = eventServices;
        }

        // ?? NEW Index action
        public async Task<IActionResult> Index(int? year, int? month)
        {
            // jag ahr satt den som July 2025 default, tills vidare. beror på hur mycket vi hinner implementera
            var targetYear = year ?? 2025;
            var targetMonth = month ?? 7;

            var firstDay = new DateTime(targetYear, targetMonth, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            // This uses the same logic as api/Event/getbydate
            var events = await _eventServices.GetEventsByDateTimeServicesAsync(firstDay, lastDay);
            // events is List<GetEventCalenderDisplayDTO>

            // Group events by date
            var eventsByDate = events
                .GroupBy(e => e.EventDate.Date)      // ? if your DTO uses another name, change this
                .ToDictionary(g => g.Key, g => g.ToList());

            var model = new CalendarMonthViewModel
            {
                Year = targetYear,
                Month = targetMonth
            };

            // Build one CalendarDayViewModel for each day of the month
            for (var date = firstDay; date <= lastDay; date = date.AddDays(1))
            {
                var dayVm = new CalendarDayViewModel { Date = date };

                if (eventsByDate.TryGetValue(date.Date, out var dayEvents))
                {
                    foreach (var ev in dayEvents)
                    {
                        // Time: "12.00-17.30"
                        string timeRange = "";
                        if (ev.StartTime.HasValue && ev.EndTime.HasValue)
                        {
                            var startStr = ev.StartTime.Value.ToString(@"hh\:mm").Replace(":", ".");
                            var endStr = ev.EndTime.Value.ToString(@"hh\:mm").Replace(":", ".");
                            timeRange = $"{startStr}-{endStr}";
                        }
                        else if (ev.StartTime.HasValue)
                        {
                            timeRange = ev.StartTime.Value.ToString(@"hh\:mm").Replace(":", ".");
                        }

                        var calEvent = new CalendarEventViewModel
                        {
                            EventId = ev.Id,               // ?? NEW (adjust if your DTO uses another name)
                            Date = date,
                            TimeRange = timeRange,
                            Title = ev.Title,              // change if your property name differs
                            TypeName = ev.Type.ToString()  // "School", "StudentBody", "Leasson", "StudentEvent"
                        };

                        dayVm.Events.Add(calEvent);
                    }
                }

                model.Days.Add(dayVm);
            }

            return View(model);
        }

        // Privacy + Error actions stay as they are...
    }


    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}
}
