﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    interface IUpdater
    {
        void Update(string tableName, IUpdateValue value, WhereClause where);
    }
}
