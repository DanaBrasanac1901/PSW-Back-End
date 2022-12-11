using HospitalLibrary.Core.Feedback;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Feedback
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback> GetAll();
        void Create(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);
        Feedback GetById(int id);
        void ChangeApproval(int feedbackId);
        void ChangeVisibility(int feedbackId);
        
    }
}
