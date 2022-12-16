using HospitalLibrary.Core.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Services
{
    public interface IDrugListApplicationService
    {
        IEnumerable<DrugList> GetAllDrugList();
    }
}
