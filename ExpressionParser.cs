using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluater
{
    internal static class ExpressionParser
    {
        internal static MathExpression Parse(String input)
        {
            MathExpression expression = new MathExpression();
            bool isLeftOperandFilled = false;
            bool isOperationSelected = false;
            const string sympols = "+*/%^";
            StringBuilder token = new StringBuilder();

            for (int i = 0;i<input.Length;i++)
            {
                char currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    if (i!=0&&char.IsLetter(input[i - 1]) && !isOperationSelected)
                    {
                        expression.operation = Operation(token.ToString());
                        isOperationSelected = true;
                        token.Clear();
                    }
                    token.Append(currentChar); 
                    if (i == input.Length - 1)
                    {
                        expression.rightOperand = double.Parse(token.ToString());
                        break;
                    }
                }
                else if (sympols.Contains(currentChar))
                {
                    expression.leftOperand = double.Parse(token.ToString());
                    isLeftOperandFilled = true;
                    token.Clear();
                    expression.operation = Operation(currentChar.ToString());
                    isOperationSelected = true;
                }
                else if (currentChar == '-')
                {
                    if (i==0)
                    {
                        token.Append(currentChar);
                    }
                    else
                    {
                        if (!isOperationSelected)
                        {
                            expression.operation = Operation("-");
                            isOperationSelected = true;
                            expression.leftOperand = double.Parse(token.ToString());
                            isLeftOperandFilled = true;
                            token.Clear();
                        }
                        else
                            token.Append(currentChar);
                    }
                }
                else if (char.IsLetter(currentChar))
                {
                    if (!isLeftOperandFilled)
                    {
                        expression.leftOperand = token.ToString() =="" ? 0 : token.ToString() == "-" ? -1 : double.Parse(token.ToString());
                        isLeftOperandFilled = true;
                        token.Clear();
                        token.Append(currentChar);
                    }
                    else
                    {
                        token.Append(currentChar);
                    }
                }
                else if (currentChar ==' ')
                {
                    if (isLeftOperandFilled && !isOperationSelected)
                    {
                        expression.operation = Operation(token.ToString());
                        isOperationSelected = true;
                        token.Clear();
                    }
                }
            }
            return expression;
        }

        internal static MathOperation Operation(string input)
        {
            switch (input)
            {
                case "+": 
                case "add":
                    return MathOperation.Add;
                case "sub":
                case "substract":
                case "-":
                    return MathOperation.Subtract;
                case "*":
                case "multiply":
                    return MathOperation.Multiply;
                case "/":
                case "divide":
                    return MathOperation.Divide;
                case "^":
                case "power":
                case "pow":
                    return MathOperation.Power;
                case "%":
                case "mod":
                case "modulas":
                    return MathOperation.Modulus;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.none;
            }
        }
    }
}
