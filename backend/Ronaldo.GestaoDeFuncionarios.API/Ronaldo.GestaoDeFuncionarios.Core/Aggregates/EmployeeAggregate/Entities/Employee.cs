using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Entities;
using System;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities
{
    public class Employee : Entity
    {
        public string Email { get; set; }
        public int IdDepartment { get; set; }
        public virtual Department Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Access { get; set; }
    }
}
