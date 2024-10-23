using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class DiscountTests
{
    [Fact]
    public void Discount_is_Created_successfully()
    {
        //Arrange
        //Act
        var actual = new Discount("D1", "XYZ", 8800, false);
        //Assert
        actual.Id.Should().Be("D1");
        actual.Code.Should().Be("XYZ");
        actual.Amount.Should().Be(8800);
        actual.IsActive.Should().Be(false);
    }
}