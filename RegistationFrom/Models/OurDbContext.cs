using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegistationFrom.Models
{
    public class OurDbContext:DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}