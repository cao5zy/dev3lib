using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev3Lib.Util;

namespace Dev3Lib.Web
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SessionObjectAttribute : Attribute
    {
        public readonly string SessionId;
        public SessionObjectAttribute(string attrId) : base() {
            if (attrId.IsNullOrEmpty())
                throw new ArgumentNullException("attrId");

            SessionId = attrId;
        }
    }
}
