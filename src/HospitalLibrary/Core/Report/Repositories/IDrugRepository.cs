using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Report.Model;

namespace HospitalLibrary.Core.Report.Repositories
{
    public interface IDrugRepository
    {
        IEnumerable<Drug> GetAll();
      

    }
}
