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
    public void RemoveAllOccurrences(T element) // Задание 4.7
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

    public void InsertBeforeFirstOccurrence(T existingElement, T newElement) // Задание 4.8
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

    public void AppendList(CustomLinkedList<T> listToAppend) // Задание 4.9
    {
        // Проверяем, не является ли список, который мы добавляем, пустым
        if (listToAppend.head == null)
        {
            Console.WriteLine("Список для добавления пуст. Ничего не добавлено.");
            return;
        }

        // Если наш список пуст, просто копируем в него список для добавления
        if (head == null)
        {
            CopyList(listToAppend);
            return;
        }

        // Находим последний элемент нашего списка
        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        // Копируем элементы из списка для добавления в конец нашего списка
        CopyList(listToAppend, current);
    }

    private void CopyList(CustomLinkedList<T> source, Node destination)
    {
        Node current = source.head;

        while (current != null)
        {
            Node newNode = new Node(current.Data);
            destination.Next = newNode;
            destination = newNode;
            current = current.Next;
        }
    }

    private void CopyList(CustomLinkedList<T> source)
    {
        Node current = source.head;

        while (current != null)
        {
            AddToFront(current.Data);
            current = current.Next;
        }
    }

    public void SplitList(T number, out CustomLinkedList<T> secondList) // Задание 4.10
    {
        secondList = new CustomLinkedList<T>();

        if (head == null)
        {
            // Список пуст, второй список остается пустым, первый не изменяется
            return;
        }

        Node current = head;
        Node previous = null;

        // Ищем первое вхождение числа в списке
        while (current != null && !EqualityComparer<T>.Default.Equals(current.Data, number))
        {
            previous = current;
            current = current.Next;
        }

        if (current == null)
        {
            // Число не найдено в списке, второй список остается пустым, первый не изменяется
            return;
        }

        // Разрываем связь между первым и вторым списком
        if (previous != null)
        {
            previous.Next = null;
        }
        else
        {
            // Если первый элемент - искомое число, то обнуляем голову
            head = null;
        }

        // Заполняем второй список начиная с найденного числа
        secondList.head = current;

        // Первый список остается без изменений
    }
    public void DuplicateList() // Задание 4.11
    {
        if (head == null)
        {
            // Нечего удваивать, список пуст
            return;
        }

        // Копируем текущий список
        CustomLinkedList<T> copy = CopyList();
        copy.Reverse();

        // Ищем конец текущего списка
        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        // Добавляем к текущему списку копию списка
        current.Next = copy.head;
    } 
    public void SwapElements(T element1, T element2) // Задание 4.12
    {
        // Проверка наличия обоих элементов в списке
        if (!Contains(element1) || !Contains(element2))
        {
            Console.WriteLine("Один из элементов отсутствует в списке. Невозможно выполнить обмен.");
            return;
        }

        // Если элементы равны, обмена не требуется
        if (EqualityComparer<T>.Default.Equals(element1, element2))
        {
            Console.WriteLine("Оба элемента одинаковы. Обмен не требуется.");
            return;
        }

        // Ищем узлы, содержащие элементы
        Node prev1 = null, current1 = head;
        Node prev2 = null, current2 = head;

        while (current1 != null && !EqualityComparer<T>.Default.Equals(current1.Data, element1))
        {
            prev1 = current1;
            current1 = current1.Next;
        }

        while (current2 != null && !EqualityComparer<T>.Default.Equals(current2.Data, element2))
        {
            prev2 = current2;
            current2 = current2.Next;
        }

        // Если один из элементов находится в начале списка
        if (prev1 == null)
        {
            head = current2;
        }
        else
        {
            prev1.Next = current2;
        }

        if (prev2 == null)
        {
            head = current1;
        }
        else
        {
            prev2.Next = current1;
        }

        // Обмениваем ссылки Next
        Node temp = current1.Next;
        current1.Next = current2.Next;
        current2.Next = temp;
    }
    public bool Contains(T data)
    {
        Node current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
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