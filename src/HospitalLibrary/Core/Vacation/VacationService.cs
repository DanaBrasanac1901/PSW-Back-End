using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Vacation.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRequestRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public VacationService(IVacationRepository vacationRequestRepository,IAppointmentRepository appointmentRepository)
        {
            _vacationRequestRepository = vacationRequestRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<VacationRequest> GetAll()
        {
            return _vacationRequestRepository.GetAll();
        }

        public VacationRequest GetById(int id)
        {
            return _vacationRequestRepository.GetById(id);
        }

        //sta je ovo?
        /*
        public Boolean CheckIfVacationIsSetInFuture(DateTime dateToCheck)
        {
            DateTime dateTimeNow = DateTime.Now;
            if (dateTimeNow.Year > dateToCheck.Year)
            {
                return true;
            }
            else if (dateTimeNow.Month > dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year)
            {
                return true;
            }
            else if (dateTimeNow.Day >= dateToCheck.Day && dateTimeNow.Month >= dateToCheck.Month && dateTimeNow.Year >= dateToCheck.Year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        public int GenerateId()
        {
            List<int> ids = new List<int>();
            IEnumerable<VacationRequest> requests = _vacationRequestRepository.GetAll();
            ids = requests.Select(r => r.Id).ToList();
            if (ids.Count == 0)
                return 0;
            else
                return ids.Max() + 1;
        }

        public void Cancel(int requestId)
        {
            VacationRequest request = _vacationRequestRepository.GetById(requestId);
            request.Status = VacationRequestStatus.Cancelled;
            _vacationRequestRepository.Update(request);
        }

        public void Disapprove(int requestId)
        {
            VacationRequest request = _vacationRequestRepository.GetById(requestId);
            request.Status = VacationRequestStatus.Disapproved;
            _vacationRequestRepository.Update(request);
        }

        public IEnumerable<ViewAllVacationRequestsDTO> GetAllByDoctor(string id)
        {
            IEnumerable<VacationRequest> doctorsVacationRequests = _vacationRequestRepository.GetAllByDoctor(id);
           
            List<ViewAllVacationRequestsDTO> requestsDTO = new List<ViewAllVacationRequestsDTO>();
            
            foreach (VacationRequest request in doctorsVacationRequests)
                requestsDTO.Add(VacationRequestDTOAdapter.VacationRequestToDTO(request));

            return requestsDTO;
        }

        public void CreateVacationRequest(VacationRequest request)
        {
            //pretpostavimo da imamo ulogovanog doktora pa ne mora da se get-uje
            Doctor.Doctor doctor = new Doctor.Doctor();
            if (doctor.IsAvailable(request.Start, request.End) && !VacationTooClose(request.Start))
                _vacationRequestRepository.Create(request);
        }

        public void CreateUrgentVacationRequest(VacationRequest request)
        {
            //pretpostavimo da imamo ulogovanog doktora pa ne mora da se get-uje
            //Doctor.Doctor doctor = new Doctor.Doctor();
            if (CheckIfThereAreAppointmentsInRange(request.Start, request.End, request.DoctorId) == false)
            {
                _vacationRequestRepository.Create(request);
            }
        }

        public bool CheckIfThereAreAppointmentsInRange(DateTime start,DateTime end,String doctorId)
        {
            List<Appointment.Appointment> allApps = _appointmentRepository.GetAll().ToList();
            //List<Appointment.Appointment> retApps = new List<Appointment.Appointment>();
            foreach (var app in allApps)
            {
                if(app.DoctorId == doctorId && CheckIfAppointmentIsInRange(app,start,end) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckIfAppointmentIsInRange(Appointment.Appointment app, DateTime start, DateTime end)
        {
            if (app.Start < start || app.Start > end)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void IsUrgentAvailable(VacationRequest request, Doctor.Doctor doctor)
        {
            
        }

        public void UpdateVacationRequest(VacationRequest vacationRequest)
        {
            throw new NotImplementedException();
        }

        public bool VacationTooClose(DateTime startDate)
        {
            TimeSpan difference = startDate - DateTime.Now;

            if (difference.TotalDays >= 5)
                return false;

            else return true;
        }
    }
}
