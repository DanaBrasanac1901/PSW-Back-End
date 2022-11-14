using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core
{
    public class DateTimeRange
    {
        public DateTimeRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool OverlapsWith(DateTimeRange range)
        {
            if (Start >= range.Start && Start <= range.End)
                return true;
            else if (range.Start >= Start && range.Start <= End)
                return true;
            else
                return false;
        }
    }
}
