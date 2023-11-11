using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3
{
    class Tasks
    {
        public static void RunStackTasks()
        {
            Console.WriteLine("Выберите задание стека:");
            Console.WriteLine("1. Запуск различных наборов операций из файла input.txt с выводом на экран");
            Console.WriteLine("2. Запуск с замером времени различных наборов операций из файла input.txt.");
            Console.WriteLine("3. Вычисление в постфиксной записи");
            Console.WriteLine("4. Перевод из инфиксной записи в постфиксную запись");
            Console.WriteLine("5. Запуск с замером времени различных наборов операций из файла input.txt, для встроенного класса Stack в C#");

            while (true)
            {
                int choice = MenuManager.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Executor.ExecuteStackOperations();
                        break;
                    case 2:
                        Console.Clear();
                        Executor.ExecuteStackOperationsFromFile();
                        break;
                    case 3:
                        Console.Clear();
                        Executor.ExecutePostfixCalculation();
                        break;
                    case 4:
                        Console.Clear();
                        Executor.ExecuteInfixToPostfixTask();
                        break;
                    case 5:
                        Console.Clear();
                        Executor.ExecuteStackOperationsWithBuiltInStack();
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 5!");
                        continue;
                }
            }
        }

        public static void RunQueueTasks()
        {
            Console.WriteLine("Выберите задание очереди:");
            Console.WriteLine("1. Запуск различных наборов операций из файла input.txt с выводом на экран");
            Console.WriteLine("2. Запуск с замером времени различных наборов операций из файла input.txt.");

            while (true) 
            {
                int choice = MenuManager.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        // Реализация задания 1 для очереди
                        break;
                    case 2:
                        // Реализация задания 2 для очереди
                        break;
                    case 3:
                        // Реализация задания 3 для очереди
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        continue;
                }
            }
        }

        public static void RunDynamicStructuresTasks()
        {
            Console.WriteLine("Выберите задание динамических структур данных:");
            Console.WriteLine("1. Пример использования структуры данных Список");
            Console.WriteLine("2. Пример использования структуры данных Стек");
            Console.WriteLine("3. Пример использования структуры данных Очередь");
            Console.WriteLine("4. Пример использования структуры данных Дерево");

            while (true)
            {
                int choice = MenuManager.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        // Реализация задания 1 для динамических структур данных (Список)
                        break;
                    case 2:
                        // Реализация задания 2 для динамических структур данных (Стек)
                        break;
                    case 3:
                        // Реализация задания 3 для динамических структур данных (Очередь)
                        break;
                    case 4:
                        // Реализация задания 4 для динамических структур данных (Дерево)
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 4!");
                        continue;
                }
            }
        }

        public static void RunListTasks()
        {
            Console.WriteLine("Выберите задание листа:");
            Console.WriteLine("1. Перевернуть список");
            Console.WriteLine("2. Поменять местами первый и последний элемент");
            Console.WriteLine("3. Количество целых чисел");
            Console.WriteLine("4. Удалить все неуникальные элементы");
            Console.WriteLine("5. Вставка самого себя после первого вхождения X");
            Console.WriteLine("6. Вставка элемента с сохранением порядка");
            Console.WriteLine("7. Удалить элементы E");
            Console.WriteLine("8. Вставка элемента F перед первым вхождением E");
            Console.WriteLine("9. Считать 2 списка из файла и записать их в 1");
            Console.WriteLine("10. Разбить список по заданному числу");
            Console.WriteLine("11. Удвоить список");
            Console.WriteLine("12. Переставить элементы");

            while (true)
            {
                int choice = MenuManager.GetMenuChoice(); 

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Executor.ReverseLinkedList();
                        break;
                    case 2:
                        Console.Clear();
                        Executor.MoveLastToFrontToLast(); 
                        break;
                    case 3:
                        Console.Clear();
                        Executor.DistinctElementsCount();
                        break;
                    case 4:
                        Console.Clear();
                        Executor.ExecuteRemoveNonUniqueElements();
                        break;
                    case 5:
                        Console.Clear();
                        // Реализация задания 5 для листа
                        break;
                    case 6:
                        Console.Clear();
                        // Реализация задания 6 для листа
                        break;
                    case 7:
                        Console.Clear();
                        // Реализация задания 7 для листа
                        break;
                    case 8:
                        Console.Clear();
                        // Реализация задания 8 для листа
                        break;
                    case 9:
                        Console.Clear();
                        // Реализация задания 9 для листа
                        break;
                    case 10:
                        Console.Clear();
                        // Реализация задания 10 для листа
                        break;
                    case 11:
                        Console.Clear();
                        // Реализация задания 11 для листа
                        break;
                    case 12:
                        Console.Clear();
                        // Реализация задания 12 для листа
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 12!");
                        continue;
                }
            }
        }
     }

}
