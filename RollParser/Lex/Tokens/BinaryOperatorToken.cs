using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Lex.Tokens
{
    public abstract class BinaryOperatorToken : Token
    {
        public abstract double Execute(double operand1, double operand2);

        public override Type GetTokenType()
        {
            return Token.Type.BINARY_OPERATOR;
        }
    }
}
