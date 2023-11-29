using System;

namespace TEMPLATE_ELDOS_BACKEND.App
{
    public static class DateTimeHelper
    {
        public static string GetTimeRange(DateTime? dateTimeStart, DateTime? dateTimeEnd)
        {
            if (dateTimeStart == null || dateTimeEnd == null)
            {
                return "";
            }
            var result = $"{GetTime(dateTimeStart)} - {GetTime(dateTimeEnd)}";
            return result;
        }

        public static string GetTime(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "";
            }
            var timeString = dateTime.Value.ToString("hh.mm");
            return timeString;
        }

        public static DateTime GetDateFrom(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }

        public static DateTime GetDateUntil(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }

        public static string GetDate(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "";
            }
            var dateString = dateTime.Value.ToString("dd.MM.yyyy");
            return dateString;
        }
        public static DateTime GetLastDateMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59);
        }

        public static DateTime GetFirstDateMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0);
        }
    }
}