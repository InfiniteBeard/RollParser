using Microsoft.VisualStudio.TestTools.UnitTesting;
using RollParser.Exceptions;
using RollParser.Tokenizing.Tokens;
using RollParser.Tokenizng;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace RollParserTests
{
    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void DiceOperatorSingleDigitOperands()
        {
            string eq = "1d4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            Assert.AreEqual(tokens[0].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[0].ToString(), "1");
            Assert.AreEqual(tokens[1].GetTokenType(), Token.Type.BINARY_OPERATOR);
            Assert.AreEqual(tokens[1].ToString(), "d");
            Assert.AreEqual(tokens[2].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[2].ToString(), "4");
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);

        }

        [TestMethod]
        public void AdditionOperator()
        {
            string eq = "1 + 4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            Assert.AreEqual(tokens[0].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[0].ToString(), "1");
            Assert.AreEqual(tokens[1].GetTokenType(), Token.Type.BINARY_OPERATOR);
            Assert.AreEqual(tokens[1].ToString(), "+");
            Assert.AreEqual(tokens[2].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[2].ToString(), "4");
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
        }

        [TestMethod]
        public void SubtractionOperator()
        {
            string eq = "1 - 4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            Assert.AreEqual(tokens[0].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[0].ToString(), "1");
            Assert.AreEqual(tokens[1].GetTokenType(), Token.Type.BINARY_OPERATOR);
            Assert.AreEqual(tokens[1].ToString(), "-");
            Assert.AreEqual(tokens[2].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[2].ToString(), "4");
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
        }


        [TestMethod]

        public void DiceOperatorUppercaseD()
        {
            string eq = "1D4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            Assert.AreEqual(tokens[0].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[0].ToString(), "1");
            Assert.AreEqual(tokens[1].GetTokenType(), Token.Type.BINARY_OPERATOR);
            Assert.AreEqual(tokens[1].ToString(), "d");
            Assert.AreEqual(tokens[2].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[2].ToString(), "4");
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);

        }

        [TestMethod]
        public void DiceOperatorMultiDigitOperands()
        {
            string eq = "100d40";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            Assert.AreEqual(tokens[0].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[0].ToString(), "100");
            Assert.AreEqual(tokens[1].GetTokenType(), Token.Type.BINARY_OPERATOR);
            Assert.AreEqual(tokens[1].ToString(), "d");
            Assert.AreEqual(tokens[2].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[2].ToString(), "40");
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
        }
        
        [TestMethod]
        public void OperatorMultiDigitOperands()
        {
            string eq = "5 * 60";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            Assert.AreEqual(tokens[0].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[0].ToString(), "5");
            Assert.AreEqual(tokens[1].GetTokenType(), Token.Type.BINARY_OPERATOR);
            Assert.AreEqual(tokens[1].ToString(), "*");
            Assert.AreEqual(tokens[2].GetTokenType(), Token.Type.OPERAND);
            Assert.AreEqual(tokens[2].ToString(), "60");
            Assert.AreEqual(tokens[3].GetTokenType(), Token.Type.END_OF_EQUATION);
        }

        [TestMethod]
        [ExpectedException(typeof(UnsupportedCharacterException))]
        public void InvalidCharacter()
        {
            string eq = "1a4";
            Lexer tokenizer = new Lexer();
            tokenizer.Parse(eq);
        }

    }
}
