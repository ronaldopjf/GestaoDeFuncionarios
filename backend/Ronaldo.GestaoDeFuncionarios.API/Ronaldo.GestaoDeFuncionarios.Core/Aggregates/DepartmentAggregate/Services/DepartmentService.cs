using AutoMapper;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.DTOs;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Repositories;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Interfaces.Services;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Entities;
using Ronaldo.GestaoDeFuncionarios.Core.SharedKernel.Interfaces.UnityOfWork;
using System.Collections.Generic;

namespace Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IMapper mapper, IUnityOfWork unityOfWork, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentForGetDto> Get()
        {
            var departments = _departmentRepository.Get();
            return _mapper.Map<IEnumerable<DepartmentForGetDto>>(departments);
        }

        public DepartmentForGetDto Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ResponseObject<DepartmentForGetDto> Post(DepartmentForGetDto employeeForRegisterDto)
        {
            throw new System.NotImplementedException();
        }

        public ResponseObject<DepartmentForGetDto> Put(DepartmentForGetDto employeeForEditDto)
        {
            throw new System.NotImplementedException();
        }

        public ResponseObject<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
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
