using System;
using System.Globalization;

namespace Bcl.Yelpers
{
    public static class IdentityNumberYelper
    {
        public static bool IsValidIdNumber(string idNumber)
        {
            var isValid = false;
            var a = 0;
            var b = 0;
            var d = 0;
            var c = 0;
            var s = idNumber.Length;
            var bStr = "";

            if ((s == 13) & (idNumber != "0000000000000") & (idNumber != "6666666666666"))
            {
                for (var i = 0; i < 12; i += 2)
                {
                    a += int.Parse(idNumber.Substring(i, 1) + "");
                }

                for (var i = 1; i < 12; i += 2)
                {
                    bStr += idNumber.Substring(i, 1);
                }

                b = int.Parse(bStr);
                b *= 2;

                do
                {
                    c += b % 10;
                    b = b / 10;
                }
                while (b > 0);

                c += a;
                d = 10 - (c % 10);

                if (d == 10) d = 0;

                if (Convert.ToInt16(idNumber.Substring(s - 1, 1)) == d)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public static bool DobIdNumberValidator(string dob, string idNumber)
        {
            var isValid = false;

            if (string.IsNullOrEmpty(dob) || string.IsNullOrEmpty(idNumber))
            {
                return false;
            }

            var dateOfBirthYear = Convert.ToInt32(DateTime.Parse(dob).Year.ToString().Substring(2, 2));
            var dateOfBirthMonth = DateTime.Parse(dob).Month;
            var dateOfBirthDay = DateTime.Parse(dob).Day;

            if (idNumber.Length >= 6)
            {
                var idYear = Convert.ToInt32(idNumber.Substring(0, 2));
                var idMonth = Convert.ToInt32(idNumber.Substring(2, 2));
                var idDay = Convert.ToInt32(idNumber.Substring(4, 2));

                if (dateOfBirthYear == idYear && dateOfBirthMonth == idMonth && dateOfBirthDay == idDay)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public static DateTime? GetDateOfBirthFromIdentityNumber(string idNumber)
        {
            var dateToday = DateTime.Now;
            var currentYear = int.Parse(dateToday.Year.ToString().Substring(2, 2));
            var yearBorn = int.Parse(idNumber.Substring(0, 2));
            string birthDate;
            string centuryBorn;

            if (yearBorn >= currentYear)
            {
                centuryBorn = dateToday.Year.ToString().Substring(0, 2);
                centuryBorn = (int.Parse(centuryBorn) - 1).ToString();
                birthDate = centuryBorn + idNumber.Substring(0, 6);
            }
            else
            {
                centuryBorn = dateToday.Year.ToString().Substring(0, 2);
                birthDate = centuryBorn + idNumber.Substring(0, 6);
            }

            DateTime.TryParseExact(birthDate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out var dob);

            return dob;
        }

        public static string GetGenderFromIdNumber(string idNumber)
        {
            var result = string.Empty;

            if (string.IsNullOrEmpty(idNumber) || !IsValidIdNumber(idNumber)) 
                return result;

            var genderValue = idNumber.Substring(6, 1);
            if (genderValue.IndexOfAny("01234".ToCharArray()) != -1)
            {
                result = "Female";
            }
            else if (genderValue.IndexOfAny("56789".ToCharArray()) != -1)
            {
                result = "Male";
            }

            return result;
        }

    }
}