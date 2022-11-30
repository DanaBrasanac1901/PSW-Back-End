using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.TenderOffer
{
    public class TenderOfferRepository : ITenderOfferRepository
    {
        private readonly IntegrationDbContext _context;

        public TenderOfferRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TenderOffer> GetAll()
        {
            return _context.TenderOffers.ToArray().ToList();
        }

        public TenderOffer GetById(int id, Guid bankId)
        {
            return _context.TenderOffers.Find(id, bankId);
        }

        public void Create(TenderOffer tenderOffer)
        {
            _context.TenderOffers.Add(tenderOffer);
            _context.SaveChanges();
        }

        public void Update(TenderOffer tenderOffer)
        {
            _context.Entry(tenderOffer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(TenderOffer tenderOffer)
        {
            _context.TenderOffers.Remove(tenderOffer);
            _context.SaveChanges();
        }
    }
}
