using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Lex.Tokens
{
    public class DivisonOperatorToken : BinaryOperatorToken
    {
        public override double Execute(double operand1, double operand2)
        {
            return operand1 / operand2;
        }
    }
}
