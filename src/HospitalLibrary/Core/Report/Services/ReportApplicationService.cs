using HospitalLibrary.Core.Report.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Core.Report.Repositories;

namespace HospitalLibrary.Core.Report.Services
{
    public class ReportApplicationService : IReportApplicationService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IDrugPrescriptionRepository _drugPrescriptionReposiotory;
        private readonly ISymptomRepository _symptomRepository;

        public ReportApplicationService(IReportRepository reportRepository, IDrugPrescriptionRepository drugPrescriptionReposiotory,
            ISymptomRepository symptomRepository)
        {
            _reportRepository = reportRepository;
            _drugPrescriptionReposiotory = drugPrescriptionReposiotory;
            _symptomRepository = symptomRepository;
        }

        public List<SearchResultReportDTO> GetPrescriptionsContaining(string[] searchWords)
        {
            List<Model.Report> allReports = (List<Model.Report>)_reportRepository.GetAll();

            List<SearchResultReportDTO> matchingReports = new List<SearchResultReportDTO>();


            foreach (Model.Report report in allReports)
            {
                Model.Report reportForDTO = report.ContainsAny(searchWords);
                if (reportForDTO != null)
                    matchingReports.Add(ReportAdapter.CreateSearchResultDTO(report));
                
            }

            return matchingReports;
        }

        public ReportApplicationService(IReportRepository reportRepository,
            ISymptomRepository symptomRepository)
        {
            _reportRepository = reportRepository;
            _symptomRepository = symptomRepository;
        }


        public void Create(ReportToCreateDTO dto)
        {
            Report.Model.Report report = ReportAdapter.ReportToCreateDTOToReport(dto);
            DrugPrescription drugPrescription = ReportAdapter.CreateDrugPrescription(report.Id, dto);
            _reportRepository.Create(report);
            _drugPrescriptionReposiotory.Create(drugPrescription);
            //pozove drugprescription da napravi
            //_reportRepository.Create(report);
        }

        public void Delete(Report.Model.Report report)
        {
            _reportRepository.Delete(report);
        }

        public IEnumerable<Report.Model.Report> GetAll()
        {
            return _reportRepository.GetAll();
        }

        public Report.Model.Report GetById(string id)
        {
            return _reportRepository.GetById(id);
        }

        public void Update(Report.Model.Report report)
        {
            _reportRepository.Update(report);
        }

        public bool IsSymptomExist(ICollection<Symptom> symptoms,string id)
        {
            //var report = _reportRepository.GetById(id);
            //ICollection<Symptom> symptom = report.Symptoms;
            //foreach (var symp in symptom)
            //{
            //    if(!symptoms.Contains(symp)) return false;
            //}
            return true;
        }

        private Report.Model.Report GetReportByAppointmentId(string appointmentId)
        {
            foreach (var report in _reportRepository.GetAll())
            {
                if(report.AppointmentId == appointmentId)
                {
                    return report;
                }
            }
            return null;
        }
        public ICollection<Drug> GetDrugFromReport(string reportId)
        {
            foreach (var drug in _reportRepository.GetAll())
            {
                if (drug.Id == reportId)
                {
                    return drug.Drugs;
                }
             
            }
            return null;
        }

        public ReportToShowDTO GetReportToShow(string id)
        {

            return ReportAdapter.ReportToReportToShowDTO(GetReportByAppointmentId(id));
        }

        public DrugPrescriptionToShowDTO GetDrugToShow(string id)
        {
            return ReportAdapter.DrugPrescriptionToDrugPrescriptionToShowDTO(GetById(id));
        }

        
    }
}
