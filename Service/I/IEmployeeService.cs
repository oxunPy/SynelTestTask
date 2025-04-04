using SynelTestTask.Dto;
using SynelTestTask.Entity;

namespace SynelTestTask.Service.I
{
    public interface IEmployeeService : ICrudService<EmployeeDTO>
    {
        Task<EmployeeDTO?> GetEmployeeById(int id);
    }
}
