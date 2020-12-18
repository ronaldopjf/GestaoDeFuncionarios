using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities;
using System;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.DTOs
{
    public class EmployeeForUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int idDepartment { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Access { get; set; }
        public bool Active { get; set; }
    }
}
