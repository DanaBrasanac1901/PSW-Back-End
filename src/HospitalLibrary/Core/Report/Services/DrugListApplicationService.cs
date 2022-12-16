using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Core.Report.Repositories;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public class DrugListApplicationService: IDrugListApplicationService
    {
        private readonly IDrugListRepository _drugListRepository;

        public DrugListApplicationService(IDrugListRepository drugListRepository)
        {
            _drugListRepository = drugListRepository;
        }

        public IEnumerable<DrugList> GetAllDrugList()
        {
            return _drugListRepository.GetAll();
        }


    }
}
