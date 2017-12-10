using System;
using System.IO;

namespace ExceptionHandeling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader streamreader = new StreamReader(@"E:\Data.txt");
                Console.WriteLine(streamreader.ReadToEnd());
                streamreader.Close();
                Console.ReadLine();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.FileName);
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(ex.StackTrace);
            }
            
        }
    }
}
