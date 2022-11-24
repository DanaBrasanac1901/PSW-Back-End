using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Blood
{
    public class BloodSupplyRepository : IBloodConsuptionRepository
    {

        private readonly HospitalDbContext _context;
        public BloodSupplyRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BloodSupply> GetAll()
        {
            return _context.HospitalBlood.ToList();
        }

        public BloodSupply GetById(int id)
        {
            return _context.HospitalBlood.Find(id);
        }

        public void Create(BloodSupply bloodSupply)
        {
            _context.HospitalBlood.Add(bloodSupply);
            _context.SaveChanges();
        }

        public void Update(BloodSupply bloodSupply)
        {
            _context.Entry(bloodSupply).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(BloodSupply bloodSupply)
        {
            _context.HospitalBlood.Remove(bloodSupply);
            _context.SaveChanges();
        }

        public List<BloodSupply> GetByGroup(BloodType type)
        {

            List<BloodSupply> supplies = _context.HospitalBlood.Where(s => s.Type == type).ToList();

            return supplies;
        }
    }
}
