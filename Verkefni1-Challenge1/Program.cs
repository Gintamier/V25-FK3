using System;
using System.Collections.Generic;
using System.Linq;

class challenge1
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        string input;

        Console.WriteLine("Enter numbers (press Enter to stop):");

        while (true)
        {
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;

            if (int.TryParse(input, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        if (numbers.Count > 0)
        {
            Console.WriteLine($"Smallest number: {numbers.Min()}");
            Console.WriteLine($"Largest number: {numbers.Max()}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}