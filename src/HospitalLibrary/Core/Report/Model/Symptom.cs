using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    [Owned]
    public class Symptom : ValueObject
    {
        public string Name { get; private set; }

        public Symptom()
        {
        }
        

        public Symptom(string name)
        {
            Name = name;
        }

        

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

       

    }
}
