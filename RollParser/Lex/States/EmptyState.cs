using RollParser.Tokenizng;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.States
{
    public class EmptyState : State
    {
        private Lexer lexer;

        public EmptyState(Lexer lexer)
        {
            this.lexer = lexer;
        }

        public override void EndOfEquation()
        {
            //blank
        }

        public override void Number(char num)
        {
            lexer.AppendDigit(num);
            lexer.CurrentState = lexer.NumberState;
        }

        public override void Operator(char op)
        {
            lexer.AddOperator(op);
            lexer.CurrentState = lexer.OperatorState;
        }
    }
}
