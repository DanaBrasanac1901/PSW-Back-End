using HospitalLibrary.Core.Service;
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
            public IFeedbackService Inject()
            {
                IFeedbackService service = new FeedbackService();
                return service;
            }
    }
}

