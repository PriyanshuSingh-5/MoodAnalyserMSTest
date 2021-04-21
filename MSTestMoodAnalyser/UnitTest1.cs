using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyser;

namespace MSTestMoodAnalyser
{
    [TestClass]
    public class UnitTest1
    {
        //UC1
        [TestMethod]
        public void Given_Happymood_Expecting_Happy_Results()
        {
            //Arrange
            MoodToAnalyse mood = new MoodToAnalyse("I am in happy mood");
            string expected = "happy";

            //Act
            string actual = mood.Analyser();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //UC-2
        [TestMethod]
        public void Given_nullmood_Expecting_Exception_Result()
        {
            //Arrange
            MoodToAnalyse mood = new MoodToAnalyse(null);
            string expected = "Object reference not set to an instance of an object";

            //Act
            string actual = mood.Analyser();

            //Assert
            Assert.AreEqual(expected, actual);
        }


        //UC2.1
        [TestMethod]
        public void Given_nullmood_Expecting_happy_Result()
        {
            //Arrange
            MoodToAnalyse mood = new MoodToAnalyse(null);
            string expected = "happy";

            //Act
            string actual = mood.Analyser();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //UC3.1-Null
        [TestMethod]
        public void Given_Emptymood_Using_CustomException_Return_Null()
        {
            //Arrange
            MoodToAnalyse mood = new MoodToAnalyse(null);
            string expected = "Mood should not be null";
            try
            {

                //Act
                string actual = mood.Analyser();
            }
            catch (MoodAnalyserException exception)
            {
                //Assert
                Assert.AreEqual(expected, exception.Message);
            }
        }

        //UC3.2-Empty 
        [TestMethod]
        public void Given_Emptymood_Using_CustomException_Return_Empty()
        {
            //Arrange
            MoodToAnalyse mood = new MoodToAnalyse("");
            string expected = "Mood should not be empty";
            try
            {

                //Act
                string actual = mood.Analyser();
            }
            catch (MoodAnalyserException exception)
            {
                //Assert
                Assert.AreEqual(expected, exception.Message);
            }
        }

    }
}