using RollParser.Tokenizing.Tokens;
using RollParser.Verification.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Verification
{
    /**
     *  This class verifies that a given sequence of tokens is valid. It does so by verifying
     *  that the order of the tokens does not violate any rules. This class along with the 
     *  TokenVerifier and it's implementations are an implementation of the State design pattern.
     */
    public class TokenVerifier
    {
        //The state the TokenVerifier is in at the start of the verification process.
        public VerifierState StartState { get; private set; }

        //The state the TokenVerifier is in when an operand token is encountered. 
        public VerifierState OperandState { get; private set; }

        //The state the TokenVerifier is in when an operator token is encountered. 
        public VerifierState OperatorState { get; private set; }

        //The current state of the TokenVerifier
        public VerifierState CurrentState { get; set; }

        public TokenVerifier()
        { 
            StartState = new EquationStartState(this);
            OperandState = new OperandTokenState(this);
            OperatorState = new OperatorTokenState(this);
            CurrentState = StartState;
        }


        //Verifies the sequence of Tokens
        public bool Verify(List<Token> tokens)
        {
            foreach(Token token in tokens)
            {
                if (!CurrentState.Process(token))
                {
                    return false;
                }
            }

            return true;
        }



    }
}
