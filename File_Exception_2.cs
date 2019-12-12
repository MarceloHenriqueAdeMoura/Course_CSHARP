using System;
using System.IO;

namespace File_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Marcelo\Documents\VisualStudioCode Projects\c#\arquivos\arquivo1.txt";

            StreamReader streamReader = null;

            try
            {                
                streamReader = File.OpenText(path);
                while(!streamReader.EndOfStream){
                    string line = streamReader.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("An error accurred: " + e);
            }
            finally
            {
                if(streamReader != null) streamReader.Close();           
            }
        }
    }
}