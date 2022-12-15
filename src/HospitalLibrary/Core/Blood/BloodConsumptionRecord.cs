using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;

namespace HospitalLibrary.Core.Blood
{
    public class BloodConsumptionRecord
    {
        private IBloodService bloodService;

        public int Id { get; set; }
        public double Amount { get; set; }
        public BloodType Type { get; set; }
        public String Reason { get; set; }
        public DateTime CreatedAt { get; set; }
        public String DoctorId { get; set; }
        public Guid SourceBank { get; set; }

        public BloodConsumptionRecord() { }
        public BloodConsumptionRecord(int id, double amount, BloodType type, string reason, DateTime createAt, string doctorId, Guid sourceBank)
        {
            Id = id;
            Amount = amount;
            Type = type;
            Reason = reason;
            CreatedAt = createAt;
            DoctorId = doctorId;
            SourceBank = sourceBank;
        }

        public BloodConsumptionRecord(IBloodService bloodService)
        {
            this.bloodService = bloodService;
        }
    }

    /*public class BloodConsumptionRecord
    {
        private IBloodService bloodService;

        public int Id { get; set; } 
        public double Amount { get; set; }
        public BloodType Type { get; set; }
        public String Reason { get; set; }
        public DateTime CreatedAt { get; set; }
        public String DoctorId { get; set; }
        public Guid SourceBank { get; set; }

        public BloodConsumptionRecord() { }
        public BloodConsumptionRecord(int id, double amount, BloodType type, string reason, DateTime createAt, string doctorId, Guid sourceBank)
        {
            Id = id;        
            Amount = amount;
            Type = type;
            Reason = reason;
            CreatedAt = createAt;
            DoctorId = doctorId;
            SourceBank = sourceBank;
        }

        public BloodConsumptionRecord(IBloodService bloodService)
        {
            this.bloodService = bloodService;
        }
    }*/
}
