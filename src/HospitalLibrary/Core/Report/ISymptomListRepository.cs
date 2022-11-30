using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    public interface ISymptomListRepository
    {
        IEnumerable<SymptomList> GetAll();
        SymptomList GetById(string id);
        void Create(SymptomList symptomList);
        void Update(SymptomList symptomList);
        void Delete(SymptomList symptomList);
    }
}
