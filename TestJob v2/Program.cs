using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace TestJob_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please, enter path to the file - ");
                string path = Console.ReadLine();
                Dictionary words = new Dictionary(path);
                Console.Write("Please, enter your word: ");
                string request = Console.ReadLine();
                if (request == "###")
                {
                    Console.WriteLine("Application complete.");
                    Thread.Sleep(2000);
                    return;
                }
                else
                {
                    words.Complete(request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey(true);
        }
    }
}
