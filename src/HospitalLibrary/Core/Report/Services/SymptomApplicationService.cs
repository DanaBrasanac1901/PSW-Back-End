using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Core.Report.Repositories;
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
        private readonly ISymptomListRepository _symptomListRepository;

        public SymptomApplicationService(ISymptomRepository symptomRepository,ISymptomListRepository symptomListRepository)
        {
            _symptomRepository = symptomRepository;
            _symptomListRepository = symptomListRepository;
        }

        

        public IEnumerable<SymptomDTO> GetAllSymptoms()
        {
            List<SymptomDTO> returnList = new List<SymptomDTO>();
            foreach (var symptom in _symptomListRepository.GetAllSymptoms())
            {
                returnList.Add(new SymptomDTO(symptom.Name));
            }
            return returnList;
        }
    }
}
