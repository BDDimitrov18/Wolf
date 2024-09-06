using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient
{
    public static class GlobalSettings
    {
        public static string FormTitle { get; set; } = "Wolf";
        public static string IconPath { get; set; } = "";

        static GlobalSettings()
        {
            // Set the time zone to Bulgarian time zone (EET/EEST - FLE Standard Time)
            CurrentTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
        }

        // Property to hold the current time zone
        public static TimeZoneInfo CurrentTimeZone { get; private set; }

        // Method to get the current time in the specified time zone (Bulgarian time zone)
        public static DateTime GetCurrentTime()
        {
            // Get the current time in UTC
            DateTime utcNow = DateTime.UtcNow;

            // Convert UTC time to the Bulgarian time zone
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, CurrentTimeZone);

            return localTime;
        }
    }
}
