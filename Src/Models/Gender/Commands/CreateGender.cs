﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Gender.Commands
{
    internal class CreateGender : ICommand
    {
        void IDisposable.Dispose() { }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Execute(DB db)
        {
            throw new NotImplementedException();
        }

    }
}