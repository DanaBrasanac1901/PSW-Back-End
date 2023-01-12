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
            /*Report.Model.Report report = new Report.Model.Report();
            //report.Id =  DateTime.Now.ToString("yyMMddhhmmssffffff");
            report.PatientId = dto.patientId;
            report.DoctorId = dto.doctorId;
            report.ReportDescription = dto.description;
            report.DayAndTimeOfMaking = DateTime.Now;
            report.Symptoms = CreateSymptoms(dto.symptoms);
            report.AppointmentId = dto.appointmentId;
            report.Drugs=CreateDrugs(dto.drugs);*/
            Report.Model.Report report = new Report.Model.Report(DateTime.Now.ToString("yyMMddhhmmssffffff"), dto.patientId, dto.doctorId, dto.description, CreateSymptoms(dto.symptoms), DateTime.Now, CreateDrugs(dto.drugs));

            return report;
        }


        public static ICollection<Symptom>CreateSymptoms(List<SymptomDTO> dtos)
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

        public static Model.Report SetFields(Model.Report report, ReportToCreateDTO dto)
        {
            report.PatientId = dto.patientId;
            report.DoctorId = dto.doctorId;
            report.ReportDescription = dto.description;
            report.DayAndTimeOfMaking = DateTime.Now;
            report.Symptoms = CreateSymptoms(dto.symptoms);
            report.AppointmentId = dto.appointmentId;
            report.Drugs = CreateDrugs(dto.drugs); 

            return report;
        }

        private static List<SymptomDTO> CreateSymptomsDTO(ICollection<Symptom> symptoms)
        {
            List<SymptomDTO> dtos = new List<SymptomDTO>();
            foreach (var symptom in symptoms)
            {
                SymptomDTO dto = new SymptomDTO();
                dto.name = symptom.Name;
                dto.isChecked = false;
                dtos.Add(dto);
            }
            return dtos;
        }

        public static ReportToShowDTO ReportToReportToShowDTO(Report.Model.Report report)
        {
            ReportToShowDTO dto = new ReportToShowDTO();
            dto.id = report.Id;
            dto.patientId = report.PatientId;
            dto.description = report.ReportDescription;
            dto.symptoms = CreateSymptomsDTO(report.Symptoms);
            dto.appointmentId = report.AppointmentId;
            return dto;
        }

        public static List<DrugDTO> CreateDrugdDTO(ICollection<Drug> drugs)
        {
            List<DrugDTO> dtos = new List<DrugDTO>();
            foreach (var drug in drugs)
            {
                DrugDTO dto = new DrugDTO();
                dto.name = drug.Name;
                dto.companyName = drug.CompanyName;
                dto.isChecked = false;
                dtos.Add(dto);
            }
            return dtos;
        }

        public static DrugPrescriptionToShowDTO DrugPrescriptionToDrugPrescriptionToShowDTO(Report.Model.Report report)
        {
            DrugPrescriptionToShowDTO dto = new DrugPrescriptionToShowDTO();
            dto.reportId  = report.Id;
            dto.drugs = CreateDrugdDTO(report.Drugs);
            return dto;
        }


        /*
    public string PatientId { get; set; }
       public string DoctorId { get; set; }
       public string AppointmentId { get; set; }
       public string ReportDescription { get; set; }

       //[Column(TypeName = "jsonb")]
       public ICollection<Symptom> Symptoms { get; set; }
       public DateTime DayAndTimeOfMaking { get; set; }

       public ICollection<Drug> Drugs { get; set; }
   */

        public static SearchResultReportDTO CreateSearchResultDTO(Report.Model.Report report)
        {
            SearchResultReportDTO dto = new SearchResultReportDTO();

            dto.patientId = report.PatientId;
            dto.description = report.ReportDescription;
            dto.symptoms = CreateSymptomsDTO(report.Symptoms);
            dto.appointmentId = report.AppointmentId;
            dto.prescriptions = CreateDrugdDTO(report.Drugs);

            return dto;
        }
    }
}
