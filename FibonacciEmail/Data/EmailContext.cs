using FibonacciEmail.Model;
using Microsoft.EntityFrameworkCore;

namespace FibonacciEmail.Data
{
 
        public class EmailContext : DbContext
        {
            public EmailContext(DbContextOptions options) : base(options) { }
            public DbSet<EmailModel> emailmodels { get; set; }

        }
    
}
