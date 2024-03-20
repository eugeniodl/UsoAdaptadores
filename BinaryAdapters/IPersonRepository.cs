using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAdapters
{
    public interface IPersonRepository
    {
        Person GetPerson(int id);
        IEnumerable<Person> GetAll();
        void Add(Person person);
        void Update(Person person);
        void Delete(int id);
    }
}
