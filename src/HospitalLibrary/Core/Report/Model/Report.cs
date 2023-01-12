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
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentId { get; set; }
        public string ReportDescription { get; set; }

        //[Column(TypeName = "jsonb")]
        public ICollection<Symptom> Symptoms { get; set; }
        public DateTime DayAndTimeOfMaking { get; set; }

        public ICollection<Drug> Drugs { get; set; }

        public Report()
        {
        }

        public Report(string id, int patientId, int doctorId, string reportDescription, ICollection<Symptom> symptoms, DateTime dayAndTimeOfMaking, ICollection<Drug> drugs)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            ReportDescription = reportDescription;
            Symptoms = symptoms;
            DayAndTimeOfMaking = dayAndTimeOfMaking;
            Drugs = drugs;
        }

        public Report ContainsAny(string[] searchWords)
        {
            bool hasMatchingFields = HasMatchingFields(searchWords);
            List<Drug> matchingPrescriptions = GetMatchingPrescriptions(searchWords);

   
            if (hasMatchingFields || matchingPrescriptions.Count != 0)
            {
                Report reportForDTO = new Report();
                reportForDTO.Id = Id;
                reportForDTO.PatientId = PatientId;
                reportForDTO.ReportDescription = ReportDescription;
                reportForDTO.Symptoms = Symptoms;
                reportForDTO.AppointmentId = AppointmentId;
                reportForDTO.Drugs = matchingPrescriptions;

                return reportForDTO;
            }

            return null;
        }

        private bool HasMatchingFields(string[] searchWords)
        {
            foreach(string word in searchWords)
            {
                if (ReportDescription.Contains(word) || IsInSymptoms(word))
                    return true;
            }

            return false;
        }

        private List<Drug> GetMatchingPrescriptions(string[] searchWords)
        {
            List<Drug> matchingPrescriptions = new List<Drug>();
            foreach(Drug drug in Drugs)
            {
                if (drug.ContainsAny(searchWords))
                    matchingPrescriptions.Add(drug);
            }
            return matchingPrescriptions;
        }

        private bool IsInSymptoms(string word)
        {
            foreach(Symptom symptom in Symptoms)
            {
                if (symptom.Name.Contains(word))
                    return true;
            }
            return false;
        }
    }
}