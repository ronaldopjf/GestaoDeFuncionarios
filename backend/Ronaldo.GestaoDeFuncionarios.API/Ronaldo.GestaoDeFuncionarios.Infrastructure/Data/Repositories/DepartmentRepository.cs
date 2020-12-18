using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<Department> Get()
        {
            var departments = _dataContext.Departments
                .Where(department => department.Active == true)
                .ToList();

            return departments;
        }
    }
}
