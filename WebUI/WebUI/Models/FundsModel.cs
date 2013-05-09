using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class SummaryFund
    {
        public String Name { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Balance { get; set; }
        public Decimal GoalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ReleaseOn { get; set; }
        public String Frequency { get; set; }
    }

    public class SummaryModel
    {
        public List<SummaryFund> Funds { get; set; }
    }

    public class CreateModel
    {
        public String Name { get; set; }
        public Decimal GoalAmount { get; set; }
        public DateTime ReleaseOn { get; set; }
        public String Frequency { get; set; }
    }
}