using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Feedback.Injectors
{
    internal class FeedbackRepositoryInjector
    {
        HospitalDbContext context;
        public FeedbackRepositoryInjector(HospitalDbContext hospitalDb)
        {
            context = hospitalDb;
        }

        public IFeedbackRepository Inject()
            {

                IFeedbackRepository repository = new FeedbackRepository(context);
                return repository;
            }
    }
}
