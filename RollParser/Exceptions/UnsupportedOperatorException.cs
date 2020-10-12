using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Exceptions
{
    /**
     * This class represents an exception that is used when an unsupported operator is encountered.
     */
    public class UnsupportedOperatorException : Exception
    {

        public UnsupportedOperatorException(char invalidOperator) : base(string.Format("The operator '{0}' is unsupported.", invalidOperator))
        {

        }
    }
}
