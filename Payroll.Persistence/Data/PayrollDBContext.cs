using Microsoft.EntityFrameworkCore;
using Payroll.Domain.Entities.Payroll;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Persistence.Data
{
    public class PayrollDBContext : DbContext
    {
        public PayrollDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmployeePersonal> EmployeePersonals { get; set; }
        public DbSet<EmployeeOfficial> EmployeeOfficials { get; set; }
        public DbSet<User>  Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // PayrollDBContextSeed.Seed(modelBuilder);
        }
    }
}
