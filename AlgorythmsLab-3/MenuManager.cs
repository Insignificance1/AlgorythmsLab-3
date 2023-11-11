using System;

namespace AlgorythmsLab_3
{
    public static class MenuManager
    {
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите структуру данных:");
            Console.WriteLine("1. Стек");
            Console.WriteLine("2. Очередь");
            Console.WriteLine("3. Динамические структуры");
            Console.WriteLine("4. Лист");
        }

        public static void ReturnToMainMenu()
        {
            Console.WriteLine("Введите 1, чтобы вернуться в главное меню.");
            Console.WriteLine("Введите 2, чтобы завершить программу.");
            int returnChoice = GetMenuChoice();
            if (returnChoice == 1)
            {
                Program.Main(); // Вызываем метод Main из класса Program
            }
            else if (returnChoice == 2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Некорректный выбор. Программа будет завершена.");
                Environment.Exit(0); // Выход из программы
            }
        }

        public static int GetMenuChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return -1;
        }
    }
}
