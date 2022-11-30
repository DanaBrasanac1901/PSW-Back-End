using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Tender
{

    public class Tender
    {
        public Tender() {}

        public Tender(double amountOfA, double amountOfB, double amountOfAB, double amountOfO, string hospitalName, DateTime expiration, int id)
        {
            this.AmountOfA = amountOfA;
            this.AmountOfB = amountOfB;
            this.AmountOfAB = amountOfAB;
            this.AmountOfO = amountOfO;
            this.HospitalName = hospitalName;
            this.Expiration = expiration;
            this.Id = id;
        }

        private double amountOfA;
        private double amountOfB;
        private double amountOfAB;
        private double amountOfO;
        private string hospitalName;
        private DateTime expiration;
        private int id;

        public double AmountOfA { get => amountOfA; private set => amountOfA = value; }
        public double AmountOfB { get => amountOfB; private set => amountOfB = value; }
        public double AmountOfAB { get => amountOfAB; private set => amountOfAB = value; }
        public double AmountOfO { get => amountOfO; private set => amountOfO = value; }
        public string HospitalName { get => hospitalName; private set => hospitalName = value; }
        public DateTime Expiration { get => expiration; private set => expiration = value; }
        public int Id { get => id; private set => id = value; }
    }
}
