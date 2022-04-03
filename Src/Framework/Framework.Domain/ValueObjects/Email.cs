using Framework.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public const string REGEX = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public const string INVALID_EMAIL_ERROR = "Email is invalid";
        public static Email Create(string email) => new Email(email);
        protected Email() { }
        protected Email(string email)
        {
            var regex = new Regex(REGEX);
            if (string.IsNullOrEmpty(email?.Trim()) || !regex.IsMatch(email))
                throw new AppArgumentException(INVALID_EMAIL_ERROR);
            this.Value = email;
        }
        public string Value { get; protected set; }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
