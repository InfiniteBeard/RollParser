using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Lex.Tokens
{
    public class MultiplicationOperatorToken : BinaryOperatorToken
    {
        public override double Execute(double operand1, double operand2)
        {
            return operand1 * operand2;
        }

        public override string ToString()
        {
            return "*";
        }

    }
}
