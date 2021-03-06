﻿using Microsoft.EntityFrameworkCore;
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

        public int CountAccess()
        {
            return _dataContext.Set<Employee>().Count(e => e.Access == true);
        }

        public IEnumerable<Employee> Get()
        {
            return _dataContext.Set<Employee>().Include(employee => employee.Department).ToList();
        }

        public Employee Get(string login)
        {
            return _dataContext.Set<Employee>().AsNoTracking().FirstOrDefault(e => e.Login == login);
        }

        public void Delete(IEnumerable<Employee> employees)
        {
            var allEmployees = Get();
            var employeesForRemove = new List<Employee>();

            foreach (var item in employees)
            {
                employeesForRemove.Add(allEmployees.FirstOrDefault(e => e.Id == item.Id));
            }

            _dataContext.Set<Employee>().RemoveRange(employeesForRemove);
        }
    }
}
