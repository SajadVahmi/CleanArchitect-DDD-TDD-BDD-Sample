using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Entities
{
    public class Entity<TKEY> : IEntity, IEquatable<Entity<TKEY>>
    {
        public TKEY Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity<TKEY>)obj);
        }
        public override int GetHashCode()
        {
            return EqualityComparer<TKEY>.Default.GetHashCode(Id);
        }
        public bool Equals(Entity<TKEY> other)
        {
            if (other == null) return false;
            return this.Id.Equals(other.Id);
        }
    }
}
