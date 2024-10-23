using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class CustomerTests
{
    [Fact]
    public void Customer_is_Created_successfully()
    {
        //Arrange
        //Act
        var actual = new Customer("C1","Customer",true);
        //Assert
        actual.Id.Should().Be("C1");
        actual.Name.Should().Be("Customer");
        actual.IsActive.Should().Be(true);
    }
}