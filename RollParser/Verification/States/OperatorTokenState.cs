using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Verification.States
{

    /**
     * This class represents the state of having encountered an operator token.
     * An operator token MUST be followed by an operand token.
     */
    public class OperatorTokenState : VerifierState
    {
        private TokenVerifier tokenVerifier;

        public OperatorTokenState(TokenVerifier tokenVerifier)
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
