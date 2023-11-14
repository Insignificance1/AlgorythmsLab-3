using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3.Stack
{
    class CustomStack<T>
    {
        private Node<T> top;

        private LinkedList<T> items;

        public CustomStack()
        {
            top = null;
            items = new LinkedList<T>();
        }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);
            newNode.Next = top;
            top = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                return default;
            }

            T data = top.Data;
            top = top.Next;

            return data;
        }


        public T Top()
        {
            if (IsEmpty())
            {
                return default;
            }

            return top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public void Print(bool printToConsole = true)
        {
            Node<T> current = top;
            if (IsEmpty())
            {
                if (printToConsole)
                {
                    Console.WriteLine("Print: Стек пуст.");
                }
                return;
            }
            if (printToConsole)
            {
                Console.Write("Print: ");
            }
            while (current != null)
            {
                if (printToConsole)
                {
                    Console.Write($"{current.Data} ");
                }
                current = current.Next;
            }
            if (printToConsole)
            {
                Console.WriteLine();
            }
        }
    }

}
