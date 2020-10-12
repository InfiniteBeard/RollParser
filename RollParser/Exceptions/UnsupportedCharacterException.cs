using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Exceptions
{
    /**
     *  This class represents an exception that is used when an unsupported input character is encountered.
     */
    public class UnsupportedCharacterException  : Exception
    {

        
        public UnsupportedCharacterException(char invalidCharacter) : base(string.Format("The character '{0}' is unsupported.", invalidCharacter))
        {

        }
        
    }
}
