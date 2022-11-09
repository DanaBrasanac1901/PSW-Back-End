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
        private int patientId;
        private String text;
        private Boolean visibleToPublic;
        private Boolean approved;
        private DateTime date;
        private int id;
        private Boolean anonymous;
        public Feedback()
        {

        }
        public class FeedbackBuilder
            {
            internal int patientId;
            internal String text;
            internal Boolean visibleToPublic;
            internal Boolean approved;
            internal DateTime date;
            internal int id;
            internal Boolean anonymous;

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

            public FeedbackBuilder ID(int id)
            {
                this.id = id;
                return this;
            }

            public FeedbackBuilder PatientID(int patientId)
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
        public Feedback(int patientId, string text, bool visibility, bool approved, DateTime date, int iD)
        {
            this.patientId = patientId;
            this.text = text;
            this.VisibleToPublic = visibility;
            this.approved = approved;
            this.date = date;
            this.ID = iD;
        }
        public Feedback(FeedbackBuilder feedbackBuilder)
        {
            this.patientId = feedbackBuilder.patientId;
            this.text = feedbackBuilder.text;
            this.VisibleToPublic = feedbackBuilder.visibleToPublic;
            this.approved = feedbackBuilder.approved;
            this.date = feedbackBuilder.date;
            this.ID = feedbackBuilder.id;
        }

        public Feedback(int patientId, string text, bool visibleToPublic, bool approved, DateTime date, int id, bool anonymous)
        {
            this.patientId = patientId;
            this.text = text;
            this.visibleToPublic = visibleToPublic;
            this.approved = approved;
            this.date = date;
            this.id = id;
            this.anonymous = anonymous;
        }

        public int PatientId { get => patientId; set => patientId = value; }
        public string Text { get => text; set => text = value; }
        public bool VisibleToPublic { get => visibleToPublic; set => visibleToPublic = value; }
        public bool Approved { get => approved; set => approved = value; }
        public DateTime Date { get => date; set => date = value; }
        
        public int ID { get => id; set => id = value; }
        public bool Anonymous { get => anonymous; set => anonymous = value; }
    }
}
