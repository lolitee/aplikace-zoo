using System;
using Zoo.Database;

namespace Zoo.Models.Caregiver.Commands
{
    internal class CreateCaregiver : ICommand
    {
        void IDisposable.Dispose()
        {
        }

        public void Execute(DB db)
        {
            throw new NotImplementedException();
        }
    }
}