using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3
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

        public int Size
        {
            get { return items.Count; }
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
                return default(T);
            }

            T data = top.Data;
            top = top.Next;

            return data;
        }


        public T Top()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            return top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public void Print(bool printToConsole = true)
        {
            if (IsEmpty())
            {
                if (printToConsole)
                {
                    Console.WriteLine("Print: Стек пуст.");
                }
                return;
            }

            Node<T> current = top;

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
