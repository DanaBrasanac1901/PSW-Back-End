using HospitalLibrary.Core.Report.DTO;
using HospitalLibrary.Core.Report.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Repositories
{
    public interface ISymptomListRepository
    {
        public List<SymptomList> GetAllSymptoms();
    }
}
