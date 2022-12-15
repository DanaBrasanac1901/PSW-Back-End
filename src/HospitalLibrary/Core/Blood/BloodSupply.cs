﻿using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Enums; 

namespace HospitalLibrary.Core.Blood
{
    public class BloodSupply
    {

        public int Id { get; set; }
        public BloodType Type { get; set; }
        public double Amount { get; set; }
        public Guid SourceBank { get; set; }


        public BloodSupply() { }

        public BloodSupply(int id, BloodType type, double amount, Guid sourceBank)
        {
            this.Id = id;
            this.Type = type;
            this.Amount = amount;
            this.SourceBank = sourceBank;
        }

        public BloodSupply(BloodType type, double amount, Guid sourceBank)
        {
            this.Type = type;
            this.Amount = amount;
            this.SourceBank = sourceBank;
        }

        public bool ReduceBy(double amount)
        {
            if (this.Amount >= amount)
            {
                this.Amount -= amount;
                return true;
            }

            return false;
        }
    }
    /*
    public class BloodSupply : ValueObject
    {
        public BloodType Type { get; private set; }
        public double Amount { get; private set; }
        public Guid SourceBank { get; private set; }

        public BloodSupply() { }
        
        public BloodSupply(BloodType type, double amount, Guid sourceBank)
        {
            Validate(amount);
            this.Type = type;
            this.Amount = amount;
            this.SourceBank = sourceBank;
        }

        private void Validate(double amount)
        {
            if (amount < 0)
                throw new ArgumentException();
        }

        public BloodSupply ReduceBy(BloodSupply supply)
        {
            
            bool canBeReduced = IsCompatible(supply) && IsReducibleBy(supply);
            if (!canBeReduced) throw new ArgumentException();
            {
                return new BloodSupply(Type, Amount - supply.Amount, SourceBank);
            }
        }

        private bool IsReducibleBy(BloodSupply supply)
        {
            return (Amount - supply.Amount) >= 0;
        }

        private bool IsCompatible(BloodSupply supply)
        {
            return supply.SourceBank == SourceBank && supply.Type == Type;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Amount;
            yield return SourceBank;
        }
    }*/
}
