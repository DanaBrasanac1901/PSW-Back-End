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
        IEnumerable<Report.Model.Report> GetAll();
        Report.Model.Report GetById(string id);
        void Create(ReportToCreateDTO report);
        void Update(Report.Model.Report report);
        void Delete(Report.Model.Report report);

    }
}
