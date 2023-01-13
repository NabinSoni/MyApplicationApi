using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            int age = Math.Abs(dateTime.Year - currentDate.Year);

            if(currentDate < dateTime.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
