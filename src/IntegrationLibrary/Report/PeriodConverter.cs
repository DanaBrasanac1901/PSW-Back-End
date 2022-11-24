using System;

namespace IntegrationLibrary.Report
{
    public class PeriodConverter
    {
        public static TimeSpan Convert(Period period)
        {
            if (period == Period.Daily)
            {
                return TimeSpan.FromDays(1);
            }
            else if (period == Period.Monthly)
            {
                return TimeSpan.FromDays(30);
            }
            else
            {
                return TimeSpan.FromDays(240);
            }

        }
    }
}