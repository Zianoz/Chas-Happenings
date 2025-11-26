using System;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.EvenDTOs;
using Application.Interfaces.IServices;
using chas_happenings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        public async Task<IActionResult> Index(int? year, int? month)
        {
            var today = DateTime.Today;
            var targetYear = year ?? today.Year;
            var targetMonth = month ?? today.Month;

            var firstDay = new DateTime(targetYear, targetMonth, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);

            var events = await _eventServices.GetEventsByDateTimeServicesAsync(firstDay, lastDay);

            var eventsByDate = events
                .GroupBy(e => e.EventDate.Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            var model = new CalendarMonthViewModel
            {
                Year = targetYear,
                Month = targetMonth
            };

            for (var date = firstDay; date <= lastDay; date = date.AddDays(1))
            {
                var dayVm = new CalendarDayViewModel { Date = date };

                if (eventsByDate.TryGetValue(date.Date, out var dayEvents))
                {
                    foreach (var ev in dayEvents)
                    {
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
                            EventId = ev.Id,
                            Date = date,
                            TimeRange = timeRange,
                            Title = ev.Title,
                            TypeName = ev.Type.ToString()
                        };

                        dayVm.Events.Add(calEvent);
                    }
                }

                model.Days.Add(dayVm);
            }

            return View(model);
        }
    }
}
