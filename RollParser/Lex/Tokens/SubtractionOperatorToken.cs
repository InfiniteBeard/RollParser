using RollParser.Lex.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.Tokens
{
    /**
     * This class represents a token that reprsents the subtraction operator. It also
     * contains logic for being able to execute the operator.
     */
    public class SubtractionOperatorToken : BinaryOperatorToken
    {

        public override double Execute(double operand1, double operand2)
        {
            return operand1 - operand2;
        }


        public override string ToString()
        {
            return "-";
        }
    }
}
