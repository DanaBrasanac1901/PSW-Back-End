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
        public void Has_matching_words()
        {
            ReportApplicationService reportService = new ReportApplicationService(CreateReportRepository(), CreateSymptomRepository());
            string[] searchWords = { "Coldrex"};

            List<SearchResultReportDTO> containing = reportService.GetPrescriptionsContaining(searchWords);

            Assert.True(containing.Count==1);
        }





        private IReportRepository CreateReportRepository()
        {
            var stubRepo = new Mock<IReportRepository>();

            var reports = new List<Report>();

            var prescriptions = new List<Drug>();

            prescriptions.Add(new Drug("Bromazepam 3mg", "Galenika"));
            prescriptions.Add(new Drug("Panadol Extra Advance", "Neka druga firma"));
            prescriptions.Add(new Drug("Fervex", "Neka treca firma"));


            Report report = new Report("1", "PAT1", "DOC1", "mans sick", new List<Symptom>(), new DateTime(2022, 12, 21), prescriptions);
            reports.Add(report);

            prescriptions = new List<Drug>();

            prescriptions.Add(new Drug("Prospan", "Galenika"));
            prescriptions.Add(new Drug("Panadol", "Neka druga firma"));
            prescriptions.Add(new Drug("Bromazepam 5mg", "Galenika"));

            report = new Report("2", "PAT1", "DOC1", "mans sick", new List<Symptom>(), new DateTime(2022, 12, 21), prescriptions);
            reports.Add(report);

            prescriptions = new List<Drug>();

            prescriptions.Add(new Drug("Coldrex", "Galenika"));
            prescriptions.Add(new Drug("Coldrex jagoda", "Galenika"));


            report = new Report("2", "PAT1", "DOC1", "mans sick", new List<Symptom>(), new DateTime(2022, 12, 21), prescriptions);
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
