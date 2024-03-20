﻿// Ejemplo de escritura y lectura de datos
// en un archivo de texto

string texto = "Este es un ejemplo";
File.WriteAllText("ejemplo.txt", texto);

string texto2 = File.ReadAllText("ejemplo.txt");
Console.WriteLine($"Texto leído desde el archivo: " +
    $"{texto2}");

// Escribir datos en un archivo binario
int[] numeros = { 1, 2, 3, 4, 5 };
using(BinaryWriter br = new BinaryWriter(
    File.Open("numeros.bin", FileMode.Create)))
    foreach(int numero in numeros)
        br.Write(numero);

// Leer datos desde un archivo binario
int[] numerosLeidos;
using (BinaryReader br = new BinaryReader(
    File.Open("numeros.bin", FileMode.Open)))
{
    numerosLeidos = new int[numeros.Length];
    for (int i = 0; i < numerosLeidos.Length; i++)
        numerosLeidos[i] = br.ReadInt32();
}

Console.WriteLine("Números leídos " +
    "desde el archivo binario");
foreach(int numero in numeros)
    Console.WriteLine( numero);
