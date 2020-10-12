using RollParser.Exceptions;
using RollParser.Lex.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.Tokens
{

    /**
     * This class represents an operator token. it also contains the logic
     * for determining if an input char is token.
     */
    public abstract class OperatorToken : Token
    {

        private static HashSet<char> operators = new HashSet<char>
        {
            'd', 'D', '+', '-', '*'
        };
        


        public static Token Create(char op)
        {
            switch (op)
            {
                case 'd':
                case 'D':
                    return new DiceOperatorToken();
                case '+':
                    return new AdditionOperatorToken();
                case '-':
                    return new SubtractionOperatorToken();
                case '*':
                    return new MultiplicationOperatorToken();
                default:
                    throw new UnsupportedOperatorException(op);
            }
        }

        public static bool IsOperator(char s)
        {
            return operators.Contains(s);
        }
    }
}
