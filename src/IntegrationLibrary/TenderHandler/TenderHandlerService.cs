using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Tender;
using HospitalLibrary.Core.TenderOffer;
using IntegrationLibrary.TenderHandler;
using Microsoft.AspNetCore.Builder;
using Org.BouncyCastle.Crypto.Tls;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HospitalLibrary.Core.Tender
{
    public class TenderHandlerService : ITenderHandlerService
    {
        ITenderOfferRepository _tenderOfferRepository;
        ITenderRepository _tenderRepository;

        public TenderHandlerService(ITenderOfferRepository tenderOfferRepository, ITenderRepository tenderRepository)
        {
            _tenderOfferRepository = tenderOfferRepository;
            _tenderRepository = tenderRepository;
        }

        public IEnumerable<TenderHandler> GetAll()
        {
            List<TenderHandler> list = new List<TenderHandler>();
            IEnumerable<Tender> tenders = _tenderRepository.GetAll();
            foreach (Tender tender in tenders)
                list.Add(new TenderHandler(tender,_tenderOfferRepository.GetAll().Where(e=>e.TenderId==tender.Id).ToList()));
            return list;
        }

        public TenderHandler GetById(int id)
        {
            List<TenderHandler> list = new List<TenderHandler>();
            IEnumerable<Tender> tenders = _tenderRepository.GetAll();
            foreach (Tender tender in tenders)
                if(tender.Id==id)
                return new TenderHandler(tender, _tenderOfferRepository.GetAll().Where(e => e.TenderId == tender.Id).ToList());
            return null;
        }

        public void CreateTender(Tender tender)
        {
            _tenderRepository.Create(tender);
        }



        public void UpdateTender(Tender tender)
        {
            _tenderRepository.Update(tender);
        }

        public void DeleteTender(Tender tender)
        {
            _tenderRepository.Delete(tender);
        }


        public void CreateOffer(TenderOffer.TenderOffer offer)
        {
             _tenderOfferRepository.Create(offer);
        }

        public void UpdateOffer(TenderOffer.TenderOffer offer)
        {
            _tenderOfferRepository.Update(offer);
        }

        public void DeleteOffer(TenderOffer.TenderOffer offer)
        {
            _tenderOfferRepository.Delete(offer);
        }
        
    }
}
