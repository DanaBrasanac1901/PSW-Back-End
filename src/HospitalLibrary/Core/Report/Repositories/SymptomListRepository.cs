using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Repositories
{
    public class SymptomListRepository : ISymptomListRepository
    {
        private readonly HospitalDbContext _context;

        public SymptomListRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public List<SymptomList> GetAllSymptoms()
        {
            return _context.SymptomList.ToList();
        }
    }
}
