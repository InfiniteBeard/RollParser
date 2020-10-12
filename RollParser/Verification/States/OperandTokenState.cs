using RollParser.Exceptions;
using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Verification.States
{
    /**
     * This class represents the state of having encountered an operand token.
     * An operand token MUST be followed by an operator token.
     */
    public class OperandTokenState : VerifierState
    {
        private TokenVerifier tokenVerifier;

        public OperandTokenState(TokenVerifier tokenVerifier)
        {
            this.tokenVerifier = tokenVerifier;
        }

        public override bool EndOfEquationToken(Token token)
        {
            return true;
        }

        public override bool OperandToken(Token token)
        {
            return false;
        }

        public override bool OperatorToken(Token token)
        {
            tokenVerifier.CurrentState = tokenVerifier.OperatorState;
            return true;
        }
    }
}
