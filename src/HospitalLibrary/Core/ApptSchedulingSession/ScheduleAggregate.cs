using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses;
using HospitalLibrary.Core.ApptSchedulingSession.Events;

namespace HospitalLibrary.Core.ApptSchedulingSession
{
    public class ScheduleAggregate : EventSourcedAggregate
    {

        public ScheduleAggregate(Guid id) {
        
            Id = id;
        }

        public ScheduleAggregate() { }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        public void Start(Guid id, DateTime timeStamp)
        {
            Causes(new SchedulingStarted(id, timeStamp));
        }

        public void Back(DateTime timeStamp)
        {
            Causes(new BackButtonPressed(this.Id, timeStamp));
        }
        public void Next(DateTime timeStamp)
        {
            Causes(new NextButtonPressed(this.Id, timeStamp));
        }
        public void Schedule(DateTime timeStamp)
        {
            Causes(new ScheduleButtonPressed(this.Id, timeStamp));
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        private void When(SchedulingStarted schedulingStarted)
        {
            //nista?
        }

        private void When(NextButtonPressed nextButtonPressed)
        {
        // mislim da ne mora svaki dogadjaj nesto da uradi
        }

        private void When(BackButtonPressed backButtonPressed)
        {
            // mislim da ne mora svaki dogadjaj nesto da uradi
        }

        private void When(ScheduleButtonPressed scheduleButtonPressed)
        {
           //
        }

       


    }
}
