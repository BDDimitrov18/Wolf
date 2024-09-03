using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient
{
    public static class TimeSettingsUserManagament
    {

        static TimeSettingsUserManagament()
        {
            // Get the current system time zone
            CurrentTimeZone = TimeZoneInfo.Local;
        }

        // Property to hold the current time zone
        public static TimeZoneInfo CurrentTimeZone { get; private set; }

        // Method to get the current time in the system's time zone
        public static DateTime GetCurrentTime()
        {
            // Get the current time in UTC
            DateTime utcNow = DateTime.UtcNow;

            // Convert UTC time to the local time zone
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, CurrentTimeZone);

            return localTime;
        }
    }
}
