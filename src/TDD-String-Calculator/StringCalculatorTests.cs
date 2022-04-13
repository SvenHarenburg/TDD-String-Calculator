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
        public void Add_Returns_3_For_1_And_2()
        {
            // Arrange
            var input = "1,2";
            var sut = new StringCalculator();

            // Act
            var result = sut.Add(input);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
