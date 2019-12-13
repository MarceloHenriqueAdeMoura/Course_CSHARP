using System;
using System.IO;

namespace File_StreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\Marcelo\Documents\VisualStudioCode Projects\c#\arquivos\arquivo1.txt";
            string targetPath = @"C:\Users\Marcelo\Documents\VisualStudioCode Projects\c#\arquivos\arquivo2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter writer = File.AppendAllText(targetPath))
                {
                    foreach(string line in lines)
                    {
                        writer.WriteLine(line.ToUpper());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: " + e);
            }
        }
    }
}