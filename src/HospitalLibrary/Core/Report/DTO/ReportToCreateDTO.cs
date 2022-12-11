using HospitalLibrary.Core.Report.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;

namespace HospitalLibrary.Core.Report.DTO
{
    public class ReportToCreateDTO
    {
        public IReportApplicationService _reportApplicationService;
        public string patientId { get; set;}
        public string doctorId { get; set; }
        public string appointmentId { get; set; }
        public string description { get; set; }
        public string datOfMaking { get; set; }
        public List<SymptomDTO> symptoms { get; set; }
        public List<DrugDTO> drugs { get; set; }

        public ReportToCreateDTO()
        {

        }

        public ReportToCreateDTO(IReportApplicationService reportApplicationService)
        {
            _reportApplicationService = reportApplicationService;
            //patientId = "PAT1";
            //doctorId = "DOC1";
            //description = "Descripcija";
            //datOfMaking = DateTime.Now.ToString();
            //symptoms = symptomsList();
            //drugs = drugsList();
        }

        private List<Symptom> symptomsList()
        {
            List<Symptom> retList = new List<Symptom>();
            retList.Add(new Symptom("Glavobolja"));
            retList.Add(new Symptom("Kijavica"));
            return retList;
        }

        private List<Drug> drugsList()
        {
            List<Drug> retList = new List<Drug>();
            retList.Add(new Drug("Aspirin","Hemofarm"));
            retList.Add(new Drug("Brufent","Galenika"));
            return retList;
        }
    }
}
