using RollParser.Exceptions;
using RollParser.Tokenizing.Tokens;
using RollParser.Tokenizng;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.States
{
    /**
     * This class is an abstract representation of a state the Lexer could
     * be in. It along with it's implementations and the Lexer are an 
     * implementation of the State design pattern.
     */
    public abstract class State
    {
        public abstract void Number(char num);

        public abstract void Operator(char op);

        public abstract void EndOfEquation();

        public void Process(char character)
        {
            if(NumberToken.IsNumber(character))
            {
                Number(character);

            } else if(OperatorToken.IsOperator(character))
            {
                Operator(character);

            } else if(Lexer.END_OF_EQUATION == character)
            {
                EndOfEquation();
            }
            else
            {
                throw new UnsupportedCharacterException(character);
            }

        }
    }
}
