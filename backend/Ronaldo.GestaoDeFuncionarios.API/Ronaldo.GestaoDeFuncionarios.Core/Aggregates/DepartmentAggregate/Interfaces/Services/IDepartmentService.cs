using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Entities;
using System.Collections.Generic;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentForGetDto> Get();
        DepartmentForGetDto Get(int id);
        ResponseObject<DepartmentForGetDto> Post(DepartmentForGetDto departmentForRegisterDto);
        ResponseObject<DepartmentForGetDto> Put(DepartmentForGetDto departmentForEditDto);
        ResponseObject<bool> Delete(int id);
        ResponseObject<bool> Activate(int id);
        ResponseObject<bool> Inactivate(int id);
    }
}
