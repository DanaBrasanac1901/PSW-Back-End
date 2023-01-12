using HospitalLibrary.Core.Infrastructure;
using HospitalLibrary.Core.Report.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class Report : EventSourcedAggregate
    {
        public string PatientId { get; set; }  
        public string DoctorId { get; set; }
        public string AppointmentId { get; set; }
        public string ReportDescription { get; set; }
        public ICollection<Symptom> Symptoms { get; set; }
        public DateTime DayAndTimeOfMaking { get; set; }
        public ICollection<Drug> Drugs { get; set; }
        public int InitialVersion { get; private set; }
        public int CurrentStep { get; private set; }

        public Report(string id){
            Id = id;
            DayAndTimeOfMaking = DateTime.Now;
        }

        public Report(ReportSnapshot snapshot)
        {
            Version = snapshot.Version;
            InitialVersion = snapshot.Version; 
        }

        public Report(string id, string patientId, string doctorId, string reportDescription, ICollection<Symptom> symptoms, DateTime dayAndTimeOfMaking, ICollection<Drug> drugs)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            ReportDescription = reportDescription;
            Symptoms = symptoms;
            DayAndTimeOfMaking = dayAndTimeOfMaking;
            Drugs = drugs;
        }

        private DomainEvent Causes(DomainEvent @event)
        {
            //Changes.Add(@event);
            Apply(@event);

            return @event;
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version++;
        }

        public DomainEvent ReportCreated()
        {
            return Causes(new ReportCreated(Id));
        }

        public DomainEvent ClickedOnNextButton()
        {
            if (CurrentStep < 4)
                return Causes(new NextButtonClicked(Id, CurrentStep));
            return null;
        }

        public DomainEvent ClickedOnBackButton()
        {
            if (CurrentStep > 0)
                return Causes(new BackButtonClicked(Id, CurrentStep));
            return null;
        }

        public DomainEvent FinishedCreating()
        {
            return Causes(new ReportFinished(Id));
        }


        public void When(NextButtonClicked nextClicked)
        {
            CurrentStep += 1;
        }

        public void When(BackButtonClicked backClicked)
        {
            CurrentStep -= 1;
        }

        public void When(ReportCreated reportCreated)
        {
            CurrentStep = 0;
        }

        public void When(ReportFinished reportFinished)
        {
            
        }
    }
}