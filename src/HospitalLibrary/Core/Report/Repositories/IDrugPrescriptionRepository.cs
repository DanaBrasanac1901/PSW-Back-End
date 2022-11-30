using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public interface IDrugPrescriptionRepository
    {
        IEnumerable<DrugPrescription> GetAll();
        DrugPrescription GetById(string id);
        void Create(DrugPrescription drugPrescription);
        void Update(DrugPrescription drugPrescription);
        void Delete(DrugPrescription drugPrescription);
    }
}
