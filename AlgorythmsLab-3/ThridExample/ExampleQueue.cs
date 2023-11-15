using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3
{
    class TaskManagementSystem
    {
        private Queue<Action> taskQueue;

        public TaskManagementSystem()
        {
            taskQueue = new Queue<Action>(); // Инициализируем taskQueue
        }

        public void EnqueueTask(Action task)
        {
            taskQueue.Enqueue(task);
            Console.WriteLine("Задача поставлена ​​в очередь.");
        }

        public void ProcessTasks()
        {
            while (taskQueue.Count > 0)
            {
                Action currentTask = taskQueue.Dequeue();
                Console.Write("Задача в обработке... ");
                currentTask.Invoke();
            }

            Console.WriteLine("Все задачи обработаны.");
        }

        public static void QueueSource()
        {
            TaskManagementSystem taskSystem = new TaskManagementSystem();

            Console.Write("Введите количество задач: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfTasks))
            {
                Console.WriteLine("Введите задачи (нажимайте Enter после каждой задачи):");

                for (int i = 0; i < numberOfTasks; i++)
                {
                    Console.Write($"Задача {i + 1}: ");
                    string taskDescription = Console.ReadLine();

                    taskSystem.EnqueueTask(() => Console.WriteLine($"Задача: {taskDescription}"));
                }

                taskSystem.ProcessTasks();
            }
            else
            {
                Console.WriteLine("Неверный ввод. Введите допустимое количество задач.");
            }
        }
    }
}



