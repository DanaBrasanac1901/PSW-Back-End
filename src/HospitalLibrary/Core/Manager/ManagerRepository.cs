using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Core.Manager
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly HospitalDbContext _context;

        public ManagerRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Manager> GetAll()
        {
            return _context.Managers.ToList();
        }

        public Manager GetById(int id)
        {
            return _context.Managers.Find(id);
        }

        public void Create(Manager manager)
        {
            _context.Managers.Add(manager);
            _context.SaveChanges();
        }

        public void Update(Manager manager)
        {
            _context.Entry(manager).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Manager manager)
        {
            _context.Managers.Remove(manager);
            _context.SaveChanges();
        }
    }
}
