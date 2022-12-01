using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;

namespace HospitalLibrary.Core.Report.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<Report.Model.Report> GetAll();
        Report.Model.Report GetById(string id);
        void Create(Report.Model.Report report);
        void Update(Report.Model.Report report);
        void Delete(Report.Model.Report report);
    }
}
