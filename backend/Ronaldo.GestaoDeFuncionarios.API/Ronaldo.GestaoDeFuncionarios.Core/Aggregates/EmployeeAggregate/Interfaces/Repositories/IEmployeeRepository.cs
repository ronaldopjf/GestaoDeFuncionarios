using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Interfaces.Repositories;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
