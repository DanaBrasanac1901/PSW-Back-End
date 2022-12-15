using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Doctor;

namespace HospitalLibrary.Core.Blood
{
    public class BloodRequest
    {
        public int Id { get; set; }
        public String DoctorId { get; set; }
        public RequestedBlood Blood {get; set;}
        public String Reason { get; set; }
        public DateTime Due { get; set; }

        public BloodRequest(){}

        public BloodRequest(int id, BloodType type, double amount, String reason, DateTime due)
        {
            this.Id = id;
            this.Blood = new RequestedBlood(type, amount);
            this.Reason = reason;
            this.Due = due;
        }
    }
}
