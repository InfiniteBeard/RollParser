using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.Tokens
{
    /**
     * This class represents a token that signals the end of an equation.
     */
    public class EndOfEquationToken : Token
    {
        public override Type GetTokenType()
        {
            return Type.END_OF_EQUATION;
        }
    }
}
