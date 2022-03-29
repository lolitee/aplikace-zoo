using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animal
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public int AnimalId { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool autistic { get; set; }
        public int ZooId { get; set; }
        public int CaretakerId { get; set; }
    }
}
