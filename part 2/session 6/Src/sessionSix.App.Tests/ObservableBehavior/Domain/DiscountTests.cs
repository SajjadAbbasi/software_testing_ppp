using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class DiscountTests
{
    public Discount Sut { get; private set; }

    [Theory]
    [InlineData("23B76933-FFA3-401B-A924-FEF9B0F6D31C","Promotion Code",70500,true)]
    public void Discount_is_Created_successfully(string id, string code,int amount ,bool isActive)
    {
        //arrange
        
        //act
        Sut = new Discount
        {
            Id = id,
            Code = code,
            Amount = amount,
            IsActive = isActive
        };
        if (Sut == null) throw new ArgumentNullException(nameof(Sut));
        //assert
        Sut.Id.Should().Be(id);
        Sut.Code.Should().Be(code);
        Sut.Amount.Should().Be(amount);
        Sut.IsActive.Should().Be(isActive);
    }
}