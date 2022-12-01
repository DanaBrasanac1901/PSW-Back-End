using System;

namespace IntegrationLibrary.Report
{
    public static class PeriodConverter
    {
        public static double Convert(Period period)
        {
            if (period == Period.Daily)
            {
                return 1;
            }
            else if (period == Period.Monthly)
            {
                return 30;
            }
            else
            {
                return 240;
            }

        }
    }
}