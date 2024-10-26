using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class ProductTests
{
    public Product Sut { get; private set; }

    [Theory]
    [InlineData("8D0D847E-22E7-45B7-9139-95F4A67CA9BF","Book",1200)]
    public void Product_is_Created_successfully(string id, string name,int price)
    {
        //arrange

        //act
        Sut = new Product
        {
            Id = id,
            Name = name,
            Price = price,
        };
        //assert
        Sut.Id.Should().Be(id);
        Sut.Name.Should().Be(name);
        Sut.Price.Should().Be(price);
    }
}