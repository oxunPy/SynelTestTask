using SynelTestTask.Constants;
using SynelTestTask.Entity;

namespace SynelTestTask.Repository.I
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<ICollection<Employee>> GetEmployees(EntityStatus? status);

        Task<Employee?> GetEmployeeByID(int id);
    }
}
