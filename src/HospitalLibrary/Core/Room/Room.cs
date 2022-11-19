using HospitalLibrary.Core.InpatientTreatmentRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Room
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Number { get; set; }
        [Range(1, 10)]
        public int Floor { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }


        public Room() { }

        public Room(int id, string number, int floor, ICollection<Equipment> equipment)
        {
            Id = id;
            Number = number;
            Floor = floor;
            Equipment = equipment;
        }

        public bool HasAvaliableBed()
        {
            foreach(Equipment e in Equipment)
            {
                if(e.Type != Enums.EquipmentType.BED && e.Quantity != 1)
                    return false;
            }
            return true;
        }
    }
}
