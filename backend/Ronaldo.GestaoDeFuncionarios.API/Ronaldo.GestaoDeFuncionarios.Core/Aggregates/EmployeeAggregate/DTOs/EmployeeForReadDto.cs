using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.DTOs
{
    public class EmployeeForReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone { get; set; }
        public bool Access { get; set; }
        public bool Active { get; set; }
    }
}
