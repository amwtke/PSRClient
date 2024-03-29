﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o.Query;

namespace APP
{
    interface IDB4OCompare : IQueryComparator
    {
        // 摘要:
        //     Implement to compare two arguments for sorting.
        //
        // 备注:
        //     False Not Same; True the SAME
        bool Compare(object first, object second);
    }
}
