using NUnit.Framework;
using RoulettePlatform.Classes;
using RoulettePlatform.Data.Models;
using RoulettePlatform.Data.Queries;

namespace RoulettePlatformUnitTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void BetContainsNoCurrentPayout()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Red = 1, BetAmount = 100 };
            BetResultsModel betResults = new() { Red = 1 };

            //Act
            var (_, winnings, totalPayout) = customerBet.GetValue(betResults, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual(200, totalPayout);
        }

        [Test]
        public void BetContainsOtherPayout()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Red = 1, BetAmount = 100 };
            BetResultsModel betResults = new() { Red = 1 };

            //Act
            var (_, winnings, totalPayout) = customerBet.GetValue(betResults, 100);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual(300, totalPayout);
        }
        [Test]
        public void BetContainsRed()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Red = 1, BetAmount = 100 };
            BetResultsModel betResults = new() { Red = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResults, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("Red", BetType);
        }
        [Test]
        public void BetContainsBlack()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Black = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { Black = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("Black", BetType);
        }

        [Test]
        public void BetContainsNoMatch()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Black = 1, Red = 1, BetAmount = 100, Number = 1 };
            BetResultsModel betResult = new() { Red = 0, Black = 0, Number = 2 };

            //Act
            var (BetType, winnings, totalPayout) = customerBet.GetValue(betResult, 100);


            //Assert
            Assert.AreEqual("not a winning gamble", BetType);
            Assert.AreEqual(0, winnings);
            Assert.AreEqual(100, totalPayout);
        }
        [Test]
        public void BetContainsEvenNumber()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Even = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { Even = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("Even", BetType);
        }

        [Test]
        public void BetContainsOddNumber()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Odd = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { Odd = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("Odd", BetType);
        }

        [Test]
        public void BetContainsNumberInFirstHalf()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { FirstHalf = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { FirstHalf = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("1-18", BetType);
        }

        [Test]
        public void BetContainsNumberInSecondHalf()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { SecondHalf = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { SecondHalf = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("19-36", BetType);
        }

        [Test]
        public void BetContainsFirst12()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { FirstTwelve = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { FirstTwelve = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("First12", BetType);
        }

        [Test]
        public void BetContainsSecond12()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { SecondTwelve = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { SecondTwelve = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("Second12", BetType);
        }
        [Test]
        public void BetContainsThird12()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { ThirdTwelve = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { ThirdTwelve = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("Third12", BetType);
        }
        [Test]
        public void BetContainsFirst2to1()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { FirstTwotoOne = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { FirstTwotoOne = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("1st 2-1", BetType);
        }
        [Test]
        public void BetContainsSecond2to1()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { SecondTwotoOne = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { SecondTwotoOne = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("2nd 2-1", BetType);
        }
        [Test]
        public void BetContainsThird2to1()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { ThirdTwotoOne = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { ThirdTwotoOne = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(200, winnings);
            Assert.AreEqual("3rd 2-1", BetType);
        }
        [Test]
        public void BetContainsFullNumber()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Number = 1, NumberFull = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { Number = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(3500, winnings);
            Assert.AreEqual("Number", BetType);
        }
        [Test]
        public void BetContainsSplitNumber()
        {
            //Arrange 
            CustomerBetModel customerBet = new() { Number = 1, NumberSplit = 1, BetAmount = 100 };
            BetResultsModel betResult = new() { Number = 1 };

            //Act
            var (BetType, winnings, _) = customerBet.GetValue(betResult, 0);


            //Assert
            Assert.AreEqual(1700, winnings);
            Assert.AreEqual("Number", BetType);
        }
    }
}