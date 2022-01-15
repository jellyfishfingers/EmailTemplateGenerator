using System;
using System.IO;
using System.Threading;

namespace EmailTemplateGenerator
{
  class EmailTemplate
  {
    public string FinalTemplateOutput; 

    public EmailTemplate ()
    {
      this.FinalTemplateOutput = String.Empty;
    }

    static void Menu()
    {
      Console.WriteLine("Welcome to the application.");
      Console.WriteLine("---------------------------");
      Console.WriteLine("Please enter the following:");
      Console.WriteLine("1 - To create a new template.");
      Console.WriteLine("E - To exit the program.");
    }

    static void RunProgram(EmailTemplate emailTemplate)
    {
      string templateContent = System.IO.File.ReadAllText(@"templatefile.txt");
      Console.WriteLine("What is your event's name?");
      string eventName = Console.ReadLine();
      Console.WriteLine("What is your event's date?");
      string eventDate = Console.ReadLine();
      Console.WriteLine("What is your event's time?");
      string eventTime = Console.ReadLine();

      templateContent = templateContent.Replace("@EventName", eventName);
      templateContent = templateContent.Replace("@EventDate", eventDate);
      templateContent = templateContent.Replace("@EventTime", eventTime);

      PreviewTemplateContent(templateContent);

      emailTemplate.FinalTemplateOutput = templateContent;

      CreateFile(emailTemplate);
    }

    static void PreviewTemplateContent(string templateContent)
    {
      Console.WriteLine("Here's a preview of the template file.");
      Console.WriteLine("--------------------------------------");
      Console.WriteLine(templateContent);
      Console.WriteLine("--------------------------------------");
    }

    static void CreateFile(EmailTemplate emailTemplate) 
    {
      string currentDateAndTime = DateTime.Now.ToString("ddMMyyyy");
      string folderName = "Output\\";
      string filePath = folderName + currentDateAndTime + "_EmailTemplate.txt";

      string getWorkingDirectory = Directory.GetCurrentDirectory();
      string fullOutputFolderPath = getWorkingDirectory + "\\" + folderName;

      if (!Directory.Exists(fullOutputFolderPath))
      {
        Directory.CreateDirectory(fullOutputFolderPath);
      }

      try
      {
        File.WriteAllText(filePath, emailTemplate.FinalTemplateOutput);
        Console.WriteLine("File is saved in the Output Folder:" + filePath);
        Console.WriteLine("");
        Console.WriteLine("");
      }
      catch (Exception e)
      {

      }
    }

    static void Main(string[] args)
    {
      EmailTemplate emailTemplate = new EmailTemplate();

      string input = "0";
            
      while (input != "e") 
      {
        Menu();
        input = Console.ReadLine();

        if (input == "1")
        {
          RunProgram(emailTemplate);
        }
      }
      Console.WriteLine("K Thanks Bye.");
      Thread.Sleep(5000); 
      return; //Exit program. 
    }
    
  }
}
