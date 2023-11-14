using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AlgorythmsLab_3.Stack
{
    public static class InfixToPostfixConverter
    {
        public static string ConvertToPostfix(string infixExpression)
        {
            CustomStack<string> operatorStack = new CustomStack<string>();
            StringBuilder postfixExpression = new StringBuilder();
            string[] tokens = TokenizeInfixExpression(infixExpression);
            foreach (var token in tokens)
            {
                if (IsNumeric(token))
                {
                    postfixExpression.Append($"{token} ");
                }
                else if (IsFunction(token))
                {
                    operatorStack.Push(token);
                }
                else if (IsOperator(token))
                {
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
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (!operatorStack.IsEmpty() && operatorStack.Top() != "(")
                    {
                        postfixExpression.Append($"{operatorStack.Pop()} ");
                    }
                    if (!operatorStack.IsEmpty() && IsFunction(operatorStack.Top()))
                    {
                        postfixExpression.Append($"{operatorStack.Pop()} ");
                    }
                    operatorStack.Pop();
                }
            }
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
            string[] functions = { "sin", "cos", "ln", "sqrt" };
            return functions.Contains(token);
        }

        private static bool IsOperator(string token)
        {
            string[] operators = { "+", "-", "*", "/", "^" };
            return operators.Contains(token);
        }

        private static int GetOperatorPriority(string op)
        {
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
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
