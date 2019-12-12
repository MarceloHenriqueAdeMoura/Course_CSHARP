using System;
using System.IO;

namespace File_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\Marcelo\Documents\VisualStudioCode Projects\c#\arquivos\arquivo1.txt";
            string targetPath = @"C:\Users\Marcelo\Documents\VisualStudioCode Projects\c#\arquivos\arquivo2.txt";

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);

                string[] lines = File.ReadAllLines(sourcePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: " + e.Message);                
            }
        }
    }   
}