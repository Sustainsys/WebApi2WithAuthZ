using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthZInOwin.Services
{
    public class Options<T> : IOptions<T>
        where T : class, new()
    {
        public Options(T options)
        {
            Value = options;
        }

        public T Value { get; }
    }
}