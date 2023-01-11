using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Builder;
using Org.BouncyCastle.Crypto.Tls;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HospitalLibrary.Core.Tender
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }
        public TenderService(ITenderRepository tenderRepository, IDoctorRepository doctorRepository)
        {
            _tenderRepository = tenderRepository;
            _doctorRepository = doctorRepository;
        }

        public TenderHandlerService TenderHandlerService
        {
            get => default;
            set
            {
            }
        }

        public IEnumerable<Tender> GetAll()
        {
            return _tenderRepository.GetAll();
        }

        public Tender GetById(int id)
        {
            return _tenderRepository.GetById(id);
        }

        public void Create(Tender tender)
        {

            _tenderRepository.Create(tender);
        }


        public void Update(Tender tender)
        {
            _tenderRepository.Update(tender);
        }

        public void Delete(Tender tender)
        {
            _tenderRepository.Delete(tender);
        }


    }
}
