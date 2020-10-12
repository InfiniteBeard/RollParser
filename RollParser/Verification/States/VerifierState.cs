using RollParser.Exceptions;
using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Verification.States
{
    /**
     * This class is an abstract representation of a state the TokenVerifier 
     * could be in. It along with it's implementations and the TokenizerVerifer 
     * are an implementation of the State design pattern.
     */
    public abstract class VerifierState
    {

        public abstract bool OperandToken(Token token);
        public abstract bool OperatorToken(Token token);
        public abstract bool EndOfEquationToken(Token token);

        public bool Process(Token token)
        {
            if(token.GetTokenType() == Token.Type.OPERAND)
            {
                return OperandToken(token);
            } else if(token.GetTokenType() == Token.Type.BINARY_OPERATOR)
            {
                return OperatorToken(token);
            } else if(token.GetTokenType() == Token.Type.END_OF_EQUATION)
            {
                return EndOfEquationToken(token);
            } else
            {
                throw new InvalidTokenException(token);
            }
        }
    }
}
