using System;
using System.Text.RegularExpressions;

namespace Bcl.Yelpers
{
    public static class DateOfBirthYelper
    {
        public static bool IsValidDateOfBirth(string dob)
        {
            return Regex.IsMatch(dob, @"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$");
        }

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