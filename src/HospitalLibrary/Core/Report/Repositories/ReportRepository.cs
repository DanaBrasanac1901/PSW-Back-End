using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public class ReportRepository : IReportRepository
    {
        private readonly HospitalDbContext _context;

        public ReportRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public Report GetById(string id)
        {
            return _context.Reports.Find(id);
        }
        
        public void Create(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }

        public void Update(Report report)
        {
            _context.Entry(report).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Report report)
        {
            _context.Reports.Remove(report);
            _context.SaveChanges();
        }
    }
}

