using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3.Utilities
{
    class Generate
    {
        public static void GenerateInputFile(int size)
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter("input.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    int operation = random.Next(1, 6);
                    writer.Write($"{operation} ");

                    if (operation == 1)
                    {
                        writer.Write($"{GenerateRandomValue(random)} ");
                    }
                }
            }
        }

        private static object GenerateRandomValue(Random random)
        {
            if (random.Next(2) == 0)
            {
                return random.Next(1, 101);
            }
            else
            {
                string[] words = { "cat", "dog", "bird", "apple", "orange" };
                return words[random.Next(words.Length)];
            }
        }

        public static void GenerateInputStackFile(int size)
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter("inputStack.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    int operation = random.Next(1, 6);
                    writer.Write($"{operation} ");

                    if (operation == 1)
                    {
                        writer.Write($"{GenerateRandomValue(random)} ");
                    }
                }
            }
        }

        public static void GenerateInputQueueFile(int size)
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter("inputQueue.txt"))
            {
                for (int i = 0; i < size; i++)
                {
                    int operation = random.Next(1, 6);
                    writer.Write($"{operation} ");

                    if (operation == 1)
                    {
                        writer.Write($"{GenerateRandomValue(random)} ");
                    }
                }
            }
        }
        public static void GenerateInputQueueDifferentFile()
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter("inputQueueDifferent.txt"))
            {
                for (int i = 0; i < 100; i++)
                {
                    int operation = random.Next(1, 6);
                    writer.Write($"{operation} ");

                    if (operation == 1)
                    {
                        writer.Write($"{GenerateRandomValue(random)} ");
                    }
                }
            }
        }
        public static CustomLinkedList<int> GenerateRandomLinkedList(int size)
        {
            CustomLinkedList<int> myList = new CustomLinkedList<int>();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                myList.AddToFront(random.Next(1, 101));
            }

            return myList;
        }
        public static CustomLinkedList<int> GenerateRandomSortedLinkedList(int length)
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.InsertOrdered(random.Next(1, 100));
            }

            return list;
        }
        public static CustomLinkedList<int> GenerateRandomLowValuesLinkedList(int size)
        {
            CustomLinkedList<int> myList = new CustomLinkedList<int>();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                myList.AddToFront(random.Next(1, 11));
            }

            return myList;
        }
        public static List<int> GenerateRandomList(int size)
        {
            List<int> myList = new List<int>();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                myList.Add(random.Next(1, 11));
            }

            return myList;
        }

        
    }


}
