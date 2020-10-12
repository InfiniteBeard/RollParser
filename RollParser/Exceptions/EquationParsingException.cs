using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Exceptions
{
    /**
     *  This class represents an equation that is used to described a generic problem that was 
     *  encountered when parsing an exception.
     */
    public class EquationParsingException : Exception
    {

        public EquationParsingException(string equation) : base (string.Format("An exception occurred while parsing the equation '{0}'", equation))
        {

        }

        public EquationParsingException(string equation, string reason): base(string.Format("An exception occurred while parsing the equation '{0}':\n{1}", equation, reason))
        {

        }
    }
}
