using RollParser.Tokenizng;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.States
{
    public class NumberState : State
    {

        private Lexer tokenizer;

        public NumberState(Lexer tokenizer)
        {
            this.tokenizer = tokenizer;
        }

        public override void EndOfEquation()
        {
            tokenizer.AddNumberToken();
            tokenizer.AddEndOfEquationToken();
        }

        public override void Number(char num)
        {
            tokenizer.AppendDigit(num);
            tokenizer.CurrentState = tokenizer.NumberState;
        }

        public override void Operator(char op)
        {
            tokenizer.AddNumberToken();
            tokenizer.ResetCurrentNumber();
            tokenizer.AddOperator(op);
            tokenizer.CurrentState = tokenizer.OperatorState;
        }
    }
}
