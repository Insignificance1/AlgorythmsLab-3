using AlgorythmsLab_3.Utilities;
using Eco.Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3.Queue
{
    public class ExecutorQueue
    {
        public static void ExecuteQueueOperations()
        {
            for (int size = 1; size <= 100; size++)
            {
                Console.WriteLine($"Номер прохода: {size}:");

                Generate.GenerateInputFile(size);

                CustomQueue<string> queue = new CustomQueue<string>();

                try
                {
                    string[] operations = File.ReadAllText("input.txt").Split(' ');

                    for (int i = 0; i < operations.Length - 1; i++)
                    {
                        int op = int.Parse(operations[i]);
                        ProcessQueueOperation(op, i, operations, queue);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл queue_input.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
            MenuManager.ReturnToMainMenu("Queue");
        }

        private static void ProcessQueueOperation(int op, int i, string[] operations, CustomQueue<string> queue)
        {
            switch (op)
            {
                case 1:
                    if (i + 1 < operations.Length)
                    {
                        string element = operations[i + 1];
                        queue.Enqueue(element);
                        Console.WriteLine($"Enqueue: {element}");
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Enqueue: Недостаточно аргументов для операции.");
                    }
                    break;
                case 2:
                    try
                    {
                        string dequeuedItem = queue.Dequeue();
                        Console.WriteLine($"Dequeue: {dequeuedItem}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Dequeue: {ex.Message}");
                    }
                    break;
                case 3:
                    try
                    {
                        string peekedItem = queue.Peek();
                        Console.WriteLine($"Peek: {peekedItem}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Peek: {ex.Message}");
                    }
                    break;
                case 4:
                    Console.WriteLine($"IsEmpty: {queue.IsEmpty()}");
                    break;
                case 5:
                    if (queue.IsEmpty())
                    {
                        Console.WriteLine("Print: Queue is Empty.");
                        break;
                    }
                    queue.Print();
                    break;
                default:
                    Console.WriteLine("Неверная операция");
                    break;
            }
        }

        public static void ExecuteQueueOperationsWithSameLenghtFile() // Задание 2.3
        {
            // Одинаковый по длине, случайный по операциям
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "CustomQueue_SameLenght - График выполнения операци.xlsx");
            string chartName = "CustomQueue_SameLenght - График выполнения операций";
            int isSameLenght = 1;

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();
            ExecuteQueueOperations(results, "inputQueueSameLenght.txt", isSameLenght);

            ExcelWriter.WriteToExcel(results, outputFilePath, chartName);

            Console.WriteLine();
            MenuManager.ReturnToMainMenu("Queue");
        }
        public static void ExecuteQueueOperationsWithFile() // Задание 2.3
        {
            // Прогрессирующий по длине, случайный по операциям
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "CustomQueue - График выполнения операци.xlsx");
            string chartName = "CustomQueue - График выполнения операций";
            int isChoose = 2;

            List<Tuple<int, double>> resultsDifferent = new List<Tuple<int, double>>();
            ExecuteQueueOperations(resultsDifferent, "inputQueue.txt", isChoose);

            ExcelWriter.WriteToExcel(resultsDifferent, outputFilePath, chartName);

            Console.WriteLine();
            MenuManager.ReturnToMainMenu("Queue");
        }

        private static void ExecuteQueueOperations(List<Tuple<int, double>> results, string fileName, int chooseFile)
        {
            bool isExcel = true;

            for (int size = 10; size <= 10000; size += 10)
            {
                Console.WriteLine($"Номер прохода: {size}:");

                try
                {
                    if (chooseFile == 1)
                    {
                        Generate.GenerateInputQueueDifferentFile();
                    }
                    else if (chooseFile == 2)
                    {
                        Generate.GenerateInputQueueFile(size);
                    }

                    CustomQueue<string> queue = new CustomQueue<string>();
                    OperationTimer timer = new OperationTimer();
                    timer.Start();

                    ProcessQueueOperations(queue, fileName, isExcel);

                    TimeSpan elapsedTotal = timer.Stop();
                    results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Файл {fileName} не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
            }
        }

        private static void ProcessQueueOperations(CustomQueue<string> queue, string fileName, bool isExcel)
        {
            string[] operations = File.ReadAllText(fileName).Split(' ');

            for (int i = 0; i < operations.Length - 1; i++)
            {
                int op = int.Parse(operations[i]);

                switch (op)
                {
                    case 1:
                        // Enqueue
                        if (i + 1 < operations.Length)
                        {
                            string element = operations[i + 1];
                            queue.Enqueue(element);
                            i++;
                        }
                        break;
                    case 2:
                        // Dequeue
                        try
                        {
                            string dequeuedItem = queue.Dequeue();
                        }
                        catch (InvalidOperationException) { }
                        break;
                    case 3:
                        // Peek
                        try
                        {
                            string peekedItem = queue.Peek();
                        }
                        catch (InvalidOperationException) { }
                        break;
                    case 4:
                        // IsEmpty
                        bool isEmpty = queue.IsEmpty();
                        break;
                    case 5:
                        // Print
                        queue.Print(isExcel);
                        break;
                    default:
                        Console.WriteLine("Неверная операция");
                        break;
                }
            }
        }
        public static void ExecuteQueueOperationsWithQueue() // Задание 2.4
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFilePath = Path.Combine(desktopPath, "Queue - График выполнения операций.xlsx");
            string chartName = "Queue - График выполнения операций";

            List<Tuple<int, double>> results = new List<Tuple<int, double>>();

            for (int size = 10; size <= 10000; size += 10)
            {
                Console.WriteLine($"Номер прохода: {size}");

                try
                {
                    Generate.GenerateInputQueueFile(size);

                    Queue<object> queue = new Queue<object>();
                    OperationTimer timer = new OperationTimer();
                    timer.Start();

                    ProcessQueueOperationsWithQueue(queue);

                    TimeSpan elapsedTotal = timer.Stop();
                    results.Add(new Tuple<int, double>(size, elapsedTotal.TotalMilliseconds));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл inputQueue.txt не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка выполнения операций: {ex.Message}");
                }
            }

            ExcelWriter.WriteToExcel(results, outputFilePath, chartName);
            MenuManager.ReturnToMainMenu("Queue");
        }

        private static void ProcessQueueOperationsWithQueue(Queue<object> queue)
        {
            string[] operations = File.ReadAllText("inputQueue.txt").Split(' ');

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
                            queue.Enqueue(element);
                        }
                        break;
                    case 2:
                        if (queue.Count > 0)
                        {
                            object dequeuedItem = queue.Dequeue();
                        }
                        break;
                    case 3:
                        if (queue.Count > 0)
                        {
                            object peekedItem = queue.Peek();
                        }
                        break;
                    case 4:
                        if (queue.Count == 0)
                        {
                            bool isEmpty = true;
                        }
                        break;
                    case 5:
                        // Print не применим, так как у Queue нет операции для вывода всего содержимого, поэтому используем цикл
                        foreach (var item in queue) { }
                        break;
                    default:
                        Console.WriteLine("Неверная операция");
                        break;
                }
            }
        }

    }

}
