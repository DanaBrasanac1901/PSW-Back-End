using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Appointment.DTOS;
using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Doctor.DTOS;
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
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public VacationService(IVacationRepository vacationRequestRepository, IDoctorRepository doctorRepository, IAppointmentRepository appointmentRepository)
        {
            _vacationRequestRepository = vacationRequestRepository;
            _doctorRepository = doctorRepository;
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
            {
                if(request.Status == VacationRequestStatus.Accepted || 
                    request.Status == VacationRequestStatus.WaitingForApproval)
                    requestsDTO.Add(VacationRequestDTOAdapter.VacationRequestToDTO(request));
            }
                

            return requestsDTO;
        }

        public void CreateVacationRequest(VacationRequest request)
        {
            //pretpostavimo da imamo ulogovanog doktora pa ne mora da se get-uje iz repo (skloniti repo iz klase)
            Doctor.Doctor doctor = _doctorRepository.GetById("DOC1");
            if (doctor.IsAvailable(request.Start, request.End) && !VacationTooClose(request.Start))
                _vacationRequestRepository.Create(request);
        }

        public string CreateUrgentVacationRequest(CreateUrgenVacationDTO dto)
        {
            VacationRequest request = VacationRequestDTOAdapter.CreateUrgenVacationDTOToVacationRequest(dto);
            List<bool> parameters = parametersForUrgentRequest(request);
            if (parameters[0] == false
                && parameters[1] == true
                && parameters[2] == true
                && parameters[3] == true)
            {
                parameters.Add(false);
                _vacationRequestRepository.Create(request);
            }
            else if (parameters[0] == true)
            {
                parameters.Add(false);
                var apps = GetAppointmentsUrgentVacation(request.DoctorId,dto.start,dto.end);
                List<Doctor.Doctor> docs = new List<Doctor.Doctor>();
                foreach(var app in apps)
                {
                    docs = GetFreeDoctors(app.Start);
                    if (docs == null){
                        parameters[4] = true;
                        return ResponseHandler(parameters);
                    }
                    ChangeDoctorForAppointment(docs[0].Id, app.Id);
                }
                
            }
            
            return ResponseHandler(parameters);
        }

        public void ChangeDoctorForAppointment(string doctorId, string appointmentId)
        {
            var appointment = _appointmentRepository.GetById(appointmentId);

            if (CheckIfAppointmentExistsForDoctor(doctorId, appointment.Start) == true)
            {
                appointment.DoctorId = doctorId;
                _appointmentRepository.Update(appointment);
            }

        }

        public Boolean CheckIfAppointmentExistsForDoctor(string doctorId, DateTime start)
        {

            foreach (var app in _appointmentRepository.GetAll())
            {
                if (app.DoctorId == doctorId && app.Start == start)
                {
                    return false;
                }
            }
            return true;
        }

        public List<Appointment.Appointment> ReturnListGetAppointmentsUrgentVacation(ICollection<Appointment.Appointment> apps,
            List<DateTime> startAndEnd)
        {
            List<Appointment.Appointment> returnList = new List<Appointment.Appointment>();
            foreach (var app in apps)
            {
                if (app.Start >= startAndEnd[0] && app.Start <= startAndEnd[1])
                {
                    returnList.Add(app);
                }
            }
            return returnList;
        }

        public List<Appointment.Appointment> GetAppointmentsUrgentVacation(string id, string start, string end)
        {
            List<DateTime> timeRange = VacationRequestDTOAdapter.UrgentVacationParametersHandling(start, end);
            return ReturnListGetAppointmentsUrgentVacation(_doctorRepository.GetById(id).Appointments, timeRange);
        }



        public List<Doctor.Doctor> GetFreeDoctors(DateTime start)
        {
            List<Doctor.Doctor> returnList = new List<Doctor.Doctor>();

            foreach (var doc in _doctorRepository.GetAll())
            {
                if (CheckIfDoctorIsBusy(doc.Appointments, start) == true)
                {
                    returnList.Add(doc);
                }

            }
            return returnList;
        }
        public Boolean CheckIfDoctorIsBusy(ICollection<Appointment.Appointment> apps, DateTime start)
        {
            foreach (var app in apps)
            {
                if (app.Start.Equals(start))
                {
                    return false;
                }
            }
            return true;
        }

        public List<bool> parametersForUrgentRequest(VacationRequest request)
        {
            List<bool> retList = new List<bool>();
            if(CheckIfThereAreAppointmentsInRange(request.Start, request.End, request.DoctorId) == false)
            {
                retList.Add(false);
            }
            else
            {
                retList.Add(true);
            }
            if (IsUrgentAvailable(request.Start, request.End, request.DoctorId) == true)
            {
                retList.Add(true);
            }
            else
            {
                retList.Add(false);
            }
            if (DateIsInFuture(request.Start) == true)
            {
                retList.Add(true);
            }
            else
            {
                retList.Add(false);
            }
            if (StartIsBeforeEnd(request.Start, request.End) == true)
            {
                retList.Add(true);
            }
            else
            {
                retList.Add(false);
            }
            return retList;
        }

        public string ResponseHandler(List<bool> parameters)
        {
            if(parameters[4] == true)
            {
                return "NO DOCTORS";
            }
            else if (parameters[3] == false)
            {
                return "End of the vacation is before start! Pick carefully.";
            }
            else if(parameters[2] == false)
            {
                return "Cant take vacation in past! Set time span in future.";
            }
            else if (parameters[1] == false)
            {
                return "You already have vacation in choosen time span!";
            }
            else if (parameters[0] == true)
            {
                return "You have appointment(s) in choosen time span!";
            }
            else
            {
                return "Request created.";
            }

        }

        public bool CheckIfThereAreAppointmentsInRange(DateTime start,DateTime end,String doctorId)
        {
            List<Appointment.Appointment> allApps = _appointmentRepository.GetAll().ToList();
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

        public bool IsUrgentAvailable(DateTime start, DateTime end, String doctorId)
        {
            foreach (var vacation in _vacationRequestRepository.GetAll())
            {
                if(vacation.DoctorId == doctorId && (start >= vacation.Start && start <= vacation.End) && ((start >= vacation.Start && start <= vacation.End)))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DateIsInFuture(DateTime start)
        {
            if(start > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public bool StartIsBeforeEnd(DateTime start,DateTime end)
        {
            if (start < end)
                return true;
            return false;
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
