using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Database;

namespace Zoo
{
    internal class Debug
    {
        public Debug(DB db)
        {
            try
            {

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
