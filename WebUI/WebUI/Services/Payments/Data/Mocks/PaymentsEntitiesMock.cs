using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;

namespace WebUI.Services.Payments.Data.Mocks
{
    public static class PaymentsEntitiesMock
    {
        public static List<Fund> Funds { get; set; }

        static PaymentsEntitiesMock()
        {
            Funds = new List<Fund>();
            Funds.Add(new Fund
            { 
                AccountGuid = Guid.NewGuid(), 
                Amount = 100, 
                Balance = 100,
                Frequency = "Monthly",
                CreatedOn = DateTime.Now, 
                FundGuid = Guid.NewGuid(),
                FundId = 0, GoalAmount = 1000,
                Name = "MyFund1", 
                ReleaseOn = DateTime.Now
            });

            Funds.Add(new Fund
            {
                AccountGuid = Guid.NewGuid(),
                Balance = 25,
                Frequency = "bi-enniannly",
                Amount = 100,
                CreatedOn = DateTime.Now,
                FundGuid = Guid.NewGuid(),
                FundId = 0,
                GoalAmount = 1000,
                Name = "MyFund2",
                ReleaseOn = DateTime.Now
            });
        }
    }
}