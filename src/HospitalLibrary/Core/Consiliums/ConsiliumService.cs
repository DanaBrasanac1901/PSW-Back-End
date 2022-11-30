using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Consiliums
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;

        public ConsiliumService(IConsiliumRepository consiliumRepository)
        {
            _consiliumRepository = consiliumRepository;
        }

        public IEnumerable<Consilium> GetAll()
        {
            
            return _consiliumRepository.GetAll();
        }
        public void Create(Consilium consilium)
        {
            
            _consiliumRepository.Create(consilium);
        }
        public void Update(Consilium consilium)
        {
            _consiliumRepository.Update(consilium);
        }

        
    }
}
