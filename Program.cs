using System;

namespace EmailTemplateGenerator
{
    class Program
    {
        static void Menu()
        {
            Console.WriteLine("Welcome to the application.");
            Console.WriteLine("Please enter the following:");
            Console.WriteLine("1 - To create a new template.");
            Console.WriteLine("E - To exit the program.");
        }

        static void Main(string[] args)
        {
            string templatefile = System.IO.File.ReadAllText(@"templatefile.txt");

            Menu();
            string input = Console.ReadLine();
            if (input=="1") 
            {
                Console.WriteLine(templatefile);   
            }
        
        }
    }
}
