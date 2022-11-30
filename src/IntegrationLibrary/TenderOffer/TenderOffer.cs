using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.TenderOffer
{

    public class TenderOffer
    {
        public TenderOffer(int tenderId, double price, Guid bloodBankId)
        {
            this.tenderId = tenderId;
            this.price = price;
            this.bloodBankId = bloodBankId;
        }

        private int tenderId;
        private double price;
        private Guid bloodBankId;

        public int TenderId { get => tenderId; private set => tenderId = value; }
        public double Price { get => price; private set => price = value; }
        public Guid BloodBankId { get => bloodBankId; private set => bloodBankId = value; }
    }
}
