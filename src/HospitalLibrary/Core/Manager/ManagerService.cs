using HospitalLibrary.Core.Appointment;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Manager
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public IEnumerable<Manager> GetAll()
        {
            return _managerRepository.GetAll();
        }

        public Manager GetById(int id)
        {
            return _managerRepository.GetById(id);
        }

        public void Create(Manager manager)
        {
            _managerRepository.Create(manager);
        }

        public void Update(Manager manager)
        {
            _managerRepository.Update(manager);
        }

        public void Delete(Manager manager)
        {
            _managerRepository.Delete(manager);
        }
    }
}
