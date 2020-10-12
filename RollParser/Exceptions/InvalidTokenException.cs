using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Exceptions
{
    public class InvalidTokenException : Exception
    {

        /**
         * This class reprsents an exception that is used when an invalid token is encountered.
         * 
         */
        public InvalidTokenException(Token token) : base(string.Format("The token '{0}' was not expected and is invalid", token.GetTokenType()))
        {

        }
    }
}
