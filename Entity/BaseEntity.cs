using SynelTestTask.Constants;
using SynelTestTask.Dto;

namespace SynelTestTask.Entity
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Status = EntityStatus.Active;
        }

        public int? Id { get; set; }

        public EntityStatus Status { get; set; }

        public void ForActive()
        {
            Status = EntityStatus.Active;
        }

        public void ForDelete()
        {
            Status = EntityStatus.Deleted;
        }

        public void ForPassive()
        {
            Status = EntityStatus.Passive;
        }

        public abstract T ToDTO<T>() where T : BaseDTO, new();
    }
}
