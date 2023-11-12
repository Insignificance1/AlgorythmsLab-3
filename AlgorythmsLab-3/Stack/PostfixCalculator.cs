using System;
using System.Linq;

namespace AlgorythmsLab_3.Stack
{
    public static class PostfixCalculator
    {
        public static double PostfixCalculate(string expression)
        {
            CustomStack<double> stack = new CustomStack<double>();

            string[] tokens = expression.Split(' ');
            double operand1 = 0;

            foreach (string token in tokens)
            {
                if (IsNumeric(token))
                {
                    stack.Push(double.Parse(token));
                }
                else if (IsOperator(token))
                {
                    double operand2 = stack.Pop();
                    if (!stack.IsEmpty())
                    {
                        operand1 = stack.Pop();
                    }
                    double result = PerformOperation(token, operand1, operand2);
                    stack.Push(result);
                }
                else
                {
                    throw new ArgumentException($"Некорректный токен в постфиксном выражении: {token}");
                }
            }

            return stack.Pop();
        }

        private static bool IsNumeric(string token)
        {
            return double.TryParse(token, out _);
        }

        private static bool IsOperator(string token)
        {
            string[] operators = { "+", "-", "*", "/", "^", "ln", "cos", "sin", "sqrt", "!" };
            return operators.Contains(token);
        }

        private static double PerformOperation(string operatorToken, double operand1, double operand2)
        {
            switch (operatorToken)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                case "^":
                    return Math.Pow(operand1, operand2);
                case "ln":
                    return Math.Log(operand2);
                case "cos":
                    return Math.Cos(DegreesToRadians(operand2));
                case "sin":
                    return Math.Sin(DegreesToRadians(operand2));
                case "sqrt":
                    return Math.Sqrt(operand2);
                default:
                    throw new ArgumentException($"Неизвестный оператор: {operatorToken}");
            }
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}