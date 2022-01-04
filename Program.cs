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
            string templateFile = System.IO.File.ReadAllText(@"templatefile.txt");

            Menu();
            string input = Console.ReadLine();
            
            while (input != "e") {
            if (input=="1") 
            {
                Console.WriteLine("What is your event's name?");
                string eventName = Console.ReadLine();
                Console.WriteLine("What is your event's time?");
                string eventTime = Console.ReadLine();

                templateFile = templateFile.Replace("@EventName", eventName).Replace("@EventDate","eventTime");

                Console.WriteLine(templateFile);
                CreateFile();   
            }
            else 
            {
                return; //Exit program. 
            }
            
        
        }
    }
}
