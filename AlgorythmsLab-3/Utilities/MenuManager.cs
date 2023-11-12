using System;

namespace AlgorythmsLab_3.Utilities
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

        public static void ReturnToMainMenu(string previousMethod)
        {
            Console.WriteLine("Введите 1, чтобы вернуться назад.");
            Console.WriteLine("Введите 2, чтобы ввернуться в главное меню.");
            Console.WriteLine("Введите 3, чтобы завершить программу.");
            while (true)
            {
                int choice = GetMenuChoice();
                switch (choice)
                {
                    case 1:
                        switch (previousMethod)
                        {
                            case "Stack":
                                Tasks.RunStackTasks();
                                break;
                            case "Queue":
                                Tasks.RunQueueTasks();
                                break;
                            case "DinamicStructure":
                                Tasks.RunDynamicStructuresTasks();
                                break;
                            case "List":
                                Tasks.RunListTasks();
                                break;
                            // Добавьте другие ваши кейсы по мере необходимости
                            default:
                                Program.Main();
                                break;
                        }
                        return;
                    case 2:
                        Program.Main();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 3!");
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
