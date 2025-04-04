using SynelTestTask.Entity;

namespace SynelTestTask.Repository
{
    public class DBOperation
    {
        public delegate T? SaveOperation<T> (T? entity) where T : BaseEntity;
    }
}
