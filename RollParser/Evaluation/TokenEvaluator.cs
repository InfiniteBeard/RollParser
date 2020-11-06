using RollParser.Exceptions;
using RollParser.Lex.Tokens;
using RollParser.Tokenizing.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Evaluation
{
    /**
     * This class is responsible for evaluating a Token sequence that represent 
     * an equation.
     */
    public class TokenEvaluator
    {
        public TokenEvaluator()
        {

        }

        /**
         * Removes any END_OF_EQUATION tokens
         */
        private void RemoveEndOfEquationTokens(List<Token> tokens)
        {
            for(int i = 0; i < tokens.Count;)
            {
                Token token = tokens[i];
                if(token.GetTokenType() == Token.Type.END_OF_EQUATION)
                {
                    tokens.RemoveAt(i);
                } else
                {
                    ++i;
                }
            }
        }


        /**
         * Evalutes all dice operators in the Token sequence.
         * 
         * tokens - the token sequence that whose dice operators will be evaluated
         */
        private void EvaluateBinaryOperator<T>(List<Token> tokens)
        {
            for(int i = 0; i < tokens.Count;)
            {
                Token token = tokens[i];
                if(token.GetTokenType() == Token.Type.BINARY_OPERATOR)
                {
                    if(token is T)
                    {
                        BinaryOperatorToken op = (BinaryOperatorToken)token;
                        int operand1Index = i - 1;
                        int operand2Index = i + 1;
                        NumberToken operand1 = (NumberToken)tokens[operand1Index];
                        NumberToken operand2 = (NumberToken)tokens[operand2Index];

                        tokens[operand1Index] = new NumberToken(op.Execute(operand1.Number, operand2.Number));
                        tokens.RemoveAt(operand2Index);
                        tokens.RemoveAt(i);

                    } 
                    else
                    {
                        ++i;
                    }
                } else
                {
                    ++i;
                }
            }
        }


        /**
         *  Evalutes the specified token sequence.
         *  
         *  tokens - the token sequence that whose dice operators will be evaluated
         */
        public double Evaluate(List<Token> tokens)
        {
            RemoveEndOfEquationTokens(tokens);
            EvaluateBinaryOperator<DiceOperatorToken>(tokens);
            EvaluateBinaryOperator<MultiplicationOperatorToken>(tokens);
            EvaluateBinaryOperator<DivisonOperatorToken>(tokens);
            EvaluateBinaryOperator<AdditionOperatorToken>(tokens);
            EvaluateBinaryOperator<SubtractionOperatorToken>(tokens);
            
            if(tokens.Count == 1)
            {
                if(tokens[0].GetTokenType() == Token.Type.OPERAND)
                {

                    if(tokens[0] is NumberToken)
                    {

                        NumberToken number = (NumberToken)tokens[0];
                        return number.Number;
                    }
                    else
                    {
                        throw new EquationParsingException("Final token is not of a number");
                    }
                }
                else
                {
                    throw new EquationParsingException("Final token is not an operand");
                }

            }
            else
            {
                throw new EquationParsingException("Equation had more then one token after parsing");
            }
        }
    }
}
