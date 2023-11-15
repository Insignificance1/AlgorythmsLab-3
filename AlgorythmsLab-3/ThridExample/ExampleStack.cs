using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsLab_3
{
    public class ExampleStack
    {
        static bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> brackets = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

            foreach (char c in expression)
            {
                if (brackets.ContainsKey(c))  // Если это открывающая скобка
                {
                    stack.Push(c);
                }
                else if (brackets.ContainsValue(c))  // Если это закрывающая скобка
                {
                    if (stack.Count == 0 || brackets[stack.Pop()] != c)
                    {
                        return false;
                    }
                }
            }

            // Если стек не пуст, то есть есть непарные открывающие скобки
            return stack.Count == 0;
        }

        public static void ExcuiteStack()
        {
            Console.WriteLine("Введите математическое выражение: ");
            string formula = Console.ReadLine();

            if (IsBalanced(formula) == true)
            {
                Console.WriteLine($"{formula} - Выражение верно!");
            }
            else if (IsBalanced(formula) == false) 
            {
                Console.WriteLine($"{formula} - Выражение неверно!");
            }

        }
    }

}

