using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
