using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Blood
{
    public class BloodRequestRepository : IBloodRequestRepository
    {
        private readonly HospitalDbContext _context;

        public BloodRequestRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodRequest> GetAll()
        {
            return _context.BloodRequests.ToList();
        }

        public BloodRequest GetById(int id)
        {
            return _context.BloodRequests.Find(id);
        }

        public void Create(BloodRequest bloodRequest)
        {
            _context.BloodRequests.Add(bloodRequest);
            _context.SaveChanges();
        }

        public void Update(BloodRequest bloodRequest)
        {
            _context.Entry(bloodRequest).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(BloodRequest bloodRequest)
        {
            _context.BloodRequests.Remove(bloodRequest);
            _context.SaveChanges();
        } 
    }
}
