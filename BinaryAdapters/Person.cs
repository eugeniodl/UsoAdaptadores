using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAdapters
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }

        public Person() : this(0, string.Empty, 0, 0){ }

        public Person(int id, string name, int age, double height)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
        }
    }

}
