using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.Model
{
    public class DrugList
    {
       public string Id { get; set; }

       public string Name { get; set; }

        public string CompanyName { get; set; }
        public DrugList(string id, string name, string companyName)
      {
            Id = id;
            Name = name;
            CompanyName = companyName;
      }


    }
}
