using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class StoreTests
{
    public Store Sut { get; private set; }
 
    [Theory]
    [InlineData("8D0D847E-22E7-45B7-9139-95F4A67CA9BF","Amazon",true)]
    public void Store_is_Created_successfully(string id,string name, bool isActive)
    {
        //arrange
        
        //act
        Sut = new Store
        {
            Id = id,
            Name = name,
            IsActive = isActive,
        };
        //assert
        Sut.Id.Should().Be(id);
        Sut.Name.Should().Be(name);
        Sut.IsActive.Should().Be(isActive);
    }
}