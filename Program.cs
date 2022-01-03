using System;
using System.IO;

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

        static void CreateFile() 
        {
            string currentDateAndTime = DateTime.Now.ToString("ddMMyyyy");
            string folderName = "Output/";
            string filePath = folderName + currentDateAndTime + "_EmailTemplate.txt";

            using (System.IO.FileStream fs = File.Create(filePath)){
                Console.WriteLine("File is saved in the Output Folder:" + filePath); 
            }

        }

        static void Main(string[] args)
        {
            string templatefile = System.IO.File.ReadAllText(@"templatefile.txt");

            Menu();
            string input = Console.ReadLine();
            if (input=="1") 
            {
                Console.WriteLine(templatefile);
                CreateFile();   
            }
        
        }
    }
}
