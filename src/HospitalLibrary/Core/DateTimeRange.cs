using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core
{
    public class DateTimeRange : ValueObject
    {
        public DateTimeRange(DateTime start, DateTime end)
        {
            Validate(start,end);
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
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
    }
}
