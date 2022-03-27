﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Values(params string[] values)
        {
            sql += $"VALUES ({String.Join(", ", values.Select(x => $"'{x}'"))})";
            return this;
        }
    }
}