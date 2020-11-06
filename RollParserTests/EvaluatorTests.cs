using Microsoft.VisualStudio.TestTools.UnitTesting;
using RollParser.Evaluation;
using RollParser.Tokenizing.Tokens;
using RollParser.Tokenizng;
using RollParser.Verification;
using System;
using System.Collections.Generic;
using System.Text;

namespace RollParserTests
{
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void AdditionOperator()
        {
            string eq = " 1.5 + 4.0";
            double expected = 5.5;
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            double actual = evaluator.Evaluate(tokens);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SubtractionOperator()
        {
            string eq = " 1 - 4";
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            Assert.AreEqual(-3, evaluator.Evaluate(tokens));
        }

        [TestMethod]
        public void DiceOperator()
        {
            string eq = "1d10";
            int lowBound = 1;
            int highBound = 10;
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            double results = evaluator.Evaluate(tokens);
            if (!(lowBound <= results && results <= highBound))
            {
                Assert.Fail(String.Format("Result should have fallen within {0} and {1} but was instead {2}", lowBound, highBound, results));
            }
        }

        [TestMethod]
        public void MultiplicationOperator()
        {
            string eq = "5*10";
            int expected = 50;
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            double actual = evaluator.Evaluate(tokens);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdditionAndDiceOperator()
        {
            string eq = "1d5 + 10";
            int lowBound = 11;
            int highBound = 15;
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            double results = evaluator.Evaluate(tokens);
            if (!(lowBound <= results && results <= highBound))
            {
                Assert.Fail(String.Format("Result should have fallen within {0} and {1} but was instead {2}", lowBound, highBound, results));
            }
        }

        [TestMethod]
        public void SubtractionAndDiceOperator()
        {
            string eq = "1d20 - 10";
            int lowBound = -9;
            int highBound = 10;
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            double results = evaluator.Evaluate(tokens);
            if (!(lowBound <= results && results <= highBound))
            {
                Assert.Fail(String.Format("Result should have fallen within {0} and {1} but was instead {2}", lowBound, highBound, results));
            }
        }

        [TestMethod]
        public void DivisionOperator()
        {
            string eq = "5/2";
            double expected = 2.5;
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            double actual = evaluator.Evaluate(tokens);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplicationAndDivisionOperator()
        {
            string eq = "2*5/2";
            double expected = 5;
            Lexer tokenizer = new Lexer();
            List<Token> tokens = tokenizer.Parse(eq);
            TokenVerifier verifier = new TokenVerifier();
            Assert.IsTrue(verifier.Verify(tokens));
            TokenEvaluator evaluator = new TokenEvaluator();
            double actual = evaluator.Evaluate(tokens);
            Assert.AreEqual(expected, actual);
        }
    }
}
