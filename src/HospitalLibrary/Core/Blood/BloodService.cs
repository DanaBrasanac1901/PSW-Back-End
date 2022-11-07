using HospitalLibrary.Core.Blood.DTOS;
using HospitalLibrary.Core.Doctor.DTOS;
using HospitalLibrary.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Blood
{
    public class BloodService : IBloodService

    {
        private readonly IBloodSupplyRepository _bloodSupplyRepository;
        private readonly IBloodConsuptionRecordRepository _bloodConsumptionRecordRepository;
        private readonly IBloodRequestRepository _bloodRequestRepository;

        public BloodService(IBloodSupplyRepository bloodSupplyRepository, IBloodConsuptionRecordRepository bloodConsumptionRecordRepository, IBloodRequestRepository bloodRequestRepository)
        {
            _bloodSupplyRepository = bloodSupplyRepository;
            _bloodConsumptionRecordRepository = bloodConsumptionRecordRepository;
            _bloodRequestRepository = bloodRequestRepository;
        }

        public void CreateBloodConsumptionRecord(CreateConsmptionRecordDTO record)
        {
            BloodConsumptionRecord newRecord = BloodDTOAdapter.CreateConsmptionRecordDTOToObject(record);

            newRecord.Id = GenerateId(0);

            ReduceBloodAmountAfterConsumption(newRecord.Amount, newRecord.Type);
            _bloodConsumptionRecordRepository.Create(newRecord);
        }

        public void CreateBloodRequest(BloodRequest bloodRequest)
        {
            //change parameter to DTO received from the front end
            _bloodRequestRepository.Create(bloodRequest);
        }

        public void ReduceBloodAmountAfterConsumption(double amount, BloodType type)
        {
            
        }


        private int GenerateId(int type)
        {
            List<int> ids = new List<int>();

            if (type == 0)
            {
                IEnumerable<BloodConsumptionRecord> records = _bloodConsumptionRecordRepository.GetAll();
                ids = records.Select(r => r.Id).ToList();
            }
            else if(type == 1)
            {
                IEnumerable<BloodRequest> requests = _bloodRequestRepository.GetAll();
                ids = requests.Select(r => r.Id).ToList();
            }

            if (ids.Count == 0)
                return 0;
            else
                return ids.Max() + 1;
        }
    }
}
