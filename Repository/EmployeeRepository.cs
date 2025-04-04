using Microsoft.EntityFrameworkCore;
using SynelTestTask.Constants;
using SynelTestTask.Data;
using SynelTestTask.Entity;
using SynelTestTask.Repository.I;

namespace SynelTestTask.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DataContext _dbContext;

        public EmployeeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Employee? Create(Employee? entity)
        {
            if(entity == null)
                return null;

            _dbContext.Employees.Add(entity);
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? entity : null;
        }

        public bool Delete(int id)
        {
            Employee? entity = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();
            if (entity == null)
                return false;

            entity.ForDelete();
            _dbContext.Employees.Update(entity);
            var saved = _dbContext.SaveChanges();
            return saved > 0;
        }

        public Employee? Update(Employee? entity)
        {
            if (entity == null)
                return null;

            _dbContext.Employees.Update(entity);
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? entity : null;
        }

        public async Task<Employee?> GetEmployeeByID(int id)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ICollection<Employee>> GetEmployees(EntityStatus? status)
        {
            return await _dbContext.Employees.Where(e => status != null && e.Status == status).ToListAsync();
        }

        
    }
}
