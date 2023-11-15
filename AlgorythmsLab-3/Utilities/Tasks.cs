using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorythmsLab_3.List;
using AlgorythmsLab_3.Queue;
using AlgorythmsLab_3.Stack;

namespace AlgorythmsLab_3.Utilities
{
    class Tasks
    {
        public static void RunStackTasks()
        {
            Console.Clear();

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
                        ExecutorStack.ExecuteStackOperations();
                        break;
                    case 2:
                        Console.Clear();
                        ExecutorStack.ExecuteStackOperationsFromFile();
                        break;
                    case 3:
                        Console.Clear();
                        ExecutorStack.ExecutePostfixCalculation();
                        break;
                    case 4:
                        Console.Clear();
                        ExecutorStack.ExecuteInfixToPostfixTask();
                        break;
                    case 5:
                        Console.Clear();
                        ExecutorStack.ExecuteStackOperationsWithBuiltInStack();
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 5!");
                        continue;
                }
            }
        }

        public static void RunQueueTasks()
        {
            Console.Clear();

            Console.WriteLine("Выберите задание очереди:");
            Console.WriteLine("1. Запуск различных наборов операций из файла input.txt с выводом на экран");
            Console.WriteLine("2. Запуск с замером времени с файлом одинаковым по длине, со случайными операциями из файла input.txt.");
            Console.WriteLine("3. Запуск с замером времени с файлом прогрессирующим по длине, со случайными операциями из файла input.txt.");
            Console.WriteLine("4. Запуск с замером времени с файлом прогрессирующим по длине, со случайными операциями из файла input.txt, для встроенного Queue");


            while (true)
            {
                int choice = MenuManager.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ExecutorQueue.ExecuteQueueOperations();
                        break;
                    case 2:
                        Console.Clear();
                        ExecutorQueue.ExecuteQueueOperationsWithSameLenghtFile();
                        break;
                    case 3:
                        Console.Clear();
                        ExecutorQueue.ExecuteQueueOperationsWithFile();
                        break;
                    case 4:
                        Console.Clear();
                        ExecutorQueue.ExecuteQueueOperationsWithQueue();
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 4!");
                        continue;
                }
            }
        }

        public static void RunDynamicStructuresTasks()
        {
            Console.Clear();

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
                        Console.Clear();
                        ExampleList.ExecuteList();
                        MenuManager.ReturnToMainMenu("DinamicStructure");

                        break;
                    case 2:

                        Console.Clear();
                        ExampleStack.ExcuiteStack();
                        MenuManager.ReturnToMainMenu("DinamicStructure");

                        break;
                    case 3:
                        Console.Clear();
                        TaskManagementSystem.QueueSource();
                        MenuManager.ReturnToMainMenu("DinamicStructure");
                        break;
                    case 4:
                        Console.Clear();
                        BinarySearchTree.ExampleTree();
                        MenuManager.ReturnToMainMenu("DinamicStructure");
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 4!");
                        continue;
                }
            }
        }

        public static void RunListTasks()
        {
            Console.Clear();

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
                        ExecutorList.ReverseLinkedList();
                        break;
                    case 2:
                        Console.Clear();
                        ExecutorList.MoveLastToFrontToLast();
                        break;
                    case 3:
                        Console.Clear();
                        ExecutorList.DistinctElementsCount();
                        break;
                    case 4:
                        Console.Clear();
                        ExecutorList.RemoveNonUniqueElements();
                        break;
                    case 5:
                        Console.Clear();
                        ExecutorList.InsertYourself();
                        break;
                    case 6:
                        Console.Clear();
                        ExecutorList.InsertOrdered();
                        break;
                    case 7:
                        Console.Clear();
                        ExecutorList.RemoveAllOccurrences();
                        break;
                    case 8:
                        Console.Clear();
                        ExecutorList.InsertBeforeFirstOccurrence();
                        break;
                    case 9:
                        Console.Clear();
                        ExecutorList.AppendList();
                        break;
                    case 10:
                        Console.Clear();
                        ExecutorList.SplitListExample();
                        break;
                    case 11:
                        Console.Clear();
                        ExecutorList.DuplicateListExample();
                        break;
                    case 12:
                        Console.Clear();
                        ExecutorList.SwapElementsExample();
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 12!");
                        continue;
                }
            }
        }
    }

}
