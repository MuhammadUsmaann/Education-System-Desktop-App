using System;
using System.Collections.Generic;
using System.Globalization;

namespace ES.Configurations
{
    public static class DateScripts
    {
        public const string DATE_MONTH_YEAR_FORMAT = "MMMM, yyyy";
        public const string DATE_FORMAT = "MMM-dd-yyyy";
        public const string DB_DATE_FORMAT = "yyyy-MM-dd";
        public static Boolean IsValidDate(this string date)
        {
            DateTime temp;
            if (DateTime.TryParse(date, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean IsLowerDate(this string start, string end)
        {
            DateTime date1 = Convert.ToDateTime(start);
            DateTime date2 = Convert.ToDateTime(end);

            int result = DateTime.Compare(date1, date2);

            if (result <= 0)
            {
                return true;
            }
            else
            { return false; }

        }
        public static string GetDayName(this string date)
        {
            return Convert.ToDateTime(date).ToString("dddd");
        }
        public static int GetDayOfMonth(this string date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                return dt.Day;
            }
            catch
            {
                return -1;
            }
        }
        public static Boolean ComapareDate(this string date, string date2)
        {
            try
            {
                string dt1 = Convert.ToDateTime(date).ToString(DATE_FORMAT);
                string dt2 = Convert.ToDateTime(date2).ToString(DATE_FORMAT);

                return dt1 == dt2;
            }
            catch
            {
                return false;
            }
        }
        public static int GetDaysInMonth(this string date)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                int year = dt.Year;
                int month = dt.Month;
                return DateTime.DaysInMonth(year, month);
            }
            catch
            {
                return -1;
            }
        }
        public static IEnumerable<String> GetMonths(string startDate, string endDate)
        {
            List<String> months = new List<String>();

            DateTime sDate = Convert.ToDateTime(startDate);
            DateTime eDate = Convert.ToDateTime(endDate);

            Boolean isTrue = true;
            while (isTrue)
            {
                var id = DateTime.Compare(sDate, eDate);
                if (id >= 0)
                {
                    isTrue = false;
                };
                var month = sDate.ToString("MMMM");
                sDate = sDate.AddMonths(1);
                months.Add(month);
            }
            return months;
        }
        public static void GetStartEndDate(this string date, ref string startDate, ref string endDate)
        {
            DateTime dt = Convert.ToDateTime(date);
            int daysInMonth = date.GetDaysInMonth();
            string month = dt.Month < 10 ? (String.Concat("0", dt.Month)) : dt.Month.ToString();
            string year = dt.Year < 10 ? (String.Concat("0", dt.Year)) : dt.Year.ToString();
            string days = daysInMonth < 10 ? (String.Concat("0", daysInMonth)) : daysInMonth.ToString();
            startDate = String.Concat(month, "-01", "-", year);
            endDate = String.Concat(month, "-", days, "-", year);
        }
        public static void GetDayAndDate(this string CurDate, ref string DayName, ref string reqDate, int addDays)
        {

            DateTime dt = Convert.ToDateTime(CurDate);

            DateTime sd = Convert.ToDateTime(String.Format("{0:" + DATE_FORMAT + "}", CurDate.Trim()), CultureInfo.CurrentCulture);
            DateTime newDate = sd.AddDays(addDays);

            DayName = newDate.ToString("dddd");

            reqDate = newDate.ToString(DATE_FORMAT);
        }
        public static string AddDaysInDate(this string date1, int day)
        {
            try
            {
                string date = Convert.ToDateTime(date1).AddDays(day).ToString(DB_DATE_FORMAT);

                return date;
            }
            catch
            {
                return null;
            }
        }

        public static string GetJustDate(string date)
        {
            if (string.IsNullOrEmpty(date)) return "";
            string dt = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            return dt;
        }
    }
}
