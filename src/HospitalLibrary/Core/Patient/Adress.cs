using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Patient
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; }

        public string StreetNumber { get; }
        public string City { get; }
      

        public Address(string street, string streetNumber, string city)
        {
            Street = street;
            StreetNumber = streetNumber;
            City = city;
            Validate();
           
        }

        private void Validate()
        {
            if(string.IsNullOrWhiteSpace(Street) || string.IsNullOrWhiteSpace(StreetNumber) || string.IsNullOrWhiteSpace(City))
            throw new ArgumentException();
            

            Regex r = new Regex("\\d");
            Match m = r.Match(this.StreetNumber);
            if (!m.Success) throw new ArgumentException();
            Regex r1 = new Regex("^[a-zA-Z]+$");
            Match m1 = r1.Match(this.Street);
            Match m2 = r1.Match(this.City);
            if (!m1.Success || !m2.Success) throw new ArgumentException();
           
        }

        protected override bool EqualsCore(Address other)
        {
            return Street == other.Street
                && City == other.City
                && StreetNumber == other.StreetNumber;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Street.GetHashCode();
                hashCode = (hashCode * 397) ^ City.GetHashCode();
                hashCode = (hashCode * 397) ^ StreetNumber.GetHashCode();
                return hashCode;
            }
        }
    }
}

