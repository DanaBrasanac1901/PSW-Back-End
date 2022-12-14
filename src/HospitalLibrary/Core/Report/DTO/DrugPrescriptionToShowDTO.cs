using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Report.DTO
{
    public class DrugPrescriptionToShowDTO
    {
        public string reportId { get; set; }
        public List<DrugDTO> drugs { get; set; }

        public DrugPrescriptionToShowDTO()
        {

        }
    }
}
