using SynelTestTask.Data;
using SynelTestTask.Dto;
using SynelTestTask.Entity;
using System.Runtime.InteropServices;
using static SynelTestTask.Repository.DBOperation;

namespace SynelTestTask.Repository
{
    public class DBExecutor<T> where T : BaseEntity
    {
        public static T? Add(SaveOperation<T> op, BaseDTO dto)
        {
            T? entity = null;
            if(dto is EmployeeDTO eDto)
            {
                entity = Employee.FromDTO(eDto) as T;
            }

            return op(entity);
        }

        public static T? Remove(SaveOperation<T> op, BaseDTO dto)
        {
            T? entity = null;
            if (dto is EmployeeDTO eDto)
            {
                entity = Employee.FromDTO(eDto) as T;
            }

            return op(entity);
        }

        public static T? Update(SaveOperation<T> op, BaseDTO dto)
        {
            T? entity = null;
            if (dto is EmployeeDTO eDto)
            {
                entity = Employee.FromDTO(eDto) as T;
            }

            return op(entity);
        }
    }
}
