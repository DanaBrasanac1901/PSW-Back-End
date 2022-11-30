using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using Microsoft.AspNetCore.Builder;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HospitalLibrary.Core.TenderOffer
{
    public class TenderOfferService : ITenderOfferService
    {
        private readonly ITenderOfferRepository _tenderOfferRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public TenderOfferService(ITenderOfferRepository tenderOfferRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
        }
        public TenderOfferService(ITenderOfferRepository tenderOfferRepository, IDoctorRepository doctorRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<TenderOffer> GetAll()
        {
            return _tenderOfferRepository.GetAll();
        }

        public TenderOffer GetById(int id,Guid bankID)
        {
            return _tenderOfferRepository.GetById(id,bankID);
        }

        public void Create(TenderOffer tenderOffer)
        {

            _tenderOfferRepository.Create(tenderOffer);
        }
   

        public void Update(TenderOffer tenderOffer)
        {
            _tenderOfferRepository.Update(tenderOffer);
        }

        public void Delete(TenderOffer tenderOffer)
        {
            _tenderOfferRepository.Delete(tenderOffer);
        }

   
    }
}
