using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.TenderOffer
{
    public interface ITenderOfferRepository
    {

        public IEnumerable<TenderOffer> GetAll();
        public TenderOffer GetById(int id,Guid bankId);
        public void Create(TenderOffer tenderOffer);
        public void Update(TenderOffer tenderOffer);
        public void Delete(TenderOffer tenderOffer);
    }
}
