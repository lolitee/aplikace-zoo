using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo.Models.Caregiver.Commands
{
    internal class CreateCaregiver : ObservableObject, ICommand
    {
        void IDisposable.Dispose() { }
        public void Execute(DB db)
        {
            throw new NotImplementedException();
        }

    }
}
