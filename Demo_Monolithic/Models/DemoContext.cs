using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Demo.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
    }

    public class Account
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}