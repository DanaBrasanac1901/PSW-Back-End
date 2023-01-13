using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class HealthMeasurementsRepository : IHealthMeasurementsRepository
    {
        private readonly HospitalDbContext _context;

        public HealthMeasurementsRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<HealthMeasurements> GetAll()
        {
            return _context.HealthMeasurements.ToList();
        }
    }
}
