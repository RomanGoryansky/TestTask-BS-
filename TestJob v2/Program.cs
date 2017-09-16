using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.ComponentModel.DataAnnotations;
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
                Console.Write("Please, enter your word: ");
                string request = Console.ReadLine();
                if (request == "###")
                {
                    Console.WriteLine("Application complete.");
                    Thread.Sleep(3000);
                    return;
                }
                else if (request == "")
                {
                    Console.WriteLine("You didn't enter anything");
                }
                else
                {
                    Dictionary words = new Dictionary(path, request);
                    words.Complete();
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
