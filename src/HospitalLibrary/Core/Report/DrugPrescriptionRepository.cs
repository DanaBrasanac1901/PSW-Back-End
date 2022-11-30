using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class DrugPrescriptionRepository
    {

        private readonly HospitalDbContext _context;

        public DrugPrescriptionRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DrugPrescription> GetAll()
        {
            return _context.DrugPrescriptions.ToList();
        }

        public DrugPrescription GetById(string id)
        {
            return _context.DrugPrescriptions.Find(id);
        }

        public void Create(DrugPrescription drugPrescription)
        {
            _context.DrugPrescriptions.Add(drugPrescription);
            _context.SaveChanges();
        }

        public void Update(DrugPrescription drugPrescription)
        {
            _context.Entry(drugPrescription).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(DrugPrescription drugPrescription)
        {
            _context.DrugPrescriptions.Remove(drugPrescription);
            _context.SaveChanges();
        }
    }
}

