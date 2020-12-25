using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Interfaces.Repositories;
using System.Collections.Generic;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        int CountAccess();
        Employee Get(string login);
        void Delete(IEnumerable<Employee> employees);
    }
}
