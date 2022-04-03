using Framework.Domain.Exceptions;
using Framework.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customers
{
    public class CustomerId : ValueObject<CustomerId>
    {
        public const string INVALID_ID_ERROR = "Id is invalid.";
        public static CustomerId FromGuid(Guid id) => new CustomerId(id);
        protected CustomerId() { this.Value = new Guid(); }
        protected CustomerId(Guid id)
        {
            if (id == default(Guid))
                throw new AppArgumentException(INVALID_ID_ERROR);
            this.Value = id;
        }
        public Guid Value { get; protected set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
