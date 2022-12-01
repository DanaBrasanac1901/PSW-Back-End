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
        
        public ReportApplicationService(IReportRepository reportRepository, IDrugPrescriptionRepository drugPrescriptionReposiotory)
        {
            _reportRepository = reportRepository;
            _drugPrescriptionReposiotory = drugPrescriptionReposiotory;
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
    }
}
