using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    class ConsiliumRepository  : IConsiliumRepository
    {
        private readonly HospitalDbContext _context;

        public ConsiliumRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Consilium> GetAll()
        {
            UpdateFinishedConsiliums();
            return _context.Consiliums.ToList();
        }

        public Consilium GetById(int id)
        {
            return _context.Consiliums.Find(id);
        }

        public void Create(Consilium consilium)
        {
            _context.Consiliums.Add(consilium);
            _context.SaveChanges();
        }

        public void Update(Consilium consilium)
        {
            _context.Entry(consilium).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Consilium consilium)
        {
            _context.Consiliums.Remove(consilium);
            _context.SaveChanges();
        }

        private void UpdateFinishedConsiliums()
        {
            List<Consilium> consiliums = (List<Consilium>) GetAll();

            DateTime currentTime = DateTime.Now;

            foreach (Consilium consilium in consiliums)
            {
                if (currentTime > consilium.FromTo.End)
                {
                    consilium.Finished = true;
                    Update(consilium);
                }
            }
        }
    }
}
