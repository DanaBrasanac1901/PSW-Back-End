using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;

namespace HospitalLibrary.Core.Report.Repositories
{
    public class DrugRepository : IDrugRepository
    {
        private readonly HospitalDbContext _context;

        public DrugRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Drug> GetAll()
        {
            return _context.Drugs.ToList();
        }


    }
}
