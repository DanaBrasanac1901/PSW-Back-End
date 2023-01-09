using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tender.BloodAmount
{
    internal class BloodAmount
    {
        private double amountOfA;
        private double amountOfB;
        private double amountOfAB;
        private double amountOfO;

        public BloodAmount()
        {
        }
        public BloodAmount(BloodAmount a, BloodAmount b)
        {
            this.amountOfA = a.amountOfA + b.amountOfA;
            this.amountOfB = a.amountOfB + b.amountOfB;
            this.amountOfAB=a.amountOfAB+b.amountOfAB;
            this.amountOfO=a.amountOfO+b.amountOfO;
        }

        public double AmountOfA { get => amountOfA; set => amountOfA = value; }
        public double AmountOfB { get => amountOfB; set => amountOfB = value; }
        public double AmountOfAB { get => amountOfAB; set => amountOfAB = value; }
        public double AmountOfO { get => amountOfO; set => amountOfO = value; }
        public static BloodAmount operator +(BloodAmount a, BloodAmount b)
        =>  new BloodAmount(a,b);

    }
}
