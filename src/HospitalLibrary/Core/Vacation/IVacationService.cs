using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Vacation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation
{
    public interface IVacationService
    {
        IEnumerable<VacationRequest> GetAll();
        VacationRequest GetById(int id);
        void CreateVacationRequest(VacationRequest vacationRequest);
        string CreateUrgentVacationRequest(CreateUrgenVacationDTO vacationRequest);
        void UpdateVacationRequest(VacationRequest vacationRequest);
        void Cancel(int requestId);
        void Disapprove(int requestId);
        //bool CheckIfVacationIsSetInFuture(DateTime dateToCheck);
        bool VacationTooClose(DateTime startDate);
        IEnumerable<ViewAllVacationRequestsDTO> GetAllByDoctor(int id);
        int GenerateId();
    }
}
