using HospitalLibrary.Core.Doctor;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Patient;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class ChosenDoctorTests
    {
        private Mock<IDoctorRepository> doctorRepo;
        private Mock<IPatientRepository> patientRepo;
        private PatientService patientService;

        private void Setting_doctor_repository()
        {
            var doctors = new List<Doctor>();
            doctorRepo = new Mock<IDoctorRepository>();
           
            doctors.Add(new Doctor { Id = "1", Name = "Ivan", Surname = "Nikolic", Email = "inik@gmail.com", RoomId = 1, StartWorkTime = 8, EndWorkTime = 13 });
            doctors.Add(new Doctor { Id = "2", Name = "Milica", Surname = "Todorovic", Email = "mtodorovic@hotmail.com", RoomId = 2, StartWorkTime = 8, EndWorkTime = 13 });
            doctors.Add(new Doctor { Id = "3", Name = "Darko", Surname = "Mitic", Email = "darkomitic@live.com", RoomId = 3, StartWorkTime = 13, EndWorkTime = 20 });
            doctors.Add(new Doctor { Id = "4", Name = "Selena", Surname = "Mirkovic", Email = "selmirkovic@gmail.com", RoomId = 4, StartWorkTime = 13, EndWorkTime = 20 });

            this.doctorRepo.Setup(m => m.GetAll()).Returns(doctors);

        }
        
        private void Setting_patient_repository()
        {/*
            var patients = new List<Patient>();
            patientRepo = new Mock<IPatientRepository>();

            patients.Add(new Patient { Id = 1, PatientName = "Janko Jankovic", Email = "janki@gmail.com", Password = "nekibzvzpas", BloodType = BloodType.A, Allergies = "", DoctorID = "1", Active = true });
            patients.Add(new Patient { Id = 2, PatientName = "Milan Simic", Email = "mmilaaan@hotmail.com", Password = "nekibzvzpas123", BloodType = BloodType.O, Allergies = "", DoctorID = "1", Active = true });
            patients.Add(new Patient { Id = 3, PatientName = "Nikola Nikolic", Email = "niknik@live.com", Password = "nekibzvzpas5454", BloodType = BloodType.AB, Allergies = "", DoctorID = "2", Active = true });
            patients.Add(new Patient { Id = 4, PatientName = "Sanja Medic", Email = "medics@gmail.com", Password = "321sanjinpass", BloodType = BloodType.A, Allergies = "", DoctorID = "3", Active = true });
            patients.Add(new Patient { Id = 5, PatientName = "Mirko Kis", Email = "mkis@gmail.com", Password = "nekimirkovpass", BloodType = BloodType.B, Allergies = "", DoctorID = "1", Active = true });

            this.patientRepo.Setup(m => m.GetAll()).Returns(patients);*/
        }

        private void Setting_patient_service()
        {
            Setting_doctor_repository();
            Setting_patient_repository();
            patientService = new PatientService(patientRepo.Object, doctorRepo.Object);
        }

        [Fact]
        public void Finds_minimal_number_of_patients()
        {
            Setting_patient_service();

            var minimalNumber = patientService.GetMinNumOfPatients(3);

            Assert.StrictEqual(0, minimalNumber);
        }

        [Fact]
        public void Finds_doctors_with_smallest_patient_count()
        {
            Setting_patient_service();

            var doctorIdList = patientService.DoctorsWithSimiliarNumOfPatients(0, 1);

            Assert.Equal(new List<string>() { "2", "3", "4" }, doctorIdList);


        }

        [Fact]
        public void Finds_maximum_number_of_patients()
        {
            Setting_patient_service();

            var numberOfPatients = patientService.GetMaxNumOfPatients();

            Assert.StrictEqual(3, numberOfPatients);
        }

        [Fact]  
        public void Finds_number_of_patients_for_doctor()
        {
            Setting_patient_service();

            var numberOfPatients = patientService.NumberOfPatientsByDoctor("2");

            Assert.StrictEqual(1, numberOfPatients);
        }


    }
}
