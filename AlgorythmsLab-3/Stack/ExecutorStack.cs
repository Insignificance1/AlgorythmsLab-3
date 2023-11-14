using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorythmsLab_3.Utilities;

namespace AlgorythmsLab_3.Stack
{
    class ExecutorStack
    {
        public static void ExecuteStackOperations()
        {
            for (int size = 1; size <= 100; size++)
            {
                Console.WriteLine($"Номер прохода: {size}:");
                Generate.GenerateInputFile(size);

                CustomStack<object> stack = new CustomStack<object>();

                try
                {
                    string[] operations = File.ReadAllText("input.txt").Split(' ');

                    for (int i = 0; i < operations.Length - 1; i++)
                    {
                        int op = int.Parse(operations[i]);
                        ProcessOperation(op, stack, ref i, operations);
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
            MenuManager.ReturnToMainMenu("Stack");
        }

        private static void ProcessOperation(int op, CustomStack<object> stack, ref int i, string[] operations)
        {
            switch (op)
            {
                case 1:
                    if (i + 1 < operations.Length)
                    {
                        object element = operations[i + 1];
                        stack.Push(element);
                        Console.WriteLine($"Push: {element}");
                        i++;
                    }
                    else Console.WriteLine("Push: Недостаточно аргументов для операции.");
                    break;
                case 2:
                    if (!stack.IsEmpty())
                    {
                        object poppedItem = stack.Pop();
                        Console.WriteLine($"Pop: {poppedItem}");
                    }
                    else Console.WriteLine("Pop: Стек пуст. Невозможно выполнить операцию Pop.");
                    break;
                case 3:
                    Console.WriteLine($"Top: {stack.Top()}");
                    break;
                case 4:
                    Console.WriteLine($"isEmpty: {stack.IsEmpty()}");
                    break;
                case 5:
                    stack.Print();
                    break;
                default:
                    Console.WriteLine("Неверная операция");
                    break;
            }
        }
        public static void ExecuteStackOperationsFromFile()  // Задание 1.3
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "CustomStack - График выполнения операци.xlsx");
            string chartName = "CustomStack - График выполнения операци";

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();

            for (int size = 10; size <= 50000; size += 10)
            {
                Console.WriteLine($"Размер стека: {size}");

                Generate.GenerateInputStackFile(size);

                CustomStack<object> stack = new CustomStack<object>();
                OperationTimer timer = new OperationTimer();

                try
                {
                    timer.Start();
                    ProcessStackOperations(size, stack, results);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл inputStack.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
                TimeSpan elapsedTotal = timer.Stop();
                results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
            }

            ExcelWriter.WriteToExcel(results, outputFilePath, chartName);
            MenuManager.ReturnToMainMenu("Stack");
        }

        private static void ProcessStackOperations(int size, CustomStack<object> stack, List<Tuple<int, double>> results)
        {
            string[] operations = File.ReadAllText("inputStack.txt").Split(' ');

            for (int i = 0; i < operations.Length - 1; i++)
            {
                int op = int.Parse(operations[i]);
                PerformStackOperation(op, stack, ref i, operations);
            }
        }

        private static void PerformStackOperation(int op, CustomStack<object> stack, ref int i, string[] operations)
        {
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
                    stack.Pop();
                    break;

                case 3:
                    stack.Top();
                    break;

                case 4:
                    stack.IsEmpty();
                    break;

                case 5:
                    stack.Print(false);
                    break;

                default:
                    Console.WriteLine("Неверная операция");
                    break;
            }
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
            MenuManager.ReturnToMainMenu("Stack");
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
            MenuManager.ReturnToMainMenu("Stack");
        }

        public static void ExecuteStackOperationsWithBuiltInStack() // Задание 1.6
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "Stack - График выполнения операци.xlsx");
            string chartName = "Stack - График выполнения операци";

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();

            for (int size = 10; size <= 50000; size += 10)
            {
                Console.WriteLine($"Размер стека: {size}");

                Generate.GenerateInputStackFile(size);
                Stack<object> stack = new Stack<object>();
                OperationTimer timer = new OperationTimer();
                timer.Start();

                try
                {
                    ProcessStackOperations(size, stack, results);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл inputStack.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
                TimeSpan elapsedTotal = timer.Stop();
                results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
            }

            ExcelWriter.WriteToExcel(results, outputFilePath, chartName);
            MenuManager.ReturnToMainMenu("Stack");
        }

        private static void ProcessStackOperations(int size, Stack<object> stack, List<Tuple<int, double>> results)
        {
            string[] operations = File.ReadAllText("inputStack.txt").Split(' ');

            for (int i = 0; i < operations.Length - 1; i++)
            {
                int op = int.Parse(operations[i]);
                PerformStackOperation(op, stack, ref i, operations);
            }
        }

        private static void PerformStackOperation(int op, Stack<object> stack, ref int currentIndex, string[] operations)
        {
            switch (op)
            {
                case 1:
                    // Push
                    if (currentIndex + 1 < operations.Length)
                    {
                        currentIndex++;
                        object element = operations[currentIndex];
                        stack.Push(element);
                    }
                    break;
                case 2:
                    // Pop
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    break;
                case 3:
                    // Top
                    if (stack.Count > 0)
                    {
                        stack.Peek();
                    }
                    break;
                case 4:
                    // Встроенный Stack не предоставляет метода isEmpty, поэтому используем проверку
                    if (stack.Count == 0)
                    {
                        bool isEmpty = true;
                    }
                    break;
                case 5:
                    // Встроенный Stack не предоставляет метода Print, поэтому используем цикл
                    foreach (var item in stack)
                    {
                    }
                    break;
                default:
                    Console.WriteLine("Неверная операция");
                    break;
            }
        }



    }
}



