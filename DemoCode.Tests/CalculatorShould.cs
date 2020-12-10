using AutoFixture.Xunit2;
using Xunit;

namespace DemoCode.Tests
{
    public class CalculatorShould
    {
        //data driven test
        [Theory]
        //[InlineData(1, 2)] //AddTwoPositiveNumbers
        [InlineAutoData] //AddTwoPositiveNumbers
        //[InlineData(0, 2)] //AddZeroAndPositiveNumber
        [InlineAutoData(0)] //AddZeroAndPositiveNumber
        //[InlineData(-5, 1)] //AddPositiveAndNegativeNumbers
        [InlineAutoData(-5)] //AddPositiveAndNegativeNumbers
        public void Add(int a, int b, Calculator sut)
        {
            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }

        [Theory]
        [AutoData]
        public void AddTwoPositiveNumbers(int a, int b, Calculator sut)
        {
            sut.Add(a);
            sut.Add(b);

            Assert.Equal(a + b, sut.Value);
        }
    }
}
