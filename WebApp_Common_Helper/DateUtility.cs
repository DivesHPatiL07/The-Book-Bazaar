using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp_Common_Helper
{
    public static class DateUtility
    {
        public static DateOnly MakeDate(string date)
        {
            // Assuming the input date is in the format "DD/MM/YYYY"
            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new ArgumentException("Invalid date format. Expected format: DD/MM/YYYY");
            }

            return new DateOnly(parsedDate.Year, parsedDate.Month, parsedDate.Day);
        }
        public static DateTime MakeDateTime(string date)
        {
            // Assuming the input date is in the format "DD/MM/YYYY"
            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
                throw new ArgumentException("Invalid date format. Expected format: DD/MM/YYYY");
            }

            return parsedDate;
        }
    }
}
