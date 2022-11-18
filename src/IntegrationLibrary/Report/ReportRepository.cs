using System;
using System.Collections.Generic;
using System.Linq;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Report
{
    public class ReportRepository : IReportRepository
    {
        private readonly IntegrationDbContext _context;

        public ReportRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public Report GetById(Guid id)
        {
            return _context.Reports.Find(id);
        }

        public void Create(Report report)
        {
            report.ConfigurationDate = DateTime.Today;
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

    }
}