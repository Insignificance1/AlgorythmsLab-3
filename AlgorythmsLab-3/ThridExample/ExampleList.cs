using AlgorythmsLab_3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3
{
    public class ExampleList
    {
        public static List<T> Example<T>(List<T> firstList, List<T> secondList)
        {
            List<T> result = new List<T>();
            foreach (T item in firstList)
            {
                if (secondList.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
            
        }
        public static void ExecuteList()
        {
            int size = 10;
            List<int> firstList = Generate.GenerateRandomList(size);
            List<int> secondList = Generate.GenerateRandomList(size);
            List<int> result = Example(firstList, secondList);
            Console.Write("Первый лист: ");
            foreach (int item in firstList)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.Write("Второй лист: ");

            foreach (int item in secondList)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.Write("Дубликаты: ");
            foreach (int item in result)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
 
        }
    }
}

