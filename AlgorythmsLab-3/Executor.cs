﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


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
                    // Чтение операций из файла и выполнение
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
            string outputFilePath = Path.Combine(desktopPath, "Стек(замер).xlsx");

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

            // Передача результатов в ExcelWriter
            ExcelWriter.WriteToExcel(results, outputFilePath);
            MenuManager.ReturnToMainMenu();
        }
    }

}



