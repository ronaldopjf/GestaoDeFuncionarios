using AutoMapper;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Repositories;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Repositories;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Services;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Interfaces.UnityOfWork;
using System.Collections.Generic;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IMapper mapper, IUnityOfWork unityOfWork, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<EmployeeForReadDto> Get()
        {
            var employees = _employeeRepository.Get();
            return _mapper.Map<IEnumerable<EmployeeForReadDto>>(employees);
        }

        public EmployeeForUpdateDto Get(int id)
        {
            var employee = _employeeRepository.Get(id);
            return _mapper.Map<EmployeeForUpdateDto>(employee);
        }

        public ResponseObject<EmployeeForReadDto> Post(EmployeeForCreateDto employeeForRegisterDto)
        {
            var departmentForCheckId = _departmentRepository.Get(employeeForRegisterDto.idDepartment);
            if (departmentForCheckId == null)
                return new ResponseObject<EmployeeForReadDto>(false, "Não existe um departamento com ID informado");

            var employeeForRegister = _mapper.Map<Employee>(employeeForRegisterDto);
            _employeeRepository.Post(employeeForRegister);
            var commit = _unityOfWork.Commit();

            return commit
                ? new ResponseObject<EmployeeForReadDto>(true, obj: _mapper.Map<EmployeeForReadDto>(employeeForRegister))
                : new ResponseObject<EmployeeForReadDto>(false);
        }

        public ResponseObject<EmployeeForReadDto> Put(EmployeeForUpdateDto employeeForUpdateDto)
        {
            var departmentForCheckId = _departmentRepository.Get(employeeForUpdateDto.idDepartment);
            if (departmentForCheckId == null)
                return new ResponseObject<EmployeeForReadDto>(false, "Não existe um departamento com o ID informado");

            var employeeForCheckId = _employeeRepository.Get(employeeForUpdateDto.Id);
            if (employeeForCheckId == null)
                return new ResponseObject<EmployeeForReadDto>(false, "Não existe um funcionário com o ID informado");

            var employeeForUpdate = _mapper.Map<Employee>(employeeForUpdateDto);
            _employeeRepository.Put(employeeForUpdate);
            var commit = _unityOfWork.Commit();

            return commit
                ? new ResponseObject<EmployeeForReadDto>(true, obj: _mapper.Map<EmployeeForReadDto>(employeeForUpdate))
                : new ResponseObject<EmployeeForReadDto>(false);
        }

        public ResponseObject<bool> Delete(int id)
        {
            _employeeRepository.Delete(id);
            var commit = _unityOfWork.Commit();

            return commit
                ? new ResponseObject<bool>(true, "Funcionário excluído com sucesso", true)
                : new ResponseObject<bool>(false, "A exclusão falhou", false);
        }

        public ResponseObject<bool> Activate(int id)
        {
            throw new System.NotImplementedException();
        }

        public ResponseObject<bool> Inactivate(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
