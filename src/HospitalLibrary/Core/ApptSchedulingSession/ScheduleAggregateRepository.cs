using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.ApptSchedulingSession
{
    internal class ScheduleAggregateRepository
    {
        private readonly HospitalDbContext _context;

        public ScheduleAggregateRepository(HospitalDbContext context)
        {
            _context = context;
        }
/*
        public IEnumerable<ScheduleAggregate> GetAll()
        {
        }

        public ScheduleAggregate GetById(int id)
        {
            
        }

        public void Create(ScheduleAggregate scheduleAggregate)
        {
           // _context.Patients.Add(patient);
            _context.SaveChanges();
        }*/
    }
}
