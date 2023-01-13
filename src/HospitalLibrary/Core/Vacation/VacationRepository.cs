using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Vacation
{
    public class VacationRepository : IVacationRepository
    {
        private readonly HospitalDbContext _context;

        public VacationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VacationRequest> GetAll()
        {
            return _context.VacationRequests.ToList();
        }

        public VacationRequest GetById(int id)
        {
            return _context.VacationRequests.Find(id);
        }

        public void Create(VacationRequest vacationRequest)
        {
            _context.VacationRequests.Add(vacationRequest);
            _context.SaveChanges();
        }

        public void Update(VacationRequest vacationRequest)
        {
            _context.Entry(vacationRequest).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(VacationRequest vacationRequest)
        {
            _context.VacationRequests.Remove(vacationRequest);
            _context.SaveChanges();
        }

        public IEnumerable<VacationRequest> GetAllByDoctor(int id)
        {
            List<VacationRequest> requests = _context.VacationRequests.Where(request => request.DoctorId.Equals(id)).ToList();
            return requests;
        }
    }
}
