using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Advertisements
{
    public interface IAdvertisementService
    {
        public IEnumerable<string> GetAll();
        public string ConversionOfImg(string imgPath);
    }
}
