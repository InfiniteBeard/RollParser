using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.Tokens
{
    /**
     * This class represnts a single token in an equation
     */
    public abstract class Token
    {
        public enum Type
        {
            OPERAND,
            BINARY_OPERATOR,
            END_OF_EQUATION
        }

        public abstract Type GetTokenType();

    }
}
