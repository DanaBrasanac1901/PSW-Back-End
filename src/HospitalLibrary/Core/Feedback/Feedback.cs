using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Feedback()
        {

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

        public int PatientId { get => patientId; set => patientId = value; }
        public string Text { get => text; set => text = value; }
        public bool VisibleToPublic { get => visibleToPublic; set => visibleToPublic = value; }
        public bool Approved { get => approved; set => approved = value; }
        public DateTime Date { get => date; set => date = value; }
        public int ID { get => id; set => id = value; }
    }
}
