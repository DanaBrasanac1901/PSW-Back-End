using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Vacation.DTO
{
    public class VacationRequestDTOAdapter
    {
        public static VacationRequest VacationRequestDTOToObject(CreateVacationRequestDTO request)
        {
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest.DoctorId = "DOC1";

            string[] startDate = request.Start.Split('-');
            string[] endDate = request.End.Split('-');

            vacationRequest.Start = DateTime.Parse(request.Start);
            vacationRequest.End = DateTime.Parse(request.End);


            vacationRequest.Description = request.Description;
            vacationRequest.Urgency = false;
            vacationRequest.RejectionReason = "";
            vacationRequest.Status = Enums.VacationRequestStatus.WaitingForApproval;

            return vacationRequest;
        }

        public static ViewAllVacationRequestsDTO VacationRequestToDTO(VacationRequest request)
        {
            ViewAllVacationRequestsDTO requestDTO = new ViewAllVacationRequestsDTO();
            requestDTO.id = request.Id;
            requestDTO.start = request.Start.ToString();
            requestDTO.end = request.End.ToString();
            requestDTO.description = request.Description;
            requestDTO.doctorId = request.DoctorId;
            return requestDTO;
        }

        public static VacationRequest CreateUrgenVacationDTOToVacationRequest(CreateUrgenVacationDTO dto)
        {
            VacationRequest request = new VacationRequest();
            request.Id = (int)DateTime.Now.Ticks;
            request.Start = DateTime.Parse(dto.start);
            request.End = DateTime.Parse(dto.end);
            request.Description = dto.description;
            request.Urgency = true;
            request.DoctorId = "DOC1";
            request.RejectionReason = "nista";
            request.Status = Enums.VacationRequestStatus.Accepted;
            return request;
        }

    }
}
