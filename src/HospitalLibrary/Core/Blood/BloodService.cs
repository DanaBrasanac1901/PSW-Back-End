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
        private readonly IBloodConsuptionRepository _bloodSupplyRepository;
        private readonly IBloodConsuptionRecordRepository _bloodConsumptionRecordRepository;
        private readonly IBloodRequestRepository _bloodRequestRepository;

        public BloodService(IBloodConsuptionRepository bloodSupplyRepository, IBloodConsuptionRecordRepository bloodConsumptionRecordRepository, IBloodRequestRepository bloodRequestRepository)
        {
            _bloodSupplyRepository = bloodSupplyRepository;
            _bloodConsumptionRecordRepository = bloodConsumptionRecordRepository;
            _bloodRequestRepository = bloodRequestRepository;
        }

        public Guid CreateBloodConsumptionRecord(BloodConsumptionRecord record)
        {
            List<BloodSupply> supplies = _bloodSupplyRepository.GetByGroup(record.Type);

            foreach(BloodSupply supply in supplies)
            {
                if (supply.ReduceBy(record.Amount))
                {
                    _bloodSupplyRepository.Update(supply);

                    record.SourceBank = supply.SourceBank;
                    _bloodConsumptionRecordRepository.Create(record);

                    return record.SourceBank;
                }
            }
            return new System.Guid("00000000-0000-0000-0000-000000000000");
        }

        public void CreateBloodRequest(CreateBloodRequestDTO bloodRequest)
        {
            BloodRequest newBloodRequest = BloodDTOAdapter.CreateBloodRequestDTOToObject(bloodRequest);

            bloodRequest.id = GenerateId(1);

            _bloodRequestRepository.Create(newBloodRequest);
        }


        public int GenerateId(int type)
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

        public BloodConsumptionRecord GetById(int id)
        {
            return _bloodConsumptionRecordRepository.GetById(id);
        }
    }
}
