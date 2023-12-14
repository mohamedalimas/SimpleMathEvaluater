using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluater
{
    internal class MathExpression
    {
        internal double leftOperand {  get; set; }
        internal double rightOperand { get; set; }
        internal MathOperation operation { get; set; }
    }
}
