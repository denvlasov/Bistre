namespace SmartHomeSystem.Domain.DomainBase
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; protected set; }

        //for created but not persisted objects
        public bool IsTransient()
        {
            return Id == default(int);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }

            EntityBase item = (EntityBase)obj;
            return (item.IsTransient() || IsTransient())
                ? false
                : item.Id == Id;
        }

        public override int GetHashCode()
        {
            return (!IsTransient())
                ? Id.GetHashCode() ^ 31
                : base.GetHashCode();
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            return (Equals(left, null))
                ? Equals(right, null)
                : left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }
    }
}
