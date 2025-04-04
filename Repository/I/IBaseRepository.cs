using SynelTestTask.Entity;

namespace SynelTestTask.Repository.I
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T? Create(T? entity);

        T? Update(T? entity);

        bool Delete(int id);
    }
}
