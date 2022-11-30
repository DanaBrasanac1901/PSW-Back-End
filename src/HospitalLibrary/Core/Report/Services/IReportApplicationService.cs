using HospitalLibrary.Core.Report.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public interface IReportApplicationService
    {
        IEnumerable<Report> GetAll();
        Report GetById(string id);
        void Create(ReportToCreateDTO report);
        void Update(Report report);
        void Delete(Report report);

    }
}
