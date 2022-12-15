using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood
{
    [Owned]
    public class RequestedBlood : ValueObject
    {
        public BloodType Type { get; private set; }
        public double Amount { get; private set; }

        public RequestedBlood() { }

        public RequestedBlood(BloodType type, double amount)
        {
            Validate(amount);
            this.Type = type;
            this.Amount = amount;
        }

        private void Validate(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Amount;
        }

    }
}
