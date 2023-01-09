using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public IEnumerable<string> GetAll()
        {
            List<Advertisement> advertisements = (List<Advertisement>)_advertisementRepository.GetAll();
            List<string> base64Strings = new List<string>();
            foreach (Advertisement ad in advertisements)
            {
                base64Strings.Add(ConversionOfImg(ad.Ad));
            }
            return base64Strings;
        }

        public string ConversionOfImg(string imgPath)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(imgPath);
            string converted = Convert.ToBase64String(imageArray);
            return converted;
        }
    }
}
