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
        }
    }
}