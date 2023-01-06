using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.ApptSchedulingSession.AbstractClasses;

namespace HospitalLibrary.Core.ApptSchedulingSession
{
    public class ScheduleAggregate : EventSourcedAggregate
    {
        private DateTime _begin;
        private DateTime _end;

        private bool _isFinished;

        public DateTime Begin { get { return _begin; } }
        public DateTime End { get { return _end; } }
        public bool IsFinished { get { return _isFinished; } }

        public ScheduleAggregate() { }

        public ScheduleAggregate(Guid id, DateTime begin)
        {
            Causes(new SchedulingStarted(id, begin));
        }

        public ScheduleAggregate(SchedulingSnapshot snapShot)
        { 
            Version = snapShot.Version;
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        public SchedulingSnapshot GetSchedulingSnapShot()
        {
            var snapshot = new SchedulingSnapshot();

            snapshot.Version = Version;

            return snapshot;
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
            Id = schedulingStarted.Id;
            _begin = schedulingStarted.TimeStamp;
            _isFinished = false;
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
            _end = scheduleButtonPressed.TimeStamp;
            _isFinished = true;
        }

       


    }
}
