using HospitalLibrary.Core.Blood.DTOS;
using HospitalLibrary.Core.Doctor.DTOS;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public class EquipmentService : IEquipmentService

    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Equipment ChangeBedStatus(string id, int status)
        {
            Equipment bed = _equipmentRepository.GetById(id);

            bed.Quantity = status;
            _equipmentRepository.Update(bed);

            return bed;
        }

        public IEnumerable<string> GetAvailableRoomBeds(int id)
        {
            return _equipmentRepository.GetRoomFreeBeds(id);
        }
    }
}
