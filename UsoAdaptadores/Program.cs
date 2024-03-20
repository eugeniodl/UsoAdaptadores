// Ejemplo de escritura y lectura de datos en un archivo de texto

string texto = "Esto es un ejemplo.";
File.WriteAllText("ejemplo.txt", texto);

string texto2 = File.ReadAllText("ejemplo.txt");
Console.WriteLine($"Texto leído desde el archivo: {texto2}");

// Ejemplo de escritura y lectura de datos en un archivo binario

int[] numeros = { 1, 2, 3, 4, 5, 6, 7 };
using(BinaryWriter writer = new BinaryWriter(File.Open(
    "numeros.bin", FileMode.Create)))
    foreach(int numero in numeros)
        writer.Write(numero);

int[] numerosLeidos = new int[numeros.Length];
using(BinaryReader reader = new BinaryReader(File.Open(
    "numeros.bin", FileMode.Open)))
    for(int i = 0; i < numerosLeidos.Length; i++)
        numerosLeidos[i] = reader.ReadInt32();

Console.WriteLine( "Números leídos desde el archivo binario");
foreach(int numero in numerosLeidos)
    Console.WriteLine( numero);
