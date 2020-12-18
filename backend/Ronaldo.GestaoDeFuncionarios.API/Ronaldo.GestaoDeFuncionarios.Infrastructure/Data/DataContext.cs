using Microsoft.EntityFrameworkCore;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.Mappings;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
        }
    }
}
