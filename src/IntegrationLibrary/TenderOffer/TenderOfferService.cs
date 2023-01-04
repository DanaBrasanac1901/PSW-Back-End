using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Tender;
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
        private readonly ITenderService _tenderService;

        public TenderOfferService(ITenderOfferRepository tenderOfferRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
        }
        public TenderOfferService(ITenderOfferRepository tenderOfferRepository, ITenderService tenderService)
        {
            _tenderService = tenderService;
            _tenderOfferRepository = tenderOfferRepository;
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

        public TenderOffer GetByTender(int id)
        {
            foreach(TenderOffer TO in _tenderOfferRepository.GetAll())
            {
                if(TO.TenderId == id)
                    return TO;
            }
            return null;
        }

        public void AcceptTender(TenderOffer offer)
        {
            _tenderService.Delete(_tenderService.GetById(offer.TenderId));
        }
    }
}
