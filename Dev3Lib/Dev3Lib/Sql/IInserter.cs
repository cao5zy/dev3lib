using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    interface IInserter
    {
        void Insert(IInsertValue value);
    }
}
