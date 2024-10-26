using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class CustomerTests
{
    public Customer Sut { get; private set; }

    [Theory]
    [InlineData("23B76933-FFA3-401B-A924-FEF9B0F6D31C","Book",true)]
    public void Customer_is_Created_successfully(string id,string name,bool isActive)
    {
        //arrange
        
        //act
        Sut = new Customer
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