using System;

namespace Bcl.Helpers
{
    public static class DateOfBirth
    {
        public static double CalculateAgeInYearsFromDateOfBirth(DateTime dateOfBirth)
        {
            var span = DateTime.Now.Subtract(dateOfBirth);
            return (span.TotalDays / 365);
        }

        public static double CalculateAgeInMonthsFromDateOfBirth(DateTime dateOfBirth)
        {
            var months = DateTime.Now.Subtract(dateOfBirth).Days / (365.25 / 12);
            return months;
        }

        public static int CalculateAgeInDaysFromDateOfBirth(DateTime dateOfBirth)
        {
            var hours = DateTime.Now.Subtract(dateOfBirth).Days;
            return hours;
        }

        public static int CalculateAgeInHoursFromDateOfBirth(DateTime dateOfBirth)
        {
            var hours = DateTime.Now.Subtract(dateOfBirth).Hours;
            return hours;
        }

        public static int CalculateAgeInMinutesFromDateOfBirth(DateTime dateOfBirth)
        {
            var minutes = DateTime.Now.Subtract(dateOfBirth).Minutes;
            return minutes;
        }

        public static int CalculateAgeInSecondsFromDateOfBirth(DateTime dateOfBirth)
        {
            var seconds = DateTime.Now.Subtract(dateOfBirth).Seconds;
            return seconds;
        }
    }
}