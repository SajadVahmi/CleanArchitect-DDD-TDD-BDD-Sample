using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.ValueObjects
{
    public class FullName : ValueObject<FullName>
    {
        public const string INAVLID_FIRST_OR_LAST_NAME_ERROR = "The firstname or lastname is invalid.";
        public static FullName Create(string firstname, string lastname) => new FullName(firstname, lastname);
        protected FullName() { }
        protected FullName(string firstname, string lastname)
        {
            if (string.IsNullOrEmpty(firstname?.Trim()) || string.IsNullOrEmpty(lastname?.Trim()))
                throw new AppArgumentException(INAVLID_FIRST_OR_LAST_NAME_ERROR);
            Firstname = firstname;
            Lastname = lastname;
        }



        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Firstname;
            yield return Lastname;
        }
    }
}
