using HospitalLibrary.Core.Report.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public class ReportApplicationService : IReportApplicationService
    {
        private readonly IReportRepository _reportRepository;
        private readonly ISymptomRepository _symptomRepository;
        
        public ReportApplicationService(IReportRepository reportRepository,ISymptomRepository symptomRepository)
        {
            _reportRepository = reportRepository;
            _symptomRepository = symptomRepository;
            
            
        }

        public void Create(ReportToCreateDTO dto)
        {
            Report report = ReportAdapter.ReportToCreateDTOToReport(dto);
            //DrugPrescription drugPrescription = 
            //pozove drugprescription da napravi
            //_reportRepository.Create(report);
        }

        public void Delete(Report report)
        {
            _reportRepository.Delete(report);
        }

        public IEnumerable<Report> GetAll()
        {
            return _reportRepository.GetAll();
        }

        public Report GetById(string id)
        {
            return _reportRepository.GetById(id);
        }

        public void Update(Report report)
        {
            _reportRepository.Update(report);
        }

        public bool IsSymptomExist(ICollection<Symptom> symptoms,string id)
        {
            var report = _reportRepository.GetById(id);
            ICollection<Symptom> symptom = report.Symptoms;
            foreach (var symp in symptom)
            {
                if(!symptoms.Contains(symp)) return false;
            }
            return true;
        }
    }
}
