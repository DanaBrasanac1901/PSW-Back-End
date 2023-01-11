using System.Collections.Generic;
using HospitalLibrary.Core.TenderOffer;
using IntegrationLibrary.TenderHandler;

namespace HospitalLibrary.Core.Tender
{
    public interface ITenderHandlerService
    {

        IEnumerable<TenderHandler> GetAll();
        TenderHandler GetById(int id);
        void CreateTender(Tender tender);
        void UpdateTender(Tender tender);
        void DeleteTender(Tender tender);
        void CreateOffer(TenderOffer.TenderOffer offer);
        void UpdateOffer(TenderOffer.TenderOffer offer);
        void DeleteOffer(TenderOffer.TenderOffer offer);
    }
}
