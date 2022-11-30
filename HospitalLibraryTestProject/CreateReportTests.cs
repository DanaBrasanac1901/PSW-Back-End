using HospitalLibrary.Core.Report;
using HospitalLibrary.Core.Report.Services;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class CreateReportTests
    {  
        [Fact]

        public void Can_Get_Drug()
        {
            var getDrug = new Mock<IDrugPrescriptionApplicationService>();
            DrugPrescriptionApplicationService service = new DrugPrescriptionApplicationService(CreateDrugPrescription(),CreateDrug());
            bool check = service.IsDrugExist(CreateDrugList(), "PRESC1");
            Assert.True(check);
        }

        [Fact]
        public void Have_Symptom_In_DB()
        {
            var haveSymptom = new Mock<IReportApplicationService>();
            ReportApplicationService service = new ReportApplicationService(CreateReport(), CreateSymptom());
            bool check = service.IsSymptomExist(CreateSymptomList(), "RET1");
            Assert.True(check);
        }





        public static IReportRepository CreateReport()
        {
            var stubRepo = new Mock<IReportRepository>();
            var stubRepo1= new Mock<IDrugPrescriptionRepository>();
            var stubRepo2= new Mock<IDrugRepository>();
            var stubRepo3= new Mock<ISymptomRepository>();
            var reports = new List<Report>();
            var drugPrescriptions= new List<DrugPrescription>();    
            var symptoms = new List<Symptom>();
            var symp1=new Symptom("kijavica");
            symptoms.Add(symp1);
            var drugs=new List<Drug>();
            var drug1 = new Drug("brufen 200mg", "Galenika");
            drugs.Add(drug1);
            var rep1 = new Report("RET1", "PAT1", "DOC1", "description", symptoms, new DateTime(2022, 11, 27, 12, 0, 0));
            var presc1 = new DrugPrescription("PRESC1", "RET1", drugs);
            reports.Add(rep1);
            drugPrescriptions.Add(presc1);

            stubRepo.Setup(m=> m.GetById("RET1")).Returns(rep1);

            return stubRepo.Object;

        }
        public static IDrugPrescriptionRepository CreateDrugPrescription()
        {
            var stubRepo1 = new Mock<IDrugPrescriptionRepository>();
            var drugPrescriptions = new List<DrugPrescription>();
            var drugs = new List<Drug>();
            var drug1 = new Drug("brufen 200mg", "Galenika");
            drugs.Add(drug1);
            DrugPrescription presc1 = new DrugPrescription("PRESC1", "RET1", drugs);
            drugPrescriptions.Add(presc1);

            stubRepo1.Setup(m => m.GetById("PRESC1")).Returns(presc1);

            return stubRepo1.Object;    
        }

        public  ICollection<Drug> CreateDrugList()
        {
            //var stubRepo2 = new Mock<IDrugRepository>();
            ICollection<Drug> drugs = new List<Drug>();
            var drug1 = new Drug("brufen 200mg", "Galenika");
            drugs.Add(drug1);

            

            return  drugs;

        }
        public static IDrugRepository CreateDrug()
        {
            var stubRepo2 = new Mock<IDrugRepository>();
            var drugs = new List<Drug>();
            var drug1 = new Drug("brufen 200mg", "Galenika");
            drugs.Add(drug1);

            stubRepo2.Setup(m => m.GetAll()).Returns(drugs.AsEnumerable<Drug>);


            return stubRepo2.Object;

        }

        public static ISymptomRepository CreateSymptom()
        {
            var stubRepo3 = new Mock<ISymptomRepository>();

            var symptoms = new List<Symptom>();
            var symp1 = new Symptom("kijavica");
            symptoms.Add(symp1);

            stubRepo3.Setup(m => m.GetAll()).Returns(symptoms.AsEnumerable<Symptom>);

            return stubRepo3.Object;
        }

        public ICollection<Symptom> CreateSymptomList()
        {
           

            ICollection<Symptom> symptoms = new List<Symptom>();
            var symp1 = new Symptom("kijavica");
            symptoms.Add(symp1);



            return symptoms;
        }

    }
}
