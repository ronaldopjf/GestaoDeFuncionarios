﻿using AutoMapper;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Repositories;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Repositories;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Interfaces.Services;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Interfaces.UnityOfWork;
using System;
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
                return new ResponseObject<EmployeeForReadDto>(false, "Departamento inexistente");

            var employeeForCheckLogin = _employeeRepository.Get(employeeForRegisterDto.Login);
            if (employeeForCheckLogin != null)
                return new ResponseObject<EmployeeForReadDto>(false, "Login já cadastrado");

            if (employeeForRegisterDto.Access && _employeeRepository.CountAccess() > 10)
                return new ResponseObject<EmployeeForReadDto>(false, "Dismarque a opção acesso ao sistema. Limite excedido");

            var employeeForRegister = _mapper.Map<Employee>(employeeForRegisterDto);
            _employeeRepository.Post(employeeForRegister);

            try
            {
                var commit = _unityOfWork.Commit();

                return commit
                    ? new ResponseObject<EmployeeForReadDto>(true, obj: _mapper.Map<EmployeeForReadDto>(employeeForRegister))
                    : new ResponseObject<EmployeeForReadDto>(false);
            }
            catch (Exception e)
            {
                return new ResponseObject<EmployeeForReadDto>(false, e.InnerException.Message, null);
            }
        }

        public ResponseObject<EmployeeForReadDto> Put(EmployeeForUpdateDto employeeForUpdateDto)
        {
            var departmentForCheckId = _departmentRepository.Get(employeeForUpdateDto.idDepartment);
            if (departmentForCheckId == null)
                return new ResponseObject<EmployeeForReadDto>(false, "Departamento inexistente");

            var employeeForCheckLogin = _employeeRepository.Get(employeeForUpdateDto.Login);
            if (employeeForCheckLogin != null && employeeForCheckLogin.Id != employeeForUpdateDto.Id)
                return new ResponseObject<EmployeeForReadDto>(false, "Login já cadastrado");

            if (employeeForUpdateDto.Access && _employeeRepository.CountAccess() > 10)
                return new ResponseObject<EmployeeForReadDto>(false, "Dismarque a opção acesso ao sistema! Limite excedido");

            var employeeForCheckId = _employeeRepository.Get(employeeForUpdateDto.Id);
            if (employeeForCheckId == null)
                return new ResponseObject<EmployeeForReadDto>(false, "Funcionário inexistente");

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

        public ResponseObject<bool> Delete(IEnumerable<EmployeeForReadDto> employees)
        {
            _employeeRepository.Delete(_mapper.Map<IEnumerable<Employee>>(employees));
            var commit = _unityOfWork.Commit();

            return commit
                ? new ResponseObject<bool>(true, "Funcionários excluídos com sucesso", true)
                : new ResponseObject<bool>(false, "A exclusão falhou", false);
        }

        public ResponseObject<bool> CanAccess()
        {
            var countAccess = _employeeRepository.CountAccess();

            return countAccess <= 10
                ? new ResponseObject<bool>(true, "Pode Acessar", true)
                : new ResponseObject<bool>(false, "Dismarque a opção acesso ao sistema! Limite excedido", false);
        }
    }
}
