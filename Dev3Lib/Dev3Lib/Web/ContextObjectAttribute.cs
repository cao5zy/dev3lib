using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Web
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ContextObjectAttribute : Attribute
    {
        public readonly string ContextId;
        public ContextObjectAttribute(string contextId) : base() {
            if (contextId.IsNullOrEmpty())
                throw new ArgumentNullException("contextId");

            ContextId = contextId;
        }
    }
}
