using HospitalLibrary.Core.Report.Model;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Report.Services
{
    public interface IDrugPrescriptionApplicationService
    {
        void Create(DrugPrescription drugPrescription);
        void Delete(DrugPrescription drugPrescription);
        IEnumerable<DrugPrescription> GetAll();
        DrugPrescription GetById(string id);
        void Update(DrugPrescription drugPrescription);

        bool IsDrugExist(ICollection<Drug> drugs, string id);
    }
}