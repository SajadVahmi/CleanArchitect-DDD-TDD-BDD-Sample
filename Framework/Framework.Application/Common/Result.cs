using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Common
{
    public class Result : IResult
    {
        protected readonly List<string> errors = new List<string>();

        public IEnumerable<string> Errors => errors;

        public ResultStatus Status { get; set; }

        public void AddError(string error)
        {
            errors.Add(error);
        }
        public void AddError(List<string> errors)
        {
            this.errors.AddRange(errors);
        }
        public void ClearErrors()
        {
            errors.Clear();
        }
    }

    public class Result<TData>:Result
    {
        internal TData data;
        public TData Data
        {
            get
            {
                return data;
            }
        }
    }
}
