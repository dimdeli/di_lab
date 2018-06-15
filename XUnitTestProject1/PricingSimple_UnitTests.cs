using Domain;
using Domain.Services;
using Xunit;

namespace XUnitTestProject1
{
    public class PricingSimple_UnitTests
    {
        public PricingSimple_UnitTests()
        {
            var test = "initialize...";
        }

        [Fact]
        public void DiscountPercentage_NullCheck()
        {
            // Arrange
            const decimal expectedDiscount = 0M;
            var ps = new PricingService();

            // Act
            var result = ps.DiscountPercentage(null);

            // Assert
            Assert.Equal(expectedDiscount, result);
        }
    }
}
