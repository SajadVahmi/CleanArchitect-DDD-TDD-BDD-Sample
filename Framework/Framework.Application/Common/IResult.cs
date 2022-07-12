﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application.Common
{
    public interface IResult
    {
        IEnumerable<string> Errors { get; }
        ResultStatus Status { get; set; }
    }
}
