using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class Fund
    {
        public String Name { get; set; }
        public Decimal Amount { get; set; }
        public Decimal GoalAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ReleaseOn { get; set; }
    }

    public class SummaryModel
    {
        public List<Fund> Funds { get; set; }
    }

    public class CreateModel
    {
        public String Name { get; set; }
        public String Frequency { get; set; }
        public Decimal GoalAmount { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}