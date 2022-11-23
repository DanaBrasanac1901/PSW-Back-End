using HospitalLibrary.Core.Feedback.Injectors;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(HospitalDbContext hospitalDb)
        {
           _feedbackRepository=new FeedbackRepositoryInjector(hospitalDb).Inject();

        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetById(id);
        }

        public Feedback GetByPatientId(int id)
        {
            return _feedbackRepository.GetByPatientId(id);
        }

        public void Create(Feedback feedback)
        {
            feedback.Date = System.DateTime.Today;
            feedback.Approved = false;

            //change when login gets implemented
            //feedback.PatientId = 0;
            _feedbackRepository.Create(feedback);
        }

        public void Update(Feedback feedback)
        {
            _feedbackRepository.Update(feedback);
        }

        public void Delete(Feedback feedback)
        {
            _feedbackRepository.Delete(feedback);
        }
        public void AcceptFeedback(Feedback feedback)
        {
            feedback.Approved = true;
            _feedbackRepository.Update(feedback);
        }
        public void ChangeVisibility(Feedback feedback)
        {
            if(feedback.VisibleToPublic)
                feedback.VisibleToPublic = false;
            else feedback.VisibleToPublic = true;
            _feedbackRepository.Update(feedback);
        }
    }
}

