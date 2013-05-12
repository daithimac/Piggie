using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;

namespace WebUI.Services.Payments.Data.Mocks
{
    public static class PaymentsEntitiesMock
    {
        public static List<Fund> Funds { get; set; }
        public static List<PaymentCard> PaymentCards { get; set; }

        static PaymentsEntitiesMock()
        {
            PaymentCards = new List<PaymentCard>();

            Funds = new List<Fund>();
            Funds.Add(new Fund
            { 
                AccountGuid = Guid.NewGuid(), 
                Amount = 200, 
                Balance = 100,
                Frequency = 1,
                CreatedOn = DateTime.Now, 
                FundGuid = Guid.NewGuid(),
                FundId = 0, GoalAmount = 1000,
                Name = "Electric Picnic Ticket", 
                ReleaseOn = DateTime.Now
            });

            Funds.Add(new Fund
            {
                AccountGuid = Guid.NewGuid(),
                Balance = 800,
                Frequency = 0,
                Amount = 6000,
                CreatedOn = DateTime.Now,
                FundGuid = Guid.NewGuid(),
                FundId = 0,
                GoalAmount = 1000,
                Name = "Engagement Ring",
                ReleaseOn = DateTime.Now
            });
        }
    }
}