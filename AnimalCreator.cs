using System;
using System.Collections.Generic;

namespace csharp_animals
{
    public enum AnimalType
    {
        Dog = 1,
        Cat = 2,
        Teacher = 3
    }

    public static class AnimalCreator
    {
        private static readonly Dictionary<AnimalType, Func<ITalkable>> AnimalFactories = new()
        {
            { AnimalType.Dog, () => new Dog(GetBoolInput("Is the dog friendly? (true/false)"), GetStringInput("Enter the dog's name:")) },
            { AnimalType.Cat, () => new Cat(GetIntInput("Enter the number of mice killed:"), GetStringInput("Enter the cat's name:")) },
            { AnimalType.Teacher, () => new Teacher(GetIntInput("Enter the teacher's age:"), GetStringInput("Enter the teacher's name:")) }
        };

        private static bool GetBoolInput(string prompt)
        {
            bool value;
            while (true)
            {
                Console.WriteLine(prompt);
                if (bool.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                Console.WriteLine("Invalid input, please enter 'true' or 'false'");
            }
            return value;
        }

        private static int GetIntInput(string prompt)
        {
            int value;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    break;
                }
                Console.WriteLine("Invalid input, please enter a valid integer");
            }
            return value;
        }

        private static string GetStringInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? throw new InvalidOperationException();
        }

        public static void CreateAnimals(List<ITalkable> zoo)
        {
            while (true)
            {
                Console.WriteLine("What type of animal do you want to create? (Type 'exit' to quit)");

                foreach (AnimalType type in Enum.GetValues(typeof(AnimalType)))
                {
                    Console.WriteLine($"{(int)type} - {type}");
                }

                var input = Console.ReadLine()?.ToLower();
                if (input == "exit")
                {
                    break;
                }

                AnimalType animalType;
                while (true)
                {
                    try
                    {
                        animalType = (AnimalType)Enum.Parse(typeof(AnimalType), input ?? throw new InvalidOperationException());
                        break;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid animal type, please try again");
                        input = Console.ReadLine()?.ToLower();
                        if (input == "exit")
                        {
                            return;
                        }
                    }
                }

                if (!AnimalFactories.TryGetValue(animalType, out var animalFactory))
                {
                    Console.WriteLine("Invalid animal type");
                    continue;
                }

                var animal = animalFactory();
                zoo.Add(animal);

                Console.WriteLine(animal.ToString());
                Console.WriteLine("Animal created and added to the zoo.");
            }
        }
    }
}
