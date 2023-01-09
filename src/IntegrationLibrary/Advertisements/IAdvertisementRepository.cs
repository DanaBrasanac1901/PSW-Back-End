using HospitalLibrary.Core.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Advertisements
{
    public interface IAdvertisementRepository
    {
        IEnumerable<Advertisement> GetAll();
       
    }
}
