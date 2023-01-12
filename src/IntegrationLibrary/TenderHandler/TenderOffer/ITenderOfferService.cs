using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.TenderOffer
{
    public interface ITenderOfferService
    {

        IEnumerable<TenderOffer> GetAll();
        TenderOffer GetById(int id,Guid bankId);
        TenderOffer GetByTender(int id);
        void Create(TenderOffer tenderOffer);
        void Update(TenderOffer tenderOffer);
        void Delete(TenderOffer tenderOffer);
        
     
    }
}
