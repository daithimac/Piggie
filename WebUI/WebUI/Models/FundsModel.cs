using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class SummaryModel
    {
        public Decimal Amount { get; set; }
    }

    public class CreateModel
    {
        public String Name { get; set; }
        public String frequency { get; set; }
        public Decimal PayAmount { get; set; }
        public Decimal Goal { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}