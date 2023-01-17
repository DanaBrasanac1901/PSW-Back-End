using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalLibrary.Core.Feedback
{
    public class Feedback
    {
        private int id;
        private string patientName;
        private string patientSurname;
        private int patientId;
        private string text;
        private bool visibleToPublic;
        private bool approved;
        private DateTime date;
        
        private bool anonymous;
        public Feedback()
        {

        }
        public class FeedbackBuilder
            {
            internal string patientName;
            internal string patientSurname;
            internal int patientId;
            internal string text;
            internal bool visibleToPublic;
            internal bool approved;
            internal DateTime date;
            internal int id;
            internal bool anonymous;

            public FeedbackBuilder Anonymous(bool anonymous)
            {
                this.anonymous = anonymous;
                return this;
            }

            public FeedbackBuilder Approved(bool approved)
            {
                this.approved = approved;
                return this;
            }

            public FeedbackBuilder Date(DateTime date)
            {
                this.date = date;
                return this;
            }

            public FeedbackBuilder Id(int id)
            {
                this.id = id;
                return this;
            }

            public FeedbackBuilder PatientName(string patientName)
            {
                this.patientName = patientName;
                return this;
            }

            public FeedbackBuilder PatientSurname(string patientSurname)
            {
                this.patientSurname = patientSurname;
                return this;
            }

            public FeedbackBuilder PatientId(int patientId)
            {
                this.patientId = patientId;
                return this;
            }

            public FeedbackBuilder Text(string text)
            {
                this.text = text;
                return this;
            }

            public FeedbackBuilder VisibleToPublic(bool visibleToPublic)
            {
                this.visibleToPublic = visibleToPublic;
                
                return this;
            }
            public Feedback build()
            {
                return new Feedback(this);
            }
        }
        public Feedback(FeedbackBuilder feedbackBuilder)
        {
            this.patientName = feedbackBuilder.patientName;
            this.patientSurname = feedbackBuilder.patientSurname;
            this.patientId= feedbackBuilder.patientId;
            this.text = feedbackBuilder.text;
            this.VisibleToPublic = feedbackBuilder.visibleToPublic;
            this.approved = feedbackBuilder.approved;
            this.date = feedbackBuilder.date;
            this.Id = feedbackBuilder.id;
        }


        public string PatientName { get => patientName; set => patientName = value; }

        public string PatientSurname { get => patientSurname; set => patientSurname = value; }
        public int PatientId { get => patientId; set => patientId = value; }
        public string Text { get => text; set => text = value; }
        public bool VisibleToPublic { get => visibleToPublic; set => visibleToPublic = value; }
        public bool Approved { get => approved; set => approved = value; }
        public DateTime Date { get => date; set => date = value; }
        
        public int Id { get => id; set => id = value; }
        public bool Anonymous { get => anonymous; set => anonymous = value; }
    }
}
