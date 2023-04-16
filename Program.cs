using System;
using System.Collections.Generic;

namespace csharp_animals
{
    internal class Program
    {
        private const string FileName = "animals.txt";

        private static void Main()
        {
            var zoo = new List<ITalkable>();
            AnimalCreator.CreateAnimals(zoo);

            using (var outputFile = new FileOutput(FileName))
            {
                foreach (var p in zoo)
                {
                    Console.WriteLine($"{p.GetName()} says={p.Talk()}");
                    outputFile.FileWrite($"{p.GetName()} | {p.Talk()}");
                }
            }

            using var inData = new FileInput(FileName);
            while (inData.FileReadLine() is { } line)
            {
                Console.WriteLine(line);
            }
        }
    }
}