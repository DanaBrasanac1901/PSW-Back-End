using HospitalLibrary.Core.Appointment;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Advertisements
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly IntegrationDbContext _context;
        public AdvertisementRepository(IntegrationDbContext context) {
            _context = context;
        }

        public IEnumerable<Advertisement> GetAll()
        {
            return _context.Advertisements.ToList();
        }
    }
}
