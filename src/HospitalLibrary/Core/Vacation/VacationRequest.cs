using HospitalLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation
{
    public class VacationRequest
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public bool Urgency { get; set; }
        public string DoctorId { get; set; }
        public VacationRequestStatus Status { get; set; }

        public VacationRequest() { }

        public VacationRequest(int id, DateTime start, DateTime end, string description,bool urgency, string doctorId)
        {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.Description = description;
            this.Urgency = urgency;
            this.DoctorId = doctorId;
            this.Status = VacationRequestStatus.WaitingForApproval;
        }

    }
}
