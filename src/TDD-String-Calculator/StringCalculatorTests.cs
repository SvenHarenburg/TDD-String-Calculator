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
    }
}
