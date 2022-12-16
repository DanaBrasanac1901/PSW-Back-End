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
    public class Blood : ValueObject
    {
        public BloodType Type { get; private set; }
        public double Amount { get; private set; }

        public Blood() { }

        public Blood(BloodType type, double amount)
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

        public Blood ReduceBy(Blood blood)
        {

            bool canBeReduced = IsCompatible(blood) && IsReducibleBy(blood);
            if (canBeReduced)
            {
                return new Blood(Type, Amount - blood.Amount);
            }
            return null;
        }

        private bool IsReducibleBy(Blood blood)
        {
            return (Amount - blood.Amount) >= 0;
        }

        private bool IsCompatible(Blood blood)
        {
            return blood.Type == Type;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Amount;
        }

    }
}