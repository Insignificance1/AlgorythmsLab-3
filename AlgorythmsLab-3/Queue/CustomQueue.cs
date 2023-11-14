using System;
using System.Collections.Generic;

public class CustomQueue<T>
{
    private LinkedList<T> list;

    public CustomQueue()
    {
        list = new LinkedList<T>();
    }
    public void Enqueue(T element)
    {
        list.AddLast(element);
    }
    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T value = list.First.Value;
        list.RemoveFirst();
        return value;
    }
    public bool IsEmpty()
    {
        return list.Count == 0;
    }
    public void Print()
    {
        foreach (T item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return list.First.Value;
    }
    public void Print(bool isExcel)
    {
        foreach (T item in list)
        {
        }
    }
}
