using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Core.Report.Repositories;
using HospitalLibrary.Core.Report.Services;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class ReportAndPrescriptionSearch
    {
        [Fact]
        public void Has_matches()
        {
            ReportApplicationService reportService = new ReportApplicationService(CreateReportRepository(), CreateSymptomRepository());
            string[] searchWords = { "severe headache", "Galenika", "fatigue" };

            List<SearchResultReportDTO> containing = reportService.GetSearchMatches(searchWords);

            Assert.True(containing.Count==3);
        }


        [Fact]
        public void Has_no_matches()
        {
            ReportApplicationService reportService = new ReportApplicationService(CreateReportRepository(), CreateSymptomRepository());
            string[] searchWords = { "Hemofarm", "back pain" };

            List<SearchResultReportDTO> containing = reportService.GetSearchMatches(searchWords);

            Assert.True(containing.Count == 0);
        }



        private IReportRepository CreateReportRepository()
        {
            var stubRepo = new Mock<IReportRepository>();
            var reports = new List<Report>();
            var prescriptions = new List<Drug>();



            prescriptions.Add(new Drug("Bromazepam 3mg", "Tralala"));
            prescriptions.Add(new Drug("Panadol Extra Advance", "Neka druga firma"));
            prescriptions.Add(new Drug("Fervex", "Neka treca firma"));


            Report report = new Report("1", "PAT1", "DOC1", "the patient reported severe headaches", new List<Symptom>(), new DateTime(2022, 12, 21), prescriptions);
            reports.Add(report);



            prescriptions = new List<Drug>();
            prescriptions.Add(new Drug("Prospan", "Galenika"));
            prescriptions.Add(new Drug("Panadol", "Neka druga firma"));
            prescriptions.Add(new Drug("Bromazepam 5mg", "Galenika"));

            report = new Report("2", "PAT2", "DOC2", "has bad cough", new List<Symptom>(), new DateTime(2022, 12, 21), prescriptions);
            reports.Add(report);



            prescriptions = new List<Drug>();
            prescriptions.Add(new Drug("Coldrex", "Random ime"));
            prescriptions.Add(new Drug("Coldrex jagoda", "Random ime"));

            List<Symptom> symptoms = new List<Symptom>();
            symptoms.Add(new Symptom("high temperature"));
            symptoms.Add(new Symptom("torn muscles"));


            report = new Report("3", "PAT3", "DOC1", "patient has stomach ache", symptoms, new DateTime(2022, 12, 21), prescriptions);
            reports.Add(report);



            prescriptions = new List<Drug>();
            prescriptions.Add(new Drug("Coldrex", "Random ime"));
            prescriptions.Add(new Drug("Coldrex jagoda", "Random ime"));


            symptoms = new List<Symptom>();
            symptoms.Add(new Symptom("high temperature"));
            symptoms.Add(new Symptom("fatigue"));


            report = new Report("4", "PAT3", "DOC1", "patient has stomach ache", symptoms, new DateTime(2022, 12, 21), prescriptions);
            reports.Add(report);

            stubRepo.Setup(m => m.GetAll()).Returns(reports);

            return stubRepo.Object;
        }


        private ISymptomRepository CreateSymptomRepository()
        {
            var stubRepo = new Mock<ISymptomRepository>();

            return stubRepo.Object;
        }
    }
}
