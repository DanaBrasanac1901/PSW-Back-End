using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;

namespace HospitalLibrary.Core.Report.Repositories
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
