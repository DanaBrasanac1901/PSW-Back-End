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
            report.DayAndTimeOfMaking = DateTime.Parse(dto.DATOfMaking);
            report.Symptoms = (ICollection<Report.Model.Symptom>)dto.symptoms;
            return report;
        }

        public static Report.Model.DrugPrescription CreateDrugPrescription(string reportId, ReportToCreateDTO dto)
        {
            Report.Model.DrugPrescription drugPrescription = new Report.Model.DrugPrescription();
            drugPrescription.Id = DateTime.Now.AddMilliseconds(1).ToString("yyMMddhhmmssffffff");
            drugPrescription.ReportId = reportId;
            drugPrescription.Drugs = (ICollection<Report.Model.Drug>)dto.drugs;
            return drugPrescription;
        }
    }
}
