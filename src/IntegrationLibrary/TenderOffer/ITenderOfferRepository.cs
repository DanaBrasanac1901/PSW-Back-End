using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.TenderOffer
{
    public interface ITenderOfferRepository
    {
        IEnumerable<TenderOffer> GetAll();
        TenderOffer GetById(int id,Guid bankId);
        void Create(TenderOffer tenderOffer);
        void Update(TenderOffer tenderOffer);
        void Delete(TenderOffer tenderOffer);
    }
}
