using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Continent
{
    public class BaseContinent
    {
        public int Id { get; set; }
        public Continent Continent { get; set; }
        public int ZooId { get; set; }
        public int Something { get; set; }
        public Climate Climate { get; set; }
    }
}
