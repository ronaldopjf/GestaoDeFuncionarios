using Microsoft.EntityFrameworkCore;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Employee> Get()
        {
            var employees = _dataContext.Employees
                .Include(employee => employee.Department)
                .ToList();

            return employees;
        }
    }
}
