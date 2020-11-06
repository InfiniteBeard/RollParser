using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.Tokens
{

    /**
     * This class represnts a series of characters that have been parsed into a number
     */
    public class NumberToken : Token
    {
        public double Number { get; private set; }

        public NumberToken(double number)
        {
            this.Number = number;
        }


        public static bool IsNumber(char potentialNumber)
        {
            return Char.IsDigit(potentialNumber) || potentialNumber == '.';
        }


        public static NumberToken Create(string s)
        {
            double number = double.Parse(s);
            return new NumberToken(number);
        }

        public override Type GetTokenType()
        {
            return Token.Type.OPERAND;
        }

        public override string ToString()
        {
            return Number.ToString(); 
        }

    }
}
