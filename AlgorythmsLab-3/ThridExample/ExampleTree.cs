using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3
{
    public class BinarySearchTree
    {
        class Node
        {
            public int Data;
            public Node Left, Right;

            public Node(int item)
            {
                Data = item;
                Left = Right = null;
            }
        }

        
            private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        // Метод для вставки значения в дерево
        private Node Insert(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.Data)
                root.Left = Insert(root.Left, data);
            else if (data > root.Data)
                root.Right = Insert(root.Right, data);

            return root;
        }

        public void Insert(int data)
        {
            root = Insert(root, data);
        }

        // Метод для поиска значения в дереве
        private bool Search(Node root, int data)
        {
            if (root == null)
                return false;

            if (data == root.Data)
                return true;

            if (data < root.Data)
                return Search(root.Left, data);

            return Search(root.Right, data);
        }

        public bool Search(int data)
        {
            return Search(root, data);
        }

        // Обход дерева в порядке "возрастания"
        private void InOrderTraversal(Node root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Data + " ");
                InOrderTraversal(root.Right);
            }
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
            Console.WriteLine();
        }
        

        
        
        public static void ExampleTree()
        {
            BinarySearchTree tree = new BinarySearchTree();

            // Вставка значений в дерево
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(70);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(60);
            tree.Insert(80);

            // Поиск значения в дереве
            Console.Write("Введите число для поиска: ");
            if (int.TryParse(Console.ReadLine(), out int valueToSearch))
            {
                if (tree.Search(valueToSearch))
                    Console.WriteLine($"Значение {valueToSearch} найдено в дереве.");
                else
                    Console.WriteLine($"Значение {valueToSearch} не найдено в дереве.");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }

            // Обход дерева в порядке "возрастания"
            Console.WriteLine("Обход дерева в порядке возрастания:");
            tree.InOrderTraversal();
        }
        

    }
}
