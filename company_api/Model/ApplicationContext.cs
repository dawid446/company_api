using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace company_api.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        { }

        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
