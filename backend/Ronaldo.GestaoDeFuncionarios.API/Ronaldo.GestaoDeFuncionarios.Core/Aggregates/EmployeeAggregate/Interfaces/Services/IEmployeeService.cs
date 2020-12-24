using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Entities;
using System.Collections.Generic;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeForReadDto> Get();
        EmployeeForUpdateDto Get(int id);
        ResponseObject<EmployeeForReadDto> Post(EmployeeForCreateDto employeeForCreateDto);
        ResponseObject<EmployeeForReadDto> Put(EmployeeForUpdateDto employeeForUpdateDto);
        ResponseObject<bool> Delete(int id);
        ResponseObject<bool> Delete(IEnumerable<EmployeeForReadDto> employees);
    }
}
