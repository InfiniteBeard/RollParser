using RollParser.Lex.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParser.Tokenizing.Tokens
{
    /**
     * This class represents a token that reprsents the dice operator. It also
     * contains logic for being able to execute the operator.
     */
    public class DiceOperatorToken : BinaryOperatorToken
    {
        private Random rnd = new Random();


        public override double Execute(double diceNumber, double diceType)
        {
            int result = 0;
            int convertedDiceType = ConvertDouble(diceType);
            int convertedDiceNumber = ConvertDouble(diceNumber);

            for(int i = 0; i < convertedDiceNumber; ++i)
            {
                result += rnd.Next(1, convertedDiceType + 1);
            }
            return Convert.ToDouble(result);
        }

        public override string ToString()
        {
            return "d";
        }

        private int ConvertDouble(double value)
        {
            return Convert.ToInt32(Math.Round(value, 0, MidpointRounding.AwayFromZero));
        }
    }
}
