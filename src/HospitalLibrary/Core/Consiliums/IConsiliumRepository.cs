using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public interface IConsiliumRepository
    {
        IEnumerable<Consilium> GetAll();
        Consilium GetById(int id);
        void Create(Consilium consilium);
        void Update(Consilium consilium);
        void Delete(Consilium consilium);

    }
}
