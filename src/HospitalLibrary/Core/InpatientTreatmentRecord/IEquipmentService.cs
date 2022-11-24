using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public interface IEquipmentService
    {
        IEnumerable<String> GetAvailableRoomBeds(int id);
        Equipment ChangeBedStatus(string id, int status);
    }
}
