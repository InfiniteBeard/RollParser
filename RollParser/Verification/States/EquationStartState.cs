using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Verification.States
{
    /**
     * This class represents the starting state when verifying a series of tokens. 
     */
    public class EquationStartState : VerifierState
    {

        private TokenVerifier tokenVerifier;

        public EquationStartState(TokenVerifier tokenVerifier)
        {
            this.tokenVerifier = tokenVerifier;
        }

        public override bool EndOfEquationToken(Token token)
        {
            return false;
        }

        public override bool OperandToken(Token token)
        {
            tokenVerifier.CurrentState = tokenVerifier.OperandState;
            return true;
        }

        public override bool OperatorToken(Token token)
        {
            return false;
        }
    }
}
