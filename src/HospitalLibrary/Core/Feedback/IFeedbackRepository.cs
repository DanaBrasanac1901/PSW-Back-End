using System.Collections.Generic;


namespace HospitalLibrary.Core.Feedback
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        Feedback GetByPatientId(int id);
        void Create(Feedback feedback);
        void Update(Feedback feedback);
        void Delete(Feedback feedback);

        Feedback GetById(int id);
    }
}
