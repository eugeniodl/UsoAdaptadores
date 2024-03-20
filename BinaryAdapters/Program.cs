using BinaryAdapters;

string filePath = "people.bin";

IPersonRepository personRepository = 
    new PersonBinaryRepository(filePath);
/*
personRepository.Add(new Person { Name = "Juan", Age = 17, Height = 1.70});
personRepository.Add(new Person { Name = "María", Age = 18, Height = 1.60});
personRepository.Add(new Person { Name = "Carlos", Age = 20, Height = 1.83});

personRepository.Update(new Person { Id = 3, Name = "Juan Carlos", Age = 19, Height = 1.82 });
*/

personRepository.Delete(2);

Console.WriteLine($"Datos de personas en {filePath}");
foreach (Person person in personRepository.GetAll())
    Console.WriteLine($"Id: {person.Id}, Nombre: {person.Name}, " +
        $"Edad: {person.Age}, Estatura: {person.Height}");