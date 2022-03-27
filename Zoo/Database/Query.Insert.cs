﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Database
{
    public partial class Query
    {
        public Query Insert(params string[] column)
        {

            sql += $"INSERT INTO [{this._TableName}] ({String.Join(", ", column)}) ";

            return this;
        }
    }
}
