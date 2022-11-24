using HospitalLibrary.Core.Enums;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly HospitalDbContext _context;

        public EquipmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void Create(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
        }

        public void Delete(Equipment equipment)
        {
            _context.Equipment.Remove(equipment);
            _context.SaveChanges();
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipment.ToList();
        }

        public Equipment GetById(string id)
        {
            return _context.Equipment.Find(id);
        }

        public void Update(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Equipment GetByType (EquipmentType type)
        {
            Equipment equipment = _context.Equipment.FirstOrDefault(e => e.Type == type);

            return equipment;
        }

        public IEnumerable<string> GetRoomFreeBeds(int id)
        {
            IEnumerable<string> bedIds = _context.Equipment.Where(e => e.RoomId == id && e.Quantity==1).Select(e => e.Id).ToList();

            return bedIds;
        }
    }
}
