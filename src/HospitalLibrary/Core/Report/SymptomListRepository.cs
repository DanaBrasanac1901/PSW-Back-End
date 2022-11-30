using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class SymptomListRepository
    {
        private readonly HospitalDbContext _context;

        public SymptomListRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SymptomList> GetAll()
        {
            return _context.SymptomLists.ToList();
        }

        public SymptomList GetById(string id)
        {
            return _context.SymptomLists.Find(id);
        }

        public void Create(SymptomList symptomList)
        {
            _context.SymptomLists.Add(symptomList);
            _context.SaveChanges();
        }

        public void Update(SymptomList symptomList)
        {
            _context.Entry(symptomList).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(SymptomList symptomList)
        {
            _context.SymptomLists.Remove(symptomList);
            _context.SaveChanges();
        }
    }
}

