using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите номер задания:");
        Console.WriteLine("1. Стек");
        Console.WriteLine("2. Очередь");
        Console.WriteLine("3. Динамические структуры");
        Console.WriteLine("4. Лист");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                RunPart1();
                break;
            case 2:
                RunPart2();
                break;
            case 3:
                RunPart3();
                break;
            case 4:
                RunPart4();
                break;
            default:
                Console.WriteLine("Неверный выбор");
                break;
        }
    }

    static void RunPart1()
    {
        Console.WriteLine("Выполняется Стек");
        // Ваш код для части 1
    }

    static void RunPart2()
    {
        Console.WriteLine("Выполняется Очередь");
        // Ваш код для части 2
    }

    static void RunPart3()
    {
        Console.WriteLine("Выполняется Динамические структуры");
        // Ваш код для части 3
    }

    static void RunPart4()
    {
        Console.WriteLine("Выполняется Лист");
        // Ваш код для части 4
    }
}
