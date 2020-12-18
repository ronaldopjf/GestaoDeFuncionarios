using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Entities;
using System.Collections.Generic;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities
{
    public class Department : Entity
    {
        public IEnumerable<Employee> Employees { get; } = new List<Employee>();
    }
}
