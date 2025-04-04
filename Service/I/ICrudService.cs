using SynelTestTask.Constants;
using SynelTestTask.Dto;
using SynelTestTask.Dto.Response;

namespace SynelTestTask.Service.I
{
    public interface ICrudService<T> where T : BaseDTO
    {
        Task<SynelHttpResponse<T>> Add(T item);

        Task<SynelHttpResponse<T>> Update(T item);

        Task<SynelHttpResponse<bool>> Delete(int Id);

        Task<SynelHttpResponse<ICollection<EmployeeDTO>>> FindAll(EntityStatus status);
    }
}
