using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalLibrary.Core.Report
{
    public interface IDrugListRepository
    {
        IEnumerable<DrugList> GetAll();
        DrugList GetById(string id);
        void Create(DrugList drugList);
        void Update(DrugList drugList);
        void Delete(DrugList drugList);
    }
}
