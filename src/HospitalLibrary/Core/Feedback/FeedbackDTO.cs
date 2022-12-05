using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Feedback
{
    public class FeedbackDTO
    {
        private int Id { get; set; }
        private string PatientFullName { get; set; }
        private string Text { get; set; }
        private Boolean VisibleToPublic { get; set; }
        private Boolean Approved { get; set; }
        private string DateAndTime { get; set; }
        private Boolean Anonymous { get; set; }


        public FeedbackDTO() { }


        public FeedbackDTO(Feedback feedback)
        {

            Id = feedback.ID;
            PatientFullName = feedback.PatientName + ' ' + feedback.PatientSurname;
            Text = feedback.Text;
            VisibleToPublic = feedback.VisibleToPublic;
            Approved = feedback.Approved;
            DateAndTime = feedback.Date.ToString("MM/dd/yyyy HH:mm");
            Anonymous = feedback.Anonymous;


        }


    }
}
