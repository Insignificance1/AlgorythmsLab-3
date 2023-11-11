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

        while (current.Next != null)
        {
            previous = current;
            current = current.Next;
        }

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
    public void PasteYourself(T elementInsert) // Задание 4.5
    {
        if (head == null)
        {
            AddToFront(elementInsert);
            return;
        }

        Node current = head;
        Node insertionPoint = null;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, elementInsert))
            {
                insertionPoint = current;
                break;
            }

            current = current.Next;
        }

        if (insertionPoint == null)
        {
            Console.WriteLine($"Элемент {elementInsert} не найден в списке. Ничего не вставлено.");
            return;
        }

        CustomLinkedList<T> insertionList = CopyList();
        insertionList.Reverse();

        Node temp = insertionPoint.Next;
        insertionPoint.Next = insertionList.head;

        Node insertionListEnd = insertionList.head;
        while (insertionListEnd.Next != null)
        {
            insertionListEnd = insertionListEnd.Next;
        }

        insertionListEnd.Next = temp;

    }


    private CustomLinkedList<T> CopyList()
    {
        CustomLinkedList<T> copy = new CustomLinkedList<T>();
        Node current = head;

        while (current != null)
        {
            copy.AddToFront(current.Data);
            current = current.Next;
        }

        return copy;
    }

    public void InsertOrdered(T element) // Задание 4.6
    {
        Node newNode = new Node(element);

        if (head == null || Comparer<T>.Default.Compare(element, head.Data) <= 0)
        {
            newNode.Next = head;
            head = newNode;
            return;
        }

        Node current = head;

        while (current.Next != null && Comparer<T>.Default.Compare(element, current.Next.Data) > 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }
    public void RemoveAllOccurrences(T element)
    {
        // Проверяем, не является ли список пустым
        if (head == null)
        {
            Console.WriteLine("Список пуст. Нечего удалять.");
            return;
        }

        // Удаляем все узлы с данным элементом, начиная с головы списка
        while (head != null && EqualityComparer<T>.Default.Equals(head.Data, element))
        {
            head = head.Next;
        }

        // Если после удаления головы список стал пустым, выходим из метода
        if (head == null)
        {
            return;
        }

        // Ищем и удаляем элементы в оставшейся части списка
        Node current = head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Data, element))
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }
    }

    public void InsertBeforeFirstOccurrence(T existingElement, T newElement)
    {
        // Проверяем, не является ли список пустым
        if (head == null)
        {
            Console.WriteLine("Список пуст. Невозможно вставить элемент.");
            return;
        }

        // Если голова списка содержит искомый элемент, вставляем новый элемент в начало
        if (EqualityComparer<T>.Default.Equals(head.Data, existingElement))
        {
            AddToFront(newElement);
            return;
        }

        // Ищем первое вхождение искомого элемента
        Node current = head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Data, existingElement))
            {
                // Вставляем новый элемент перед первым вхождением
                Node newNode = new Node(newElement);
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }

            current = current.Next;
        }

        // Если элемент не найден, выводим сообщение
        Console.WriteLine($"Элемент {existingElement} не найден в списке. Ничего не вставлено.");
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