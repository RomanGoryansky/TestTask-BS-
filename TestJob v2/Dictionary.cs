using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestJob_v2
{
    class Dictionary
    {
        public List<string> readedwords;            //считанные слова из файла
        public List<string> selection;              //выборка из 5 слов

        public Dictionary(string path)
        {
            string[] input = File.ReadAllLines(path, Encoding.GetEncoding(1251));
            readedwords = new List<string>(input);
            selection = new List<string>();
        }
        public IEnumerable<string> Filling(string demand)       //выбираем все подходящие под запрос слова
        {
            readedwords.Sort();
            int i = readedwords.BinarySearch(demand);           //бинарный поиск
            if (i < 0)
                i = -i - 1;
            while (i >= 0 && readedwords[i].StartsWith(demand))         //если вернули не самое первое соответсвие запросу
                --i;                                                //поднимаемся наверх, к самому первому
            ++i;
            while (i < readedwords.Count && readedwords[i].StartsWith(demand))      //возвращаем все слова, соответствующие нашему запросу
            {
                yield return readedwords[i];
                ++i;
            }

        }
        public void Complete(string request)            //выбираем 5 лучших
        {
            if (request == "")
            {
                Console.WriteLine("You don't enter nothing");
                return;
            }                
            var suitable = Filling(request);
            foreach (var str in suitable)
            {
                if (selection.Count >= 5)
                    break;
                selection.Add(str);                   //т.к слова отсортированы, выбираем 5 первых из всех
                Console.WriteLine(str);
            }
            if (selection.Count == 0)
                Console.WriteLine("No matches found");
        }
    }
}
