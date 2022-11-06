using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Core.Feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HospitalDbContext _context;

        public FeedbackRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }

        private int getIdOfLast()
        {
            List<Feedback> feedbacks = (List<Feedback>)GetAll() ;
            return ++feedbacks.Last().ID;

        }

        public Feedback GetByPatientId(int id)
        {
            return _context.Feedbacks.Find(id);
        }

        public void Create(Feedback feedback)
        {
            feedback.Date = System.DateTime.Today;
            feedback.Approved = false;

            //change when login gets implemented
            feedback.PatientId = 0;

            
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public void Update(Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
            _context.SaveChanges();
        }

        public Feedback GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

