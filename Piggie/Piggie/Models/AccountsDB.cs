using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcDemo.Models
{
    public class AccountsDB
    {
        public int AccountId { get; set; }
        public Guid ExternalId { get; set; }
        public string Login { get; set; }
    }
    public class MovieDBContext : DbContext
    {
        public DbSet<AccountsDB> Accounts { get; set; }
    }
}