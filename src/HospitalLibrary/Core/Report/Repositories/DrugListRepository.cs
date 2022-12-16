using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Repositories
{
    public class DrugListRepository : IDrugListRepository
    {
        private readonly HospitalDbContext _context;

        public DrugListRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DrugList> GetAll()
        {
            return _context.DrugsList.ToList();
        }


    }
}
