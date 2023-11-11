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
            while (true)
            {
                int choice = GetMenuChoice();
                switch (choice)
                {
                    case 1:
                        Program.Main();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 2!");
                        break;
                }
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
