using BinaryAdapters;

string filePath = "people.bin";

IPersonRepository personRepository = 
    new PersonBinaryRepository(filePath);

// Agregar algunas personas
personRepository.Add(new Person { Name = "Juan", Age = 17, Height = 170} );
personRepository.Add(new Person { Name = "María", Age = 18, Height = 160 });
personRepository.Add(new Person { Name = "Carlos", Age = 20, Height = 182 });

Console.WriteLine($"Datos de personas guardados en {filePath}");
foreach ( Person person in personRepository.GetAll() )
    Console.WriteLine($"Id: {person.Id}, Nombre: {person.Name}, " +
        $"Edad: {person.Age}, Estatura: {person.Height}");