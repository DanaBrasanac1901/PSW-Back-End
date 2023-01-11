
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Tender
{
    public class TenderRepository : ITenderRepository
    {
        private readonly IntegrationDbContext _context;

        public TenderRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tender> GetAll()
        {
            return _context.Tenders.ToArray().ToList();
        }

        public Tender GetById(int id)
        {
            return _context.Tenders.Find(id);
        }

        public void Create(Tender tender)
        {
            _context.Tenders.Add(tender);
            _context.SaveChanges();
        }

        public void Update(Tender tender)
        {
            _context.Entry(tender).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Tender tender)
        {
            _context.Tenders.Remove(tender);
            _context.SaveChanges();
        }
    }
}
