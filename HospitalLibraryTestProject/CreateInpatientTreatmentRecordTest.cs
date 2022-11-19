using HospitalLibrary.Core.Appointment;
using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.InpatientTreatmentRecord;
using HospitalLibrary.Core.Room;
using HospitalLibrary.Core.Vacation;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class CreateInpatientTreatmentRecordTest
    {

        [Fact]
        public void Has_Free_Beds()
        {
            Room room = CreateRoomWithEquipment();
            
            bool hasBed = room.HasAvaliableBed();

            hasBed.ShouldBe(true);
        }

        [Fact]

        private Room CreateRoomWithEquipment()
        {
            List<Equipment> roomEquipments = new List<Equipment>();
            roomEquipments.Add(new Equipment("Equip1",EquipmentType.BED,1,1));
            roomEquipments.Add(new Equipment("Equip2",EquipmentType.BANDAGES,0,1));
            roomEquipments.Add(new Equipment("Equip3",EquipmentType.MEDICINE,1,1));


            Room testRoom = new Room(1,"205A",2,roomEquipments);

            return testRoom;
        }

        private Room CreateRoomWithoutBeds()
        {
            List<Equipment> roomEquipments = new List<Equipment>();
            roomEquipments.Add(new Equipment("Equip1", EquipmentType.BED, 0, 2));
            roomEquipments.Add(new Equipment("Equip2", EquipmentType.BANDAGES, 1, 2));
            roomEquipments.Add(new Equipment("Equip3", EquipmentType.MEDICINE, 1, 2));


            Room testRoom = new Room(2, "206A", 2, roomEquipments);

            return testRoom;
        }
    }
}
