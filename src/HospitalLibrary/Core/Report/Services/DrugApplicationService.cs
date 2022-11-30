using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public class DrugApplicationService : IDrugApplicationService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugApplicationService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public IEnumerable<Drug> GetAll()
        {
            return _drugRepository.GetAll();
        }
    }
}
