using Microsoft.EntityFrameworkCore;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Persistence.Data
{
    public class PayrollDBContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    DepartmentId = 1,
                    DepartmentName = "HR",
                    IsActive = true
                },
                new Department()
                {
                    DepartmentId = 2,
                    DepartmentName = "Accounts",
                    IsActive = true
                });
            modelBuilder.Entity<Designation>().HasData(
                new Designation()
                {
                    DesignationId = 1,
                    DesignationName = "Manager",
                    IsActive = true
                },
                new Designation()
                {
                    DesignationId= 2,
                    DesignationName = "Assistnat Manager",
                    IsActive = true
                }
                );
            modelBuilder.Entity<Grade>().HasData(
                new Grade
                {
                    GradeId = 1,
                    GradeName = "01",
                    Active = true
                },
                new Grade
                {
                    GradeId= 2,
                    GradeName = "02",
                    Active = true
                }
                );
        }
    }
}
