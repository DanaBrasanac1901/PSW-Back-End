using System.Collections.Generic;

namespace HospitalLibrary.Core.Manager
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> GetAll();
        Manager GetById(int id);
        void Create(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}
