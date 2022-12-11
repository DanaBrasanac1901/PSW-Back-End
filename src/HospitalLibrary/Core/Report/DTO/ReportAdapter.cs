using HospitalLibrary.Core.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class ReportAdapter
    {
        public static Report.Model.Report ReportToCreateDTOToReport(ReportToCreateDTO dto)
        {
            Report.Model.Report report = new Report.Model.Report();
            report.Id =  DateTime.Now.ToString("yyMMddhhmmssffffff");
            report.PatientId = dto.patientId;
            report.DoctorId = dto.doctorId;
            report.ReportDescription = dto.description;
            report.DayAndTimeOfMaking = DateTime.Now;
            report.Symptoms = CreateSymptoms(dto.symptoms);
            return report;
        }

        public static ICollection<Symptom> CreateSymptoms(List<SymptomDTO> dtos)
        {
            ICollection<Symptom> retList = new List<Symptom>();
            foreach (var dto in dtos)
            {
                retList.Add(new Symptom(dto.name));
            }

            return retList;
        }

        public static Report.Model.DrugPrescription CreateDrugPrescription(string reportId, ReportToCreateDTO dto)
        {
            Report.Model.DrugPrescription drugPrescription = new Report.Model.DrugPrescription();
            drugPrescription.Id = DateTime.Now.AddMilliseconds(1).ToString("yyMMddhhmmssffffff");
            drugPrescription.ReportId = reportId;
            drugPrescription.Drugs = CreateDrugs(dto.drugs);
            return drugPrescription;
        }

        public static ICollection<Drug> CreateDrugs(List<DrugDTO> dtos)
        {
            ICollection<Drug> retList = new List<Drug>();
            foreach (var dto in dtos)
            {
                retList.Add(new Drug(dto.name,dto.companyName));
            }

            return retList;
        }
    }
}
