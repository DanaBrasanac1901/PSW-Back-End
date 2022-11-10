using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood.DTOS
{
    public class CreateConsmptionRecordDTO
    {
        private readonly IBloodService _bloodService;

        public CreateConsmptionRecordDTO() {}
        public CreateConsmptionRecordDTO(IBloodService bloodService)
        {
            _bloodService = bloodService;
        }

        public double Amount { get; set; }
        public BloodType Type { get; set; }
        public string Reason { get; set; }
    }
}
