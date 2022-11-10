using HospitalLibrary.Core.Blood;
using HospitalLibrary.Core.Enums;
using Shouldly;
using System;
using Xunit;

namespace HospitalLibraryTestProject
{
    public class BloodConsumptionRecordsTests
    {
        [Fact]
        public void Can_consume_blood()
        {
            BloodSupply supply = new BloodSupply(BloodType.A, 30.5);
            double amount = 3;

            bool consumption_status = supply.ReduceBy(amount);

            consumption_status.ShouldBe(true);
        }

        [Fact]
        public void Cannot_consume_blood()
        {
            BloodSupply supply = new BloodSupply(BloodType.A, 2);
            double amount = 5;

            bool consumption_status = supply.ReduceBy(amount);

            consumption_status.ShouldBe(false);
        }
    }
}
