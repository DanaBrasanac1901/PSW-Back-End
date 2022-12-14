using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    [Owned]
    public class Drug : ValueObject
    {
        public string Name { get; private set; }
        public string CompanyName { get; private set; }

        public Drug()
        {
        }

        public Drug(string name, string companyName)
        {
            Name = name;
            CompanyName = companyName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return CompanyName;
        }
    }
}
