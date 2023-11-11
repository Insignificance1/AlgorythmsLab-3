using AlgorythmsLab_3;
using System;
using System.Collections.Generic;

public class CustomLinkedList<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public CustomLinkedList()
    {
        head = null;
    }

    public void AddToFront(T data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
    }

    public void Reverse() // Задание 4.1
    {
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        head = prev;
    }
    public void MoveFirstAndLast()
    {
        if (head == null || head.Next == null)
        {
            Console.WriteLine("Список пуст или содержит только один элемент. Нечего перемещать.");
            return;
        }

        Node current = head;
        Node previous = null;

        // Проходим до конца списка
        while (current.Next != null)
        {
            previous = current;
            current = current.Next;
        }

        // Меняем местами первый и последний элементы
        current.Next = head.Next;
        head.Next = null;
        previous.Next = head;
        head = current;
    }


    public int CountDistinctElements() // Задание 4.3
    {
        HashSet<T> uniqueElements = new HashSet<T>();
        Node current = head;

        while (current != null)
        {
            uniqueElements.Add(current.Data);
            current = current.Next;
        }

        return uniqueElements.Count;
    }
    public void RemoveNonUniqueElements() // Задание 4.4
    {
        if (head == null)
        {
            Console.WriteLine("Список пуст. Нечего удалять.");
            return;
        }

        HashSet<T> uniqueElements = new HashSet<T>();
        Node current = head;
        Node previous = null;

        while (current != null)
        {
            if (uniqueElements.Contains(current.Data))
            {
                // Удаляем неуникальный элемент
                previous.Next = current.Next;
            }
            else
            {
                uniqueElements.Add(current.Data);
                previous = current;
            }

            current = current.Next;
        }
    }


    // Добавьте остальные методы для выполнения заданий
    // ...

    public void Print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write($"{current.Data} ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}