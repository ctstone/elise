using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EliseCouture.Web
{
    public static class Utility
    {
        public static string TimeSince(DateTime date)
        {
            DateTime now = DateTime.UtcNow;
            TimeSpan delta = now - date;
            if (delta.TotalMinutes < 1)
                return "seconds ago";
            else if (delta.TotalHours < 1)
                return TimeSince(delta.TotalMinutes, "minute");
            else if (delta.TotalDays < 1)
                return TimeSince(delta.TotalHours, "hour");
            else if (delta.TotalDays < 365)
                return TimeSince(delta.TotalDays, "day");
            else
                return TimeSince(delta.TotalDays / 365, "year");
        }

        static string TimeSince(double value, string unit, string plural = null)
        {
            return String.Format("{0:F0} {1} ago", value, GetUnits(value, unit, plural));
        }

        static string GetUnits(double value, string unit, string plural = null)
        {
            plural = plural ?? unit + 's';
            if (value == 1)
                return unit;
            else
                return plural;
        }
    }
}