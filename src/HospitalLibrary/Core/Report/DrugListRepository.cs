using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class DrugListRepository
    {
        private readonly HospitalDbContext _context;

        public DrugListRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DrugList> GetAll()
        {
            return _context.DrugLists.ToList();
        }

        public DrugList GetById(int id)
        {
            return _context.DrugLists.Find(id);
        }

        public void Create(DrugList drugList)
        {
            _context.DrugLists.Add(drugList);
            _context.SaveChanges();
        }

        public void Update(DrugList drugList)
        {
            _context.Entry(drugList).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(DrugList drugList)
        {
            _context.DrugLists.Remove(drugList);
            _context.SaveChanges();
        }
    }
}
