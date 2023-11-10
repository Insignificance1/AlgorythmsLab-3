﻿using System;
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

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Executor.ExecuteStackOperations();
                    break;
                case 2:
                    // Реализация задания 2 для стека
                    break;
                case 3:
                    // Реализация задания 3 для стека
                    break;
                case 4:
                    // Реализация задания 4 для стека
                    break;
                case 5:
                    // Реализация задания 5 для стека
                    break;
                default:
                    Console.WriteLine("Введите номер от 1 до 5!");
                    break;
            }
        }

        public static void RunQueueTasks()
        {
            Console.WriteLine("Выберите задание очереди:");
            Console.WriteLine("1. Запуск различных наборов операций из файла input.txt с выводом на экран");
            Console.WriteLine("2. Запуск с замером времени различных наборов операций из файла input.txt.");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Реализация задания 1 для очереди
                    break;
                case 2:
                    // Реализация задания 2 для очереди
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }

        public static void RunDynamicStructuresTasks()
        {
            Console.WriteLine("Выберите задание динамических структур данных:");
            Console.WriteLine("1. Пример использования структуры данных Список");
            Console.WriteLine("2. Пример использования структуры данных Стек");
            Console.WriteLine("3. Пример использования структуры данных Очередь");
            Console.WriteLine("4. Пример использования структуры данных Дерево");

            int choice = int.Parse(Console.ReadLine());

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
                    Console.WriteLine("Неверный выбор");
                    break;
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

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Реализация задания 1 для листа
                    break;
                case 2:
                    // Реализация задания 2 для листа
                    break;
                case 3:
                    // Реализация задания 3 для листа
                    break;
                case 4:
                    // Реализация задания 4 для листа
                    break;
                case 5:
                    // Реализация задания 5 для листа
                    break;
                case 6:
                    // Реализация задания 6 для листа
                    break;
                case 7:
                    // Реализация задания 7 для листа
                    break;
                case 8:
                    // Реализация задания 8 для листа
                    break;
                case 9:
                    // Реализация задания 9 для листа
                    break;
                case 10:
                    // Реализация задания 10 для листа
                    break;
                case 11:
                    // Реализация задания 11 для листа
                    break;
                case 12:
                    // Реализация задания 12 для листа
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }

}