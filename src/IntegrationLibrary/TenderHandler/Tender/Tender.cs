using HospitalLibrary.Core.Enums;
using IntegrationLibrary.Tender.BloodAmount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Tender
{

    public class Tender
    {

        public Tender(double amountOfA, double amountOfB, double amountOfAB, double amountOfO, string hospitalName, DateTime expiration, int id)
        {
            bloodAmount = new BloodAmount();
            this.bloodAmount.AmountOfA = amountOfA;
            this.bloodAmount.AmountOfB = amountOfB;
            this.bloodAmount.AmountOfAB = amountOfAB;
            this.bloodAmount.AmountOfO = amountOfO;
            this.HospitalName = hospitalName;
            this.Expiration = expiration;
            this.Id = id;
        }

        private BloodAmount bloodAmount;
        private string hospitalName;
        private DateTime expiration;
        private int id;

        public double AmountOfA { get => bloodAmount.AmountOfA; private set => bloodAmount.AmountOfA = value; }
        public double AmountOfB { get => bloodAmount.AmountOfB; private set => bloodAmount.AmountOfB = value; }
        public double AmountOfAB { get => bloodAmount.AmountOfAB; private set => bloodAmount.AmountOfAB = value; }
        public double AmountOfO { get => bloodAmount.AmountOfO; private set => bloodAmount.AmountOfO = value; }
        public string HospitalName { get => hospitalName; private set => hospitalName = value; }
        public DateTime Expiration { get => expiration; private set => expiration = value; }
        public int Id { get => id; private set => id = value; }

        internal BloodAmount BloodAmount
        {
            get => default;
            set
            {
            }
        }
    }
}
