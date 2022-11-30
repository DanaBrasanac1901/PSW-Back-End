using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report
{
    [Keyless]
    public class Drug : ValueObject
    {
        public string Name { get; }
        public string CompanyName { get; }

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
