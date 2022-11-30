using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public interface IConsiliumService
    {   
        IEnumerable<Consilium> GetAll();
        void Create(Consilium consilium);
        void Update(Consilium consilium);
    }
}
