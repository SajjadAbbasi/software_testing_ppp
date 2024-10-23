using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class ProductTests
{
    [Fact]
    public void Product_is_Created_successfully()
    {
        //Arrange
        //Act
        var actual = new Product("P1", "Product1", 1000);
        //Assert
        actual.Id.Should().Be("P1");
        actual.Name.Should().Be("Product1");
        actual.Price.Should().Be(1000);
    }
}