using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntitityInheritanceCF
{
    public class EmployeeDbcontext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<Employee>().ToTable("Employees");
      //      modelBuilder.Entity<PermanentEmployee>().ToTable("PermanentEmployees");
         //   modelBuilder.Entity<ContractEmployee>().ToTable("ContractEmployees");
            base.OnModelCreating(modelBuilder);
        }
    }
}