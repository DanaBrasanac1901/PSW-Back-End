using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class SymptomRepository:ISymptomRepository
    {
        private readonly HospitalDbContext _context;

        public SymptomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _context.Symptoms.ToList();
        }


    }
}
