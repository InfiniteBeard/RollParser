using Microsoft.VisualStudio.TestTools.UnitTesting;
using RollParser.Exceptions;
using RollParser.Tokenizing.Tokens;
using RollParser.Tokenizng;
using RollParser.Verification;
using System.Collections.Generic;

namespace RollParserTests
{
    [TestClass]
    public class VerifierTests
    {
        [TestMethod]
        public void DiceOperatorSingleDigitOperands()
        {
            string eq = "1d4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
        }
        [TestMethod]

        public void DoubleDiceOperators()
        {
            string eq = "1dd4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void StartsWithDiceOperator()
        {
            string eq = "d4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void EndsWithDiceOperator()
        {
            string eq = "1d";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void AdditionOperator()
        {
            string eq = "1 + 4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
        }

        [TestMethod]
        public void StartsWithAdditionOperator()
        {
            string eq = "+4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void EndsWithAdditionOperator()
        {
            string eq = "1+";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void SubtractionOperator()
        {
            string eq = "1 - 4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
        }

        [TestMethod]
        public void StartsWithSubtractionOperator()
        {
            string eq = "-4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void EndsWithSubtractionOperator()
        {
            string eq = "1-";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void BeginsWithMultiplication()
        {
            string eq = "* 60";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void EndsWithMultiplication()
        {
            string eq = "5 *";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

        [TestMethod]
        public void Multiplication()
        {
            string eq = "5 * 60";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
        }

        [TestMethod]
        public void DoubleMultiplication()
        {
            string eq = "5 * * 60";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsFalse(verifier.Verify(tokens));
        }

    }
}
