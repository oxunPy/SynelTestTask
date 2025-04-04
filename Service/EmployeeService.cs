using Microsoft.Extensions.Logging.Abstractions;
using SynelTestTask.Constants;
using SynelTestTask.Dto;
using SynelTestTask.Dto.Response;
using SynelTestTask.Entity;
using SynelTestTask.Repository;
using SynelTestTask.Repository.I;
using SynelTestTask.Service.I;

namespace SynelTestTask.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<SynelHttpResponse<EmployeeDTO>> Add(EmployeeDTO item)
        {
            Employee? entity = DBExecutor<Employee>.Add(_employeeRepository.Create, item);
            if (entity == null)
            {
                var errorResponse = SynelHttpResponse<EmployeeDTO>.CreateBuilder()
                    .WithStatus(SynelHttpResponse<EmployeeDTO>.HttpStatus.FAILED)
                    .WithMessage("Error creating employee")
                    .Build();

                return Task.FromResult(errorResponse);
            }


            var successResponse = SynelHttpResponse<EmployeeDTO>.CreateBuilder()
                .WithStatus(SynelHttpResponse<EmployeeDTO>.HttpStatus.OK)
                .WithMessage("Employee updated successfully")
                .WithObject(entity.ToDTO<EmployeeDTO>())
                .Build();

            return Task.FromResult(successResponse);
        }

        public Task<SynelHttpResponse<bool>> Delete(int Id)
        {
            SynelHttpResponse<bool> response = SynelHttpResponse<bool>.CreateBuilder()
                .WithStatus(SynelHttpResponse<bool>.HttpStatus.OK)
                .WithMessage("Employee deleted successfully")
                .WithObject(_employeeRepository.Delete(Id))
                .Build();

            return Task.FromResult(response);
        }

        public Task<SynelHttpResponse<ICollection<EmployeeDTO>>> FindAll(EntityStatus status)
        {
            SynelHttpResponse<ICollection<EmployeeDTO>> response = SynelHttpResponse<ICollection<EmployeeDTO>>.CreateBuilder()
                .WithStatus(SynelHttpResponse<ICollection<EmployeeDTO>>.HttpStatus.OK)
                .WithMessage("Employees retrieved successfully")
                .WithObject(_employeeRepository.GetEmployees(status).Result.Select(e => e.ToDTO<EmployeeDTO>()).ToList())
                .Build();

            return Task.FromResult(response);
        }

        public async Task<EmployeeDTO?> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByID(id);
            return employee?.ToDTO<EmployeeDTO>();
        }

        public async Task<SynelHttpResponse<EmployeeDTO>> Update(EmployeeDTO item)
        {
            if (item == null || item.Id == null || item.Id == 0)
            {
                return SynelHttpResponse<EmployeeDTO>.CreateBuilder()
                    .WithStatus(SynelHttpResponse<EmployeeDTO>.HttpStatus.BAD_REQUEST)
                    .WithMessage("Invalid employee data")
                    .Build();
            }

            Employee? entity = await _employeeRepository.GetEmployeeByID(item.Id.Value);

            if (entity == null)
            {
                return SynelHttpResponse<EmployeeDTO>.CreateBuilder()
                    .WithStatus(SynelHttpResponse<EmployeeDTO>.HttpStatus.NOT_FOUND)
                    .WithMessage("Employee not found")
                    .Build();
            }

            if (item.PayrollNumber != null)
            {
                entity.PayrollNumber = item.PayrollNumber;
            }

            if (item.ForeName != null)
            {
                entity.ForeName = item.ForeName;
            }

            if (item.Surname != null)
            {
                entity.Surname = item.Surname;
            }

            if (item.EmailHome != null)
            {
                entity.EmailHome = item.EmailHome;
            }

            if (item.Telephone != null)
            {
                entity.Telephone = item.Telephone;
            }

            if (item.Mobile != null)
            {
                entity.Mobile = item.Mobile;
            }

            if (item.MainAddress != null)
            {
                entity.MainAddress = item.MainAddress;
            }

            if (item.SecondaryAddress != null)
            {
                entity.SecondaryAddress = item.SecondaryAddress;
            }

            if (item.Postcode != null)
            {
                entity.Postcode = item.Postcode;
            }

            if (item.DateOfBirth != null)
            {
                entity.DateOfBirth = item.DateOfBirth;
            }

            if (item.StartDate != null)
            {
                entity.StartDate = item.StartDate;
            }

            _employeeRepository.Update(entity);

            return SynelHttpResponse<EmployeeDTO>.CreateBuilder()
                .WithStatus(SynelHttpResponse<EmployeeDTO>.HttpStatus.OK)
                .WithMessage("Employee updated successfully")
                .WithObject(entity.ToDTO<EmployeeDTO>())
                .Build();
        }
    }
}
