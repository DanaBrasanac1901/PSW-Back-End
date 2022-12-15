using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class SymptomList
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public SymptomList()
        {

        }

        public SymptomList(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public SymptomList(string name)
        {
            Name = name;
        }
    }
}
