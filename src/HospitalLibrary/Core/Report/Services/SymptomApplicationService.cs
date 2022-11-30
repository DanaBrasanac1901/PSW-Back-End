using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public class SymptomApplicationService : ISymptomApplicationService
    {
        private readonly ISymptomRepository _symptomRepository;

        public SymptomApplicationService(ISymptomRepository symptomRepository)
        {
            _symptomRepository = symptomRepository;
        }

        public IEnumerable<Symptom> GetAllSymptoms()
        {
            return _symptomRepository.GetAll();
        }
    }
}
