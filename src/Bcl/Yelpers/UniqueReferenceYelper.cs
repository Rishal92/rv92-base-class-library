using System;
using System.Linq;

namespace Bcl.Yelpers
{
    public static class UniqueReferenceYelper
    {
        public static string ReferenceCharacters = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Use 0 as a delimiter

        public static string GenerateUniqueReference(string uniqueString, bool convertStringToAsciiSum)
        {
            var uniqueId = convertStringToAsciiSum ? GetNumberFromText(uniqueString) : long.Parse(uniqueString);

            var fromDate = new DateTime(2017, 1, 1);
            var toDate = DateTime.Now;
            var timespan = toDate - fromDate;
            var minutes = (int)Math.Floor(timespan.TotalMinutes);
            var number = long.Parse(uniqueId + "0" + minutes);

            return GetCompressedStringFromNumber(number);
        }

        private static string GetCompressedStringFromNumber(long number)
        {
            var numberOfDigits = number == 0 ? 1 : (int)Math.Floor(Math.Log(number, 35) + 1);
            var digits = new char[numberOfDigits];
            for (var i = 0; i < numberOfDigits; i++)
            {
                var digit = (int)(number / (i == 0 ? 1 : 35 * i) % 35);
                digits[i] = ReferenceCharacters[digit];
            }
            return new string(digits);
        }

        private static long GetNumberFromText(string text)
        {
            return text.Aggregate<char, long>(0, (current, character) => current + (character - 48));
        }

    }
}