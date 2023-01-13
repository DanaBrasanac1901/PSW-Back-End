using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class HealthMeasurementsService : IHealthMeasurementsService
    {
        private readonly IHealthMeasurementsRepository _repository;

        public HealthMeasurementsService(IHealthMeasurementsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<HealthMeasurements> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
