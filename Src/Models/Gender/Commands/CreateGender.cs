using System;
using Zoo.Database;

namespace Zoo.Models.Gender.Commands
{
    internal class CreateGender : ICommand
    {
        void IDisposable.Dispose()
        {
        }

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