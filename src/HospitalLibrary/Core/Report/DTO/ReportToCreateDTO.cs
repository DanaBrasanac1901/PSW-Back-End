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
            patientId = "PAT1";
            doctorId = "DOC1";
            description = "Descripcija";
            datOfMaking = DateTime.Now.ToString();
            symptoms = new List<SymptomDTO>();
            drugs = new List<DrugDTO>();
            appointmentId = DateTime.Now.ToString();
        }

        private List<SymptomDTO> symptomsList()
        {
            List<SymptomDTO> retList = new List<SymptomDTO>();
            retList.Add(new SymptomDTO("Glavobolja")); 
            retList.Add(new SymptomDTO("Kijavica"));
            return retList;
        }

        private List<DrugDTO> drugsList()
        {
            List<DrugDTO> retList = new List<DrugDTO>();
            retList.Add(new DrugDTO("Aspirin","Hemofarm",false));
            retList.Add(new DrugDTO("Brufent","Galenika",false));
            return retList;
        }
    }
}
