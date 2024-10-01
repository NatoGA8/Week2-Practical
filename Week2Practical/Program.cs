using System;

class Week2Practical
{
    static void Main(string[] args)
    {
        // Main entry point for the console application.
        // Created by [Your Name]
        // Course: [Course Name]

        int option;

        // Main loop for the greeting menu
        do
        {
            PrintMenu();
            option = InputOption();
            string message = GetMessage(option);
            Console.WriteLine(message);
        } while (option != 0);

        // Main loop for the encryption/decryption menu
        while (true)
        {
            Console.WriteLine("1. Encrypt");
            Console.WriteLine("2. Decrypt");
            Console.WriteLine("3. Exit");
            int choice = InputOption();

            if (choice == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Write("Enter the text: ");
                string text = Console.ReadLine();
                Console.Write("Enter rotation (1-100): ");
                int rotations = InputOption();
                if (rotations < 1 || rotations > 100)
                {
                    Console.WriteLine("Invalid rotation. Please enter a value between 1 and 100.");
                    continue;
                }

                if (choice == 1)
                {
                    string encrypted = Encrypt(text, rotations);
                    Console.WriteLine($"Encrypted text: {encrypted}");
                }
                else if (choice == 2)
                {
                    string decrypted = Decrypt(text, rotations);
                    Console.WriteLine($"Decrypted text: {decrypted}");
                }
            }
        }
    }

    // Task 1: Method to print the greeting menu
    static void PrintMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine("0. Exit");
        Console.WriteLine("1. French (Bonjour)");
        Console.WriteLine("2. Portuguese (Ola)");
        Console.WriteLine("3. German (Hallo)");
        Console.WriteLine("4. Italian (Ciao)");
        Console.WriteLine("Please select an option:");
    }

    // Task 2: Method to get user option
    static int InputOption()
    {
        int option = -1;
        try
        {
            option = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}. Please enter a valid number.");
        }
        return option;
    }

    // Task 3: Method to get the greeting message
    static string GetMessage(int language)
    {
        switch (language)
        {
            case 0: return "Goodbye";
            case 1: return "Bonjour";
            case 2: return "Ola";
            case 3: return "Hallo";
            case 4: return "Ciao";
            default: return "Please enter a valid option";
        }
    }

    // Task 6: Method for Caesar Cipher Encryption
    static string Encrypt(string input, int rotations)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result[i] = (char)((((c + rotations) - offset) % 26) + offset);
            }
            else
            {
                result[i] = c; // Non-letter characters remain unchanged
            }
        }

        return new string(result);
    }

    // Task 7: Method for Caesar Cipher Decryption
    static string Decrypt(string input, int rotations)
    {
        return Encrypt(input, 26 - (rotations % 26)); // Decrypt by reversing the rotation
    }

    // Task 10: Method to calculate the area of a circle
    static double CircleArea(double radius)
    {
        return Math.PI * Math.Pow(radius, 2);
    }
}
