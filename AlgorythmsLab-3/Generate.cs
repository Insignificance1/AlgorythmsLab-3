using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3
{
    class Generate
    {
        public static void GenerateInputFile()
        {
            // Генерация содержимого файла input.txt
            Random random = new Random();
            int operationsCount = random.Next(5, 15);

            using (StreamWriter writer = new StreamWriter("input.txt"))
            {
                for (int i = 0; i < operationsCount; i++)
                {
                    int operation = random.Next(1, 6);
                    writer.Write($"{operation} ");

                    if (operation == 1)
                    {
                        // Для операции Push добавляем случайное значение
                        writer.Write($"{GenerateRandomValue(random)} ");
                    }
                }
            }
        }

        private static object GenerateRandomValue(Random random)
        {
            // Генерация случайного значения (числа или слова)
            if (random.Next(2) == 0)
            {
                return random.Next(1, 101); // Генерация случайного числа от 1 до 100
            }
            else
            {
                string[] words = { "cat", "dog", "bird", "apple", "orange" };
                return words[random.Next(words.Length)];
            }
        }
    }

}
