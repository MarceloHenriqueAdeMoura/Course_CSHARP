using System;
using System.IO;

namespace File_Using
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Marcelo\Documents\VisualStudioCode Projects\c#\arquivos\arquivo1.txt";

            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}