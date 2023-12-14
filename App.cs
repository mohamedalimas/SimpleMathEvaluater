using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluater
{
    internal class App
    {
        internal static void Run(string[] args)
        {
            while (true) {
                Console.WriteLine(">>");
                string input = Console.ReadLine();
                MathExpression expression = ExpressionParser.Parse(input.Trim().ToLower());
                Console.WriteLine($"Left hand value {expression.leftOperand} ,Operation => {expression.operation}, Right hand value {expression.rightOperand}");
                Console.WriteLine($"{input} = {evaluate(expression)}");
            }
        }

        private static double evaluate(MathExpression expression)
        {
            switch (expression.operation)
            {
                case MathOperation.Add:
                    return expression.leftOperand + expression.rightOperand;
                case MathOperation.Subtract:
                    return expression.leftOperand - expression.rightOperand;    
                case MathOperation.Multiply:
                    return expression.leftOperand * expression.rightOperand;
                case MathOperation.Divide:
                    return expression.leftOperand / expression.rightOperand;
                case MathOperation.Modulus:
                    return expression.leftOperand % expression.rightOperand;
                case MathOperation.Power:
                    return Math.Pow(expression.leftOperand, expression.rightOperand);
                case MathOperation.Sin:
                    return expression.leftOperand*Math.Sin(expression.rightOperand);
                case MathOperation.Cos:
                    return expression.leftOperand * Math.Cos(expression.rightOperand);
                case MathOperation.Tan:
                    return expression.leftOperand * Math.Tan(expression.rightOperand);
                default: return expression.rightOperand;
            }
        }
    }
}
