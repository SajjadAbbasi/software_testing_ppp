using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class StoreTests
{
    [Fact]
    public void Store_is_Created_successfully()
    {
        //Arrange
        //Act
        var actual = new Store("S1", "Store1", true);
        //Assert
        actual.Id.Should().Be("S1");
        actual.Name.Should().Be("Store1");
        actual.IsActive.Should().Be(true);
    }
}