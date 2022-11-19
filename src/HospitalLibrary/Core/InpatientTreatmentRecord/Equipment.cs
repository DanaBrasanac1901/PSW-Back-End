using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.InpatientTreatmentRecord
{
    public class Equipment
    {
        public string Id { get; set; }
        public EquipmentType Type { get; set; }
        public int Quantity { get; set; } 
        public int RoomId { get; set; }

        public Equipment() { }

        public Equipment (string id, EquipmentType type, int quantity, int roomId)
        {
            Id = id;
            Type = type;
            Quantity = quantity;
            RoomId = roomId;
        }
    }
}
