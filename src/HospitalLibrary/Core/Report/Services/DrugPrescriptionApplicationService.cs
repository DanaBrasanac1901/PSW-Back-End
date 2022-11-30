using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public class DrugPrescriptionApplicationService : IDrugPrescriptionApplicationService
    {
        private readonly IDrugPrescriptionRepository _drugPrescriptionRepository;
        private readonly IDrugRepository _drugRepository;

        public DrugPrescriptionApplicationService(IDrugPrescriptionRepository drugPrescriptionRepository,IDrugRepository drugRepository)
        {
            _drugPrescriptionRepository = drugPrescriptionRepository;
            _drugRepository = drugRepository;   
        }

        public void Create(DrugPrescription drugPrescription)
        {

            _drugPrescriptionRepository.Create(drugPrescription);

            //DrugPrescription drugPrescription = 
            //pozove drugprescription da napravi
            //_reportRepository.Create(report);
        }

        public void Delete(DrugPrescription drugPrescription)
        {
            _drugPrescriptionRepository.Delete(drugPrescription);
        }

        public IEnumerable<DrugPrescription> GetAll()
        {
            return _drugPrescriptionRepository.GetAll();
        }

        public DrugPrescription GetById(string id)
        {
            return _drugPrescriptionRepository.GetById(id);
        }

        public void Update(DrugPrescription drugPrescription)
        {
            _drugPrescriptionRepository.Update(drugPrescription);
        }

        public bool IsDrugExist(ICollection<Drug> drugs, string id)
        {
            var  prescription=_drugPrescriptionRepository.GetById(id);
            ICollection<Drug> drugsOnPrescription = prescription.Drugs;
            foreach (var drug in drugsOnPrescription)
            {
                if (!drugs.Contains(drug)) return false;
              
            }
            return true;  
            
        }
    }
}
