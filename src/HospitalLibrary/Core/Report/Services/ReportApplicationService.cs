using HospitalLibrary.Core.Report.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Core.Report.Repositories;
using HospitalLibrary.Core.Infrastructure;

namespace HospitalLibrary.Core.Report.Services
{
    public class ReportApplicationService : IReportApplicationService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IDrugPrescriptionRepository _drugPrescriptionReposiotory;
        private readonly ISymptomRepository _symptomRepository;
        private readonly IEventRepository _eventRepository;

        public ReportApplicationService(IReportRepository reportRepository, IDrugPrescriptionRepository drugPrescriptionReposiotory,
            ISymptomRepository symptomRepository, IEventRepository eventRepository)
        {
            _reportRepository = reportRepository;
            _drugPrescriptionReposiotory = drugPrescriptionReposiotory;
            _symptomRepository = symptomRepository;
            _eventRepository = eventRepository;
        }

        public ReportApplicationService(IReportRepository reportRepository,
            ISymptomRepository symptomRepository, IEventRepository eventRepository)
        {
            _reportRepository = reportRepository;
            _symptomRepository = symptomRepository;
            _eventRepository = eventRepository;

        }


        //kada se dodje na stranicu na front-u salje se http request koji
        //ce da pozove konstruktor objekta report koji mu dodeljuje id 
        //i postavlja current_step na 0, taj id se vrati na front

        //svaki put kad se klikne na neko dugme na frontu posalje se http req sa id-em agregata i na osnovu 
        //njega se poziva odgovarajuca metoda agregata

        //kad se klikne na finish dugme na frontu tada se popune sva polja 
        //report objekta na beku na osnovu dto sa fronta (do tad ima sustinski prazna polja)

        public string InstantiateReport()
        {
            var list = _reportRepository.GetAll();
            string flag = (list.ToList().Count + 1).ToString();
            Model.Report report = new Model.Report(flag);
            _reportRepository.Create(report);
            return report.Id;
        }

        public void SetReportFields(string id, ReportToCreateDTO dto)
        {
            Report.Model.Report report = _reportRepository.GetById(id);

            report = ReportAdapter.SetFields(report, dto);
            DomainEvent domainEvent = report.FinishedCreating();

            _reportRepository.Update(report);
            _eventRepository.Create(domainEvent);
        }

        public DomainEvent HandleClick(string id, int click)
        {
            Report.Model.Report report = _reportRepository.GetById(id);

            DomainEvent domainEvent = null;

            if (click == 1)
                domainEvent = report.ClickedOnNextButton();
            else if (click == -1)
                domainEvent = report.ClickedOnBackButton();
           
            _reportRepository.Update(report);
            _eventRepository.Create(domainEvent);

            return domainEvent;
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
