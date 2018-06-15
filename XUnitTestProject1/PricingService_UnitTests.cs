using Domain.Interfaces;
using Xunit;
using XUnitTestProject1.Common;

namespace XUnitTestProject1
{
    public class PricingService_UnitTests : IClassFixture<CommonFixture>
    {
        private readonly IPricingService _ps;

        public PricingService_UnitTests(CommonFixture fixture)
        {
            _ps = fixture.Resolve<IPricingService>();
        }

        [Fact]
        public void DiscountPercentage_NullCheck()
        {
            // Arrange
            const decimal expectedDiscount = 0M;

            // Act
            var result = _ps.DiscountPercentage(null);

            // Assert
            Assert.Equal(expectedDiscount, result);
        }

        [Theory]
        [InlineData("03aaa")]
        [InlineData("17abc")]
        [InlineData("99edf")]
        [InlineData("10edfddd")]
        [InlineData("20")]
        [InlineData("xxxxxxxxxxxx")]
        public void DiscountPercentage_Zero(string code)
        {
            Assert.Equal(0M, _ps.DiscountPercentage(code));
        }
    }
}
