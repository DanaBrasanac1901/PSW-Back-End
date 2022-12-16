using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalLibrary.Core
{
    public class DateTimeRange : ValueObject
    {
        public DateTimeRange(DateTime start, DateTime end)
        {
            Validate(start, end);
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public bool OverlapsWith(DateTimeRange range)
        {
            if (Start >= range.Start && Start <= range.End)
                return true;
            else if (range.Start >= Start && range.Start <= End)
                return true;
            else
                return false;
        }

        public bool Include(DateTime date)
        {
            return date >= Start && date <= End;
        }

        private void Validate(DateTime start, DateTime end)
        {
            if (end < start)
                throw new ArgumentOutOfRangeException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }


        public string GetStartString()
        {
            return ConvertToString(Start);
        }

        public string GetEndString()
        {
            return ConvertToString(End);
        }

        private string ConvertToString(DateTime d)
        {

            return d.Date.ToString() + "/" + d.Month.ToString() + "/" + d.Year.ToString() + " " + d.Hour.ToString() + ":" + d.Minute.ToString();
        }

        public string Serialize(DateTimeRange range)
        {
            return JsonSerializer.Serialize(this);
        }

        DateTimeRange Deserialize(string json)
        {

            return JsonSerializer.Deserialize<DateTimeRange>(json);
        }
    }
}
