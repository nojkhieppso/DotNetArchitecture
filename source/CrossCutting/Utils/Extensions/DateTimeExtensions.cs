using System;
using System.Linq;

namespace Solution.CrossCutting.Utils
{
    public static class DateTimeExtensions
    {
        public static DateTime NextDateTime(this DateTime dateTime, DayOfWeek[] days, TimeSpan[] times)
        {
            times = times.OrderBy(x => x.Hours).ToArray();

            var nextTimes = times.Where(x => x.Hours > dateTime.TimeOfDay.Hours).ToArray();

            return nextTimes.Length > 0 ? dateTime.Date + nextTimes[0] : dateTime.NextDateTime(days).Date + times[0];
        }

        public static DateTime NextDateTime(this DateTime dateTime, params DayOfWeek[] days)
        {
            return Enumerable.Range(1, 7).Cast<double>().Select(dateTime.AddDays).First(y => days.Contains(y.DayOfWeek));
        }

        public static DateTime SetTime(this DateTime dateTime, string time)
        {
            if (string.IsNullOrWhiteSpace(time))
            {
                return dateTime;
            }

            var parts = time.Split(':');

            if (parts.Length < 3
                || !int.TryParse(parts[0], out var hours)
                || !int.TryParse(parts[1], out var minutes)
                || !int.TryParse(parts[2], out var seconds))
            {
                return dateTime;
            }

            return SetTime(dateTime, hours, minutes, seconds);
        }

        public static DateTime SetTime(this DateTime dateTime, int hours, int minutes, int seconds)
        {
            if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
            {
                return dateTime;
            }

            return dateTime.Date + new TimeSpan(hours, minutes, seconds);
        }
    }
}
