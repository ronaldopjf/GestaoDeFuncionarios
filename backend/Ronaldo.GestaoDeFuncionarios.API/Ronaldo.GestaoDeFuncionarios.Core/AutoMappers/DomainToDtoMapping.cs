using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;

namespace Ronaldo.GestaoDeFuncionarios.Core.AutoMappers
{
    public class DomainToDtoMapping : AutoMapper.Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Employee, EmployeeForReadDto>().ReverseMap();
            CreateMap<Employee, EmployeeForCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeForUpdateDto>().ReverseMap();
            CreateMap<Department, DepartmentForGetDto>().ReverseMap();
        }
    }
}
