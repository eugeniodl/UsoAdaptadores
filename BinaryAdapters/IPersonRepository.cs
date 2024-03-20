using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAdapters
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetPerson(int id);
        void Add(Person person);
        void Update(Person person);
        void Delete(int id);
    }
}
