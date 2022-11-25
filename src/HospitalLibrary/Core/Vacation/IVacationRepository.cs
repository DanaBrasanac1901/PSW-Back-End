using HospitalLibrary.Core.Blood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation
{
    public interface IVacationRepository
    {
        IEnumerable<VacationRequest> GetAll();
        VacationRequest GetById(int id);
        void Create(VacationRequest vacationRequest);
        void Update(VacationRequest vacationRequest);
        void Delete(VacationRequest vacationRequest);
        IEnumerable<VacationRequest> GetAllByDoctor(string id);
    }
}
