using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorythmsLab_3.Utilities;

namespace AlgorythmsLab_3.List
{
    public class ExecutorList
    {
        public static void ReverseLinkedList() // Задание 4.1
        {
            Console.WriteLine("Задание 4.1 - Функция, которая переворачивает список L.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(10);

                Console.WriteLine("Исходный список:");
                myList.Print();

                myList.Reverse();

                Console.WriteLine("Перевернутый список:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void MoveLastToFrontToLast() // Задание 4.2
        {
            Console.WriteLine("Задание 4.2 - Функция, меняет местами первый и последний элемент.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(5);

                Console.WriteLine("Исходный список:");
                myList.Print();

                myList.MoveFirstAndLast();

                Console.WriteLine("Список после перемещения первого и последнего элементов:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void DistinctElementsCount() //Задание 4.3
        {
            Console.WriteLine("Задание 4.3 - Функция, которая определяет количество различных элементов списка.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(10);

                Console.WriteLine("Исходный список:");
                myList.Print();

                int distinctCount = myList.CountDistinctElements();

                Console.WriteLine($"Количество различных элементов в списке: {distinctCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }

        public static void RemoveNonUniqueElements() // Задание 4.4
        {
            Console.WriteLine("Задание 4.3 - Функция, которая удаляет из списка неуникальные элементы.");

            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(40);

                Console.WriteLine("Исходный список:");
                myList.Print();

                myList.RemoveNonUniqueElements();

                Console.WriteLine("Список после удаления неуникальных элементов:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void InsertYourself() // Задание 4.5
        {
            Console.WriteLine("Задание 4.5 - Вставка списка самого в себя вслед за первым вхождением числа x.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(10);

                Console.WriteLine("Исходный список:");
                myList.Print();

                Console.Write("Введите число x: ");
                int x = int.Parse(Console.ReadLine());

                myList.PasteYourself(x);

                Console.WriteLine($"Список после вставки самого себя после первого вхождения числа {x}:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void InsertOrdered() // Задание 4.6
        {
            Console.WriteLine("Задание 4.6 - Вставка в упорядоченный список с сохранением порядка.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomSortedLinkedList(10);

                Console.WriteLine("Исходный упорядоченный список:");
                myList.Print();

                Console.Write("Введите элемент для вставки: ");
                int element = int.Parse(Console.ReadLine());

                myList.InsertOrdered(element);

                Console.WriteLine($"Список после вставки элемента {element} с сохранением порядка:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void RemoveAllOccurrences() // Задание 4.7
        {
            Console.WriteLine("Задание 4.7 - Удаление всех элементов равных заданному.");

            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLowValuesLinkedList(50);

                Console.WriteLine("Исходный список:");
                myList.Print();

                Console.Write("Введите элемент для удаления: ");
                int element = int.Parse(Console.ReadLine());

                myList.RemoveAllOccurrences(element);

                Console.WriteLine($"Список после удаления всех вхождений элемента {element}:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void InsertBeforeFirstOccurrence() // Задание 4.8
        {
            Console.WriteLine("Задание 4.8 - Вставка элемента перед первым вхождением другого элемента.");

            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(30);

                Console.WriteLine("Исходный список:");
                myList.Print();

                Console.Write("Введите элемент, перед которым нужно вставить новый элемент: ");
                int existingElement = int.Parse(Console.ReadLine());

                Console.Write("Введите новый элемент: ");
                int newElement = int.Parse(Console.ReadLine());

                myList.InsertBeforeFirstOccurrence(existingElement, newElement);

                Console.WriteLine($"Список после вставки элемента {newElement} перед первым вхождением элемента {existingElement}:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void AppendList() // Задание 4.9
        {
            Console.WriteLine("Задание 4.9 - Дописывание списка к текущему.");

            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(10);
                CustomLinkedList<int> listToAppend = Generate.GenerateRandomLinkedList(10);

                Console.WriteLine("Исходный список:");
                myList.Print();

                Console.WriteLine("Список для добавления:");
                listToAppend.Print();

                myList.AppendList(listToAppend);

                Console.WriteLine("Список после дописывания:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void SplitListExample() // Задание 4.10
        {
            Console.WriteLine("Задание 4.10 - Разбиение списка на два по первому вхождению числа.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(40);

                Console.WriteLine("Исходный список:");
                myList.Print();

                Console.Write("Введите число для разбиения списка: ");
                int number = int.Parse(Console.ReadLine());

                CustomLinkedList<int> secondList;
                myList.SplitList(number, out secondList);

                Console.WriteLine($"Первый список после разбиения:");
                myList.Print();

                Console.WriteLine($"Второй список после разбиения:");
                secondList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void DuplicateListExample() // Задание 4.11
        {
            Console.WriteLine("Задание 4.11 - Удвоение списка.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(10);

                Console.WriteLine("Исходный список:");
                myList.Print();

                myList.DuplicateList();

                Console.WriteLine("Список после удвоения:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
        public static void SwapElementsExample() // Задание 4.12
        {
            Console.WriteLine("Задание 4.12 - Обмен местами двух элементов.");
            try
            {
                CustomLinkedList<int> myList = Generate.GenerateRandomLinkedList(30);

                Console.WriteLine("Исходный список:");
                myList.Print();

                Console.Write("Введите первый элемент для обмена: ");
                int element1 = int.Parse(Console.ReadLine());

                Console.Write("Введите второй элемент для обмена: ");
                int element2 = int.Parse(Console.ReadLine());

                myList.SwapElements(element1, element2);

                Console.WriteLine("Список после обмена элементов:");
                myList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                MenuManager.ReturnToMainMenu("List");
            }
        }
    }
}
