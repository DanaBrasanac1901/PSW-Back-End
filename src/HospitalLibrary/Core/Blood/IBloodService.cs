﻿using HospitalLibrary.Core.Blood.DTOS;
using HospitalLibrary.Core.Doctor.DTOS;
using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood
{
    public interface IBloodService
    {        
       
        void CreateBloodConsumptionRecord(CreateConsmptionRecordDTO record);
        void CreateBloodRequest(BloodRequest bloodRequest);
        public void ReduceBloodAmountAfterConsumption(double amount, BloodType type);
    }
}