using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthZInOwin.Services
{
    public class ValueService
    {
        public IEnumerable<string> GetValues() => new string[] { "value1", "value2" };
}
}