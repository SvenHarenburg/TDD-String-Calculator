using NUnit.Framework;

namespace TDD_String_Calculator
{
    public class StringCalculatorTests
    {
        [Test]
        public void Add_Returns_0_For_Empty_String()
        {
            // Arrange
            var input = "";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]        
        public void Add_Returns_Number_For_Single_Digit_Number()
        {
            // Arrange
            var input = "1";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Add_Returns_Number_For_Multi_Digit_Number()
        {
            // Arrange
            var input = "10";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Add_Returns_Sum_For_Two_Single_Digit_Numbers()
        {
            // Arrange
            var input = "1,2";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Add_Returns_Sum_For_Two_Double_Digit_Numbers()
        {
            // Arrange
            var input = "10,20";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Add_Returns_Sum_For_One_Single_Digit_Number_And_One_Double_Digit_Number()
        {
            // Arrange
            var input = "1,20";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(21));
        }

        [Test]
        public void Add_Returns_Sum_For_Three_Numbers()
        {
            // Arrange
            var input = "1,2,3";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_Returns_Sum_When_New_Line_Is_Used_As_Delimiter()
        {
            // Arrange
            var input = $"1\n2\n3";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_Returns_Sum_When_Mix_Of_Comma_And_New_Line_Are_Used_As_Delimiter()
        {
            // Arrange
            var input = $"1\n2,3";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        [TestCase(';', TestName = $"{nameof(Add_Returns_Sum_When_Delimiter_Is_Specified_In_First_Line)}_And_Delimiter_Is_Semicolon")]
        [TestCase(',', TestName = $"{nameof(Add_Returns_Sum_When_Delimiter_Is_Specified_In_First_Line)}_And_Delimiter_Is_Comma")]
        [TestCase('_', TestName = $"{nameof(Add_Returns_Sum_When_Delimiter_Is_Specified_In_First_Line)}_And_Delimiter_Is_Underscore")]
        [TestCase('-', TestName = $"{nameof(Add_Returns_Sum_When_Delimiter_Is_Specified_In_First_Line)}_And_Delimiter_Is_Minus")]
        //[TestCase('[', TestName = $"{nameof(Add_Returns_Sum_When_Delimiter_Is_Specified_In_First_Line)}_And_Delimiter_Is_Opening_Square_Bracket")]
        //[TestCase(']', TestName = $"{nameof(Add_Returns_Sum_When_Delimiter_Is_Specified_In_First_Line)}_And_Delimiter_Is_Closing_Square_Bracket")]
        public void Add_Returns_Sum_When_Delimiter_Is_Specified_In_First_Line(char delimiter)
        {
            // Arrange
            var input = $"//{delimiter}\n1{delimiter}2";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Add_Returns_Sum_When_Specified_Delimiter_Longer_Than_One_Character()
        {
            var input = $"//[***]\n1***2***3";
            var sut = new StringCalculator();

            var result = sut.Add(input);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_Returns_Sum_When_Multiple_Delimiters_Are_Specified()
        {
            var input = $"//[*][%]\n1*2%3";
            var sut = new StringCalculator();

            var result = sut.Add(input);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_Returns_Sum_When_Multiple_Delimiters_Are_Specified_And_Delimiters_Are_Longer_Than_One_Character()
        {
            var input = $"//[**][%%]\n1**2%%3";
            var sut = new StringCalculator();

            var result = sut.Add(input);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_Returns_Number_When_Delimiter_Is_Specified_But_Only_One_Number_In_String()
        {
            // Arrange
            var input = $"//;\n1";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Add_Throws_Exception_When_Inputting_Negative_Number()
        {
            var input = "-1";
            var sut = new StringCalculator();

            Assert.Throws<Exception>(() => sut.Add(input), "negatives not allowed: -1");
        }

        [Test]
        public void Add_Throws_Exception_When_Inputting_Multiple_Negative_Numbers()
        {
            var input = "-1,-2";
            var sut = new StringCalculator();

            Assert.Throws<Exception>(() => sut.Add(input), "negatives not allowed: -1,-2");
        }

        [Test]
        public void Add_Throws_Exception_When_Inputting_Both_Positive_And_Negative_Numbers()
        {
            var input = "1,-1,2,-2";
            var sut = new StringCalculator();

            Assert.Throws<Exception>(() => sut.Add(input), "negatives not allowed: -1,-2");
        }

        [Test]
        public void GetCalledCount_Returns_0_When_Add_Has_Not_Been_Called()
        {
            var sut = new StringCalculator();
            
            var result = sut.GetCalledCount();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetCalledCount_Returns_1_When_Add_Has_Been_Called_Once()
        {
            var sut = new StringCalculator();
            sut.Add("1");

            var result = sut.GetCalledCount();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetCalledCount_Returns_2_When_Add_Has_Been_Called_Twice()
        {
            var sut = new StringCalculator();
            sut.Add("1");
            sut.Add("1");

            var result = sut.GetCalledCount();

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void AddOccured_Gets_Raised_When_Add_Occured()
        {
            var sut = new StringCalculator();
            var hasBeenRaised = false;
            sut.AddOccured += (input, result) => { 
                hasBeenRaised = true; 
            };

            sut.Add("1");

            Assert.That(hasBeenRaised, Is.True);
        }

        [Test]
        public void AddOccured_Contains_Given_Input_When_Raised()
        {
            var sut = new StringCalculator();
            string givenInput = "";
            sut.AddOccured += (input, result) => {
                givenInput = input;
            };

            sut.Add("2");

            Assert.That(givenInput, Is.EqualTo("2"));
        }

        [Test]
        public void AddOccured_Contains_Given_Input_When_Add_Is_Called_With_Delimiter_Specification_Line()
        {
            var sut = new StringCalculator();
            string givenInput = "";
            sut.AddOccured += (input, result) => {
                givenInput = input;
            };
            var input = "//;\n1";

            sut.Add(input);

            Assert.That(givenInput, Is.EqualTo(input));
        }

        [Test]
        public void AddOccured_Contains_Same_Result_As_Given_By_Add()
        {
            var sut = new StringCalculator();
            int givenResult = 0;
            sut.AddOccured += (input, result) => {
                givenResult = result;
            };

            var addResult = sut.Add("1,2");

            Assert.That(givenResult,Is.EqualTo(addResult));
        }

        [Test]
        public void Add_Ignores_Numbers_Greater_Than_1000()
        {
            var input = $"2,1001";
            var sut = new StringCalculator();

            var result = sut.Add(input);
                        
            Assert.That(result, Is.EqualTo(2));
        }

    }
}
