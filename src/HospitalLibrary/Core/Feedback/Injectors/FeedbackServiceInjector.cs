
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Feedback.Injectors
{
    public class FeedbackServiceInjector
    {
            public IFeedbackService Inject(HospitalDbContext hospitalDb)
            {
                IFeedbackService service = new FeedbackService(hospitalDb);
                return service;
            }
    }
}

