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

        public CustomStack()
        {
            top = null;
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
                Console.WriteLine("Стек пуст. Невозможно выполнить операцию.");
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
                Console.WriteLine("Top: Стек пуст. Невозможно выполнить операцию.");
                return default(T);
            }

            return top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Print: Стек пуст.");
                return;
            }

            Node<T> current = top;
            Console.Write("Print: ");
            while (current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

}
