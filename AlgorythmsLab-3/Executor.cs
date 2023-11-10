using System;
using System.IO;
using System.Collections.Generic;
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
        }

    }
}

