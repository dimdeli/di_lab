using Domain;
using Xunit;

namespace XUnitTestProject1
{
    public class Person_UnitTests
    {
        public Person_UnitTests()
        {
            var test = "initialize...";
        }

        [Fact]
        public void GetFullName()
        {
            // Arrange
            const string expectedFullName = "foo bar";
            var p = new Person();

            // Act
            p.FirstName = "foo";
            p.LastName = "bar";

            // Assert
            Assert.Equal(expectedFullName, p.GetFullName());
        }

        [Fact]
        public void GetFullName_NullCheck()
        {
            // Arrange
            const string expectedFullName = " bar";
            var p = new Person();

            // Act
            p.FirstName = null;
            p.LastName = "bar";

            // Assert
            Assert.Equal(expectedFullName, p.GetFullName());
        }
    }
}
