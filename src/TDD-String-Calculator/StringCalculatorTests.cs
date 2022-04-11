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
    }
}
