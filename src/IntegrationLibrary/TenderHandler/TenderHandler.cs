using HospitalLibrary.Core.TenderOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.TenderHandler
{
    public class TenderHandler
    {
        HospitalLibrary.Core.Tender.Tender tender;
        List<TenderOffer> tenderOffers;

        public TenderHandler(HospitalLibrary.Core.Tender.Tender tender, List<TenderOffer> tenderOffers)
        {
            this.tender = tender;
            this.tenderOffers = tenderOffers;
        }

        public HospitalLibrary.Core.Tender.Tender Tender { get => tender; set => tender = value; }
        public List<TenderOffer> TenderOffers { get => tenderOffers; set => tenderOffers = value; }

        public HospitalLibrary.Core.Tender.Tender Tender1
        {
            get => default;
            set
            {
            }
        }

        public TenderOffer TenderOffer
        {
            get => default;
            set
            {
            }
        }
    }
}
