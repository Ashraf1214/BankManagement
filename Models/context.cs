using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalCaseStudy13.Models
{
    public class context : DbContext
    {
        public context(DbContextOptions<context> options) : base(options)
        {
        }
        public DbSet<Customer> Customer {get; set;}
        public DbSet<Account> Account { get; set;}
        public DbSet<Transaction> Transactions { get; set; }
    }
}
