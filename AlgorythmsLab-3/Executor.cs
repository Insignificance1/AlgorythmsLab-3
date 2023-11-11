using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgorythmsLab_3
{
    class Executor
    {
        public static void ExecuteStackOperations() //Задание 1.2 
        {
            for (int run = 1; run <= 100; run++)
            {
                Console.WriteLine($"Номер прохода: {run}:");
                Generate.GenerateInputFile();

                CustomStack<object> stack = new CustomStack<object>();

                try
                {
                    string[] operations = File.ReadAllText("input.txt").Split(' ');

                    for (int i = 0; i < operations.Length - 1; i++)
                    {
                        int op = int.Parse(operations[i]);

                        switch (op)
                        {
                            case 1:
                                // Push
                                if (i + 1 < operations.Length)
                                {
                                    object element = operations[i + 1];
                                    stack.Push(element);
                                    Console.WriteLine($"Push: {element}");
                                    i++;
                                }
                                else
                                {
                                    Console.WriteLine("Push: Недостаточно аргументов для операции.");
                                }
                                break;
                            case 2:
                                // Pop
                                if (!stack.IsEmpty())
                                {
                                    object poppedItem = stack.Pop();
                                    Console.WriteLine($"Pop: {poppedItem}");
                                }
                                else
                                {
                                    Console.WriteLine("Pop: Стек пуст. Невозможно выполнить операцию Pop.");
                                }
                                break;
                            case 3:
                                // Top
                                Console.WriteLine($"Top: {stack.Top()}");
                                break;
                            case 4:
                                // isEmpty
                                Console.WriteLine($"isEmpty: {stack.IsEmpty()}");
                                break;
                            case 5:
                                // Print
                                stack.Print();
                                break;
                            default:
                                Console.WriteLine("Неверная операция");
                                break;
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл input.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
            MenuManager.ReturnToMainMenu();
        }
        public static void ExecuteStackOperationsFromFile()  // Задание 1.3
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "CustomStack - График выполнения операци.xlsx");
            string chartName = "CustomStack - График выполнения операци";

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();

            for (int size = 10; size <= 1000; size += 10)
            {
                Console.WriteLine($"Размер стека: {size}");

                Generate.GenerateInputStackFile(size);

                CustomStack<object> stack = new CustomStack<object>();
                OperationTimer timer = new OperationTimer();
                timer.Start();

                try
                {
                    string[] operations = File.ReadAllText("inputStack.txt").Split(' ');

                    for (int i = 0; i < operations.Length - 1; i++)
                    {
                        int op = int.Parse(operations[i]);

                        switch (op)
                        {
                            case 1:
                                if (i + 1 < operations.Length)
                                {
                                    i++;
                                    object element = operations[i];
                                    stack.Push(element);
                                }
                                break;

                            case 2:
                                object poppedItem = stack.Pop();
                                break;

                            case 3:
                                object topItem = stack.Top();
                                break;

                            case 4:
                                bool isEmpty = stack.IsEmpty();
                                break;

                            case 5:
                                stack.Print(false);
                                break;

                            default:
                                Console.WriteLine("Неверная операция");
                                break;
                        }
                    }

                    TimeSpan elapsedTotal = timer.Stop();
                    results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл inputStack.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
            }

            ExcelWriter.WriteToExcel(results, outputFilePath, chartName);
            MenuManager.ReturnToMainMenu();
        }
        public static void ExecutePostfixCalculation() // Задание 1.4
        {
            Console.WriteLine("Задание 1.4 - Вычисление в постфиксной записи");
            Console.WriteLine("Введите выражение для вычисления:");

            string expression = Console.ReadLine();

            while (!IsPostfixExpressionValid(expression))
            {
                Console.WriteLine("Выражение введено неверно. Пожалуйста, повторите ввод:");
                expression = Console.ReadLine();
            }

            try
            {
                double result = PostfixCalculator.PostfixCalculate(expression);
                Console.WriteLine($"Выражение: {expression} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вычислении выражения: {ex.Message}");
            }
            MenuManager.ReturnToMainMenu();
        }

        private static bool IsPostfixExpressionValid(string expression)
        {
            expression = expression.Replace(" ", "");
            if (string.IsNullOrWhiteSpace(expression))
            {
                return false;
            }

            if (expression.Length < 3)
            {
                return false;
            }

            bool hasOperand = false;
            bool hasOperation = false;

            foreach (char ch in expression)
            {
                if (char.IsDigit(ch))
                {
                    hasOperand = true;
                }
                else if (IsOperator(ch))
                {
                    hasOperation = true;
                }

                if (hasOperand && hasOperation)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsOperator(char ch)
        {
            return "+-*/^".Contains(ch);
        }

        public static void ExecuteInfixToPostfixTask() // Задание 1.5
        {
            Console.WriteLine("Задание 1.5 - Перевод из инфиксной в постфиксную запись");
            Console.WriteLine("Введите инфиксное выражение:");

            string infixExpression = Console.ReadLine();

            try
            {
                string postfixExpression = InfixToPostfixConverter.ConvertToPostfix(infixExpression);
                Console.WriteLine("");
                Console.WriteLine($"Постфиксное: {postfixExpression}");

                double result = PostfixCalculator.PostfixCalculate(postfixExpression);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            MenuManager.ReturnToMainMenu();
        }

        public static void ExecuteStackOperationsWithBuiltInStack() // Задание 1.6
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "Stack - График выполнения операци.xlsx");
            string chartName = "Stack - График выполнения операци";

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();

            for (int size = 10; size <= 1000; size += 10)
            {
                Console.WriteLine($"Размер стека: {size}");

                Generate.GenerateInputStackFile(size);
                Stack<object> stack = new Stack<object>();
                OperationTimer timer = new OperationTimer();
                timer.Start();

                try
                {
                    string[] operations = File.ReadAllText("inputStack.txt").Split(' ');

                    for (int i = 0; i < operations.Length - 1; i++)
                    {
                        int op = int.Parse(operations[i]);

                        switch (op)
                        {
                            case 1:
                                if (i + 1 < operations.Length)
                                {
                                    i++;
                                    object element = operations[i];
                                    stack.Push(element);
                                }
                                break;

                            case 2:
                                if (stack.Count > 0)
                                {
                                    object poppedItem = stack.Pop();
                                }
                                break;

                            case 3:
                                if (stack.Count > 0)
                                {
                                    object topItem = stack.Peek();
                                }
                                break;

                            case 4:
                                bool isEmpty = stack.Count == 0;
                                break;

                            case 5:
                                // Встроенный Stack не предоставляет метода Print, поэтому используем цикл для вывода
                                foreach (var item in stack)
                                {
                                }

                                break;

                            default:
                                Console.WriteLine("Неверная операция");
                                break;
                        }
                    }

                    TimeSpan elapsedTotal = timer.Stop();
                    results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл inputStack.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
            }

            ExcelWriter.WriteToExcel(results, outputFilePath, chartName);
            MenuManager.ReturnToMainMenu();
        }

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
                MenuManager.ReturnToMainMenu();
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
                MenuManager.ReturnToMainMenu();
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
                MenuManager.ReturnToMainMenu();
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
                MenuManager.ReturnToMainMenu();
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
                MenuManager.ReturnToMainMenu();
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
                MenuManager.ReturnToMainMenu();
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
                MenuManager.ReturnToMainMenu();
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
                MenuManager.ReturnToMainMenu();
            }
        }

    }
}



