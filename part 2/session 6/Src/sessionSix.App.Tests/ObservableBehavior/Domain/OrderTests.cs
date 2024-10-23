using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class OrderTests
{
    [Fact]
    public void Order_is_Created_successfully()
    {
        //Arrange
        //Act
        var actual = new Order("O1");
        //Assert
        actual.Id.Should().Be("O1");
    }
}