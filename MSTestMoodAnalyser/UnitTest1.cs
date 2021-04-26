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
        //UC4-reflection to create mood analyser

        [TestMethod]
        public void Given_MoodAnalyser__Using_Reflection_ToReturn_defaultConstructor()
        {
            string expected = "Constructor is not Found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");
            }
            catch (MoodAnalyserException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }


        }

        //UC5-reflection using parameter constructor
        [TestMethod]
        public static object CreatedMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message1)
        {
            Type type = typeof(MoodToAnalyse);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message1 });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is not found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
    }
    //UC6-InvokeMethod
    [TestMethod]
    public static void Given_To_Invoke_method()
    {
        string expected = "Constructor is not found";
        try
        {
            object obj = MoodAnalyserFactory.CreateMoodAnalyseMethod("MoodAnalyzer.MoodAnalyser", "sampleClass", "HAPPY");
        }
        catch (MoodAnalyserException e)
        {
            Assert.AreEqual(expected, e.Message);
        }
    }
}

