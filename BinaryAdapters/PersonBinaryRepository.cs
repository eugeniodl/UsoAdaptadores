using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryAdapters
{
    public class PersonBinaryRepository : IPersonRepository
    {
        private string _filePath;

        public PersonBinaryRepository(string filePath)
        {
            _filePath = filePath;            
        }
        public void Add(Person person)
        {
            List<Person> people = GetAll().ToList();
            person.Id = people.Count > 0 ? people.Max(p => p.Id) + 1 : 1;
            people.Add(person);

            SavePeople(people);
        }

        private void SavePeople(List<Person> people)
        {
            try
            {
                using (FileStream fs = new FileStream(_filePath,
            FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach (Person person in people)
                    {
                        writer.Write(person.Id);
                        writer.Write(person.Name);
                        writer.Write(person.Age);
                        writer.Write(person.Height);
                    }

                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar personas {ex.Message}");
            }
        }

        public void Delete(int id)
        {
            List<Person> people = GetAll().ToList();
            people.RemoveAll(p => p.Id == id);
            SavePeople(people);
        }

        public IEnumerable<Person> GetAll()
        {
            if(!File.Exists(_filePath))
                return Enumerable.Empty<Person>();

            List<Person> people = new List<Person>();

            try
            {
                using (FileStream fs = new FileStream(_filePath,
            FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        int id = reader.ReadInt32();
                        string name = reader.ReadString();
                        int age = reader.ReadInt32();
                        double height = reader.ReadDouble();
                        people.Add(new Person(id, name, age, height));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( $"Error al leer personas:" +
                    $" {ex.Message}");
            }


            return people;
        }

        public Person GetPerson(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public void Update(Person person)
        {
            List<Person> people = GetAll().ToList();
            int index = people.FindIndex(p => p.Id == person.Id);
            if(index != -1)
            {
                people[index] = person;
                SavePeople(people);
            }
            else
            {
                throw new ArgumentException("Persona no encontrada");
            }
        }
    }
}
