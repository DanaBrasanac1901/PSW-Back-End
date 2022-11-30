using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class ReportAdapter
    {
        public static Report ReportToCreateDTOToReport(ReportToCreateDTO dto)
        {
            Report report = new Report();
            report.Id =  DateTime.Now.ToString("yyMMddhhmmssffffff");
            report.PatientId = dto.patientId;
            report.DoctorId = dto.doctorId;
            report.ReportDescription = dto.description;
            report.DayAndTimeOfMaking = DateTime.Parse(dto.DATOfMaking);
            return report;
        }

        public static DrugPrescription CreateDrugPrescription(string reportId)
        {
            DrugPrescription drugPrescription = new DrugPrescription();
            drugPrescription.Id = DateTime.Now.AddMilliseconds(1).ToString("yyMMddhhmmssffffff");
            drugPrescription.ReportId = reportId;
            return null;
        }
    }
}
