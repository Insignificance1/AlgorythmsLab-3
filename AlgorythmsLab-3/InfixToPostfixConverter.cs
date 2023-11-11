using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AlgorythmsLab_3
{
    public static class InfixToPostfixConverter
    {
        public static string ConvertToPostfix(string infixExpression)
        {
            CustomStack<string> operatorStack = new CustomStack<string>();

            // Используем StringBuilder для формирования выражения
            StringBuilder postfixExpression = new StringBuilder();

            // Разбиваем инфиксное выражение на токены
            string[] tokens = TokenizeInfixExpression(infixExpression);

            foreach (var token in tokens)
            {
                if (IsNumeric(token))
                {
                    // Если токен - операнд, добавляем его к постфиксному выражению
                    postfixExpression.Append($"{token} ");
                }
                else if (IsFunction(token))
                {
                    // Если токен - функция, помещаем ее в стек функций
                    operatorStack.Push(token);
                }
                else if (IsOperator(token))
                {
                    // Если токен - оператор, обрабатываем его приоритет
                    while (!operatorStack.IsEmpty() &&
                           (IsFunction(operatorStack.Top()) ||
                            GetOperatorPriority(operatorStack.Top()) >= GetOperatorPriority(token)))
                    {
                        postfixExpression.Append($"{operatorStack.Pop()} ");
                    }

                    operatorStack.Push(token);
                }
                else if (token == "(")
                {
                    // Если токен - открывающая скобка, помещаем ее в стек операторов
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    // Если токен - закрывающая скобка, выталкиваем все операторы и функции из стека до открывающей скобки
                    while (!operatorStack.IsEmpty() && operatorStack.Top() != "(")
                    {
                        postfixExpression.Append($"{operatorStack.Pop()} ");
                    }

                    // Если верхний элемент стека - функция, выталкиваем ее тоже
                    if (!operatorStack.IsEmpty() && IsFunction(operatorStack.Top()))
                    {
                        postfixExpression.Append($"{operatorStack.Pop()} ");
                    }

                    // Удаляем открывающую скобку из стека
                    operatorStack.Pop();
                }
            }

            // Выталкиваем оставшиеся операторы и функции из стека
            while (!operatorStack.IsEmpty())
            {
                postfixExpression.Append($"{operatorStack.Pop()} ");
            }

            return postfixExpression.ToString().Trim();
        }
        private static string[] TokenizeInfixExpression(string infixExpression)
        {
            // Используем регулярное выражение для токенизации
            // Здесь используется простой паттерн, подлежащий доработке в зависимости от требований
            string pattern = @"([\+\-\*/\^\(\)]|\b(?:sin|cos|ln|sqrt)\b|\d+)";
            return Regex.Matches(infixExpression, pattern)
                        .OfType<Match>()
                        .Select(match => match.Value)
                        .ToArray();
        }

        private static bool IsNumeric(string token)
        {
            return double.TryParse(token, out _);
        }

        private static bool IsFunction(string token)
        {
            // Ваша логика определения функций
            string[] functions = { "sin", "cos", "ln", "sqrt" };
            return functions.Contains(token);
        }

        private static bool IsOperator(string token)
        {
            // Ваша логика определения операторов
            string[] operators = { "+", "-", "*", "/", "^" };
            return operators.Contains(token);
        }

        private static int GetOperatorPriority(string op)
        {
            // Определение приоритета оператора
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                case "ln":
                case "cos":
                case "sin":
                case "sqrt":
                    return 4; // Установим более низкий приоритет для функций
                default:
                    return 0; // Для остальных операторов или операндов
            }
        }
    }
}
