using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.AppointmentCancelation
{
    public class AppointmentCancelationRepository : IAppointmentCancelationRepository
    {
        private readonly HospitalDbContext _context;
        public AppointmentCancelationRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public IEnumerable<AppointmentCancelation> GetAll()
        {
            return _context.AppointmentCancelations.ToList();
        }
        public AppointmentCancelation GetById(int id)
        {
            return _context.AppointmentCancelations.Find(id);
        }
        public void Create(AppointmentCancelation appointment)
        {
            _context.AppointmentCancelations.Add(appointment);
            _context.SaveChanges();
        }
    }
}
