using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Advertisements
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public IEnumerable<Advertisement> GetAll()
        {
            return _advertisementRepository.GetAll();
        }
    }
}
