using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Enums;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
/*
namespace HospitalLibraryTestProject
{
    public class BloodConsumptionRecordsTests
    {
        [Fact]
        public void Can_consume_blood()
        {
            BloodService bloodService = new BloodService(CreateBloodSuppliesRepo(), CreateBloodConsumptionRepo(), CreateBloodRequestRepo());
            
            BloodConsumptionRecord record = new BloodConsumptionRecord(1, 15, BloodType.A, "need for surgery", System.DateTime.Now, "DOC1", new System.Guid("00000000-0000-0000-0000-000000000000"));

            var bankId = bloodService.CreateBloodConsumptionRecord(record);

            bankId.Equals("55510651-D36E-444D-95FB-871E0902CD7E");
        }

        [Fact]
        public void Cannot_consume_blood()
        {
            BloodService bloodService = new BloodService(CreateBloodSuppliesRepo(), CreateBloodConsumptionRepo(), CreateBloodRequestRepo());

            BloodConsumptionRecord record = new BloodConsumptionRecord(1, 30, BloodType.A, "need for surgery", System.DateTime.Now, "DOC1", new System.Guid("00000000-0000-0000-0000-000000000000"));

            var bankId = bloodService.CreateBloodConsumptionRecord(record);

            bankId.Equals("-");
        }


        private IBloodConsuptionRepository  CreateBloodSuppliesRepo()
        {
            var stubRepo = new Mock<IBloodConsuptionRepository>();
            var supplies = new List<BloodSupply>();

            BloodSupply supplyABank1 = new BloodSupply(1, BloodType.A, 10, new Guid("2D4894B6-02E4-4288-A3D3-089489563190"));
            BloodSupply supplyABank2 = new BloodSupply(5, BloodType.A, 23, new Guid("55510651-D36E-444D-95FB-871E0902CD7E"));
            BloodSupply supplyABank3 = new BloodSupply(7, BloodType.A, 24, new Guid("A60460FE-0D33-478D-93B3-45D424079E66"));

            supplies.Add(supplyABank1);
            supplies.Add(supplyABank2);
            supplies.Add(supplyABank3);

            
            stubRepo.Setup(m => m.GetByGroup(BloodType.A)).Returns(supplies);

            return stubRepo.Object;
        }


        private IBloodConsuptionRecordRepository CreateBloodConsumptionRepo()
        {
            var stubRepo = new Mock<IBloodConsuptionRecordRepository>();

            return stubRepo.Object;
        }

        private IBloodRequestRepository CreateBloodRequestRepo()
        {
            var stubRepo = new Mock<IBloodRequestRepository>();

            return stubRepo.Object;
        }

        [Fact]
        public void Can_reduce()
        {
            Blood supply = new Blood(BloodType.A, 10);

            Blood reduced = supply.ReduceBy(new Blood(BloodType.A, 5));

            Assert.True(reduced.Amount == 5);
        }

        [Fact]
        public void Cannot_reduce()
        {
            Blood supply = new Blood(BloodType.A, 10);

            Blood reduced = supply.ReduceBy(new Blood(BloodType.A, 15));

            Assert.Null(reduced);
        }
    }
}*/
