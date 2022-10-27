using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Feedback
{
   public class Feedback
    {
        private int id;
        private int patientId;
        private String text;
        private Boolean visibility;
        private Boolean approved;
        private DateTime date;

        public Feedback()
        {

        }

        public Feedback(int id,int patientId, string text, bool visibility, bool approved, DateTime date)
        {
            Id = id;
            PatientId = patientId;
            Text = text;
            Visibility = visibility;
            Approved = approved;
            Date = date;
           
        }

        public int Id { get { return id; } set { id = value; } }
        public int PatientId { get => patientId; set => patientId = value; }
        public string Text { get => text; set => text = value; }
        public bool Visibility { get => visibility; set => visibility = value; }
        public bool Approved { get => approved; set => approved = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
