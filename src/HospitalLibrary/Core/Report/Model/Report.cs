using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class Report
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string AppointmentId { get; set; }
        public string ReportDescription { get; set; }

        //[Column(TypeName = "jsonb")]
        public ICollection<Symptom> Symptoms { get; set; }
        public DateTime DayAndTimeOfMaking { get; set; }

        public ICollection<Drug> Drugs { get; set; }

        public Report()
        {
        }

        public Report(string id, string patientId, string doctorId, string reportDescription, ICollection<Symptom> symptoms, DateTime dayAndTimeOfMaking, ICollection<Drug> drugs)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            ReportDescription = reportDescription;
            Symptoms = symptoms;
            DayAndTimeOfMaking = dayAndTimeOfMaking;
            Drugs = drugs;
        }

    }
}