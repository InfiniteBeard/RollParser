using RollParser.Tokenizing.States;
using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizng
{
    /**
     * This clas is responsible for taking a string that represents an equation and converting 
     * it into a series of tokens. This class, alongt with the Token class and it's implementations, 
     * are an implementation of the State design pattern.
     */
    public class Lexer
    {
        //Represents the start of an equation
        public State EmptyState { get; private set; }
        //Reprsents that a numerical character was encountered
        public State NumberState { get; private set; }
        //Represents that an operator character was encountered
        public State OperatorState { get; private set; }
        //Represents the current state of the Lexer
        public State CurrentState { get; set; }

        //Represents the end of the equation
        public static char END_OF_EQUATION = '\0';

        //The current set of tokens
        private List<Token> tokens = new List<Token>();

        //The current number that is being parsed. 
        private string currentNumber = string.Empty;



        public Lexer()
        {
            EmptyState = new EmptyState(this);
            NumberState = new NumberState(this);
            OperatorState = new OperatorState(this);


            CurrentState = EmptyState;
        }

        //Add a token to the token list
        public void AddToken(Token t)
        {
            tokens.Add(t);
        }

        //Parses the specified equation
        public List<Token> Parse(string equation)
        {
            tokens = new List<Token>();
            foreach(char c in equation.Replace(" ", ""))
            {
                CurrentState.Process(c);
            }
            CurrentState.Process(END_OF_EQUATION);
            return tokens;
        }


        //Adds a digit to the currentNumber
        public void AppendDigit(char digit)
        {
            currentNumber += digit;
        }

        //Adds an operator token to the token list
        public void AddOperator(char op)
        {
            tokens.Add(OperatorToken.Create(op));
        }

        //Adds a number token to the token list
        public void AddNumberToken()
        {
            tokens.Add(NumberToken.Create(currentNumber));
        }

        //Adds an end of equation token to the token list
        public void AddEndOfEquationToken()
        {
            tokens.Add(new EndOfEquationToken());
        }

        //Resets the current number
        public void ResetCurrentNumber()
        {
            currentNumber = string.Empty;
        }



    }
}
