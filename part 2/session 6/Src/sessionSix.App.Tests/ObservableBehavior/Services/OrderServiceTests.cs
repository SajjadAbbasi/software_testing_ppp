using FluentAssertions;
using sessionSix.App.ObservableBehavior.Services;
using sessionSix.App.Tests.ObservableBehavior.Domain.FakeObjects;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Services;

public class OrderServiceTests
{
    private readonly IOrderService _sut;

    public OrderServiceTests()
    {
        _sut = new OrderService(new StoreRepositoryFakeObject(),
            new DiscountRepositoryFakeObject(),
            new CustomerRepositoryFakeObject(),
            new ProductRepositoryFakeObject(),
            new OrderRepositoryFakeObject());
    }
    [Theory]
    [InlineData("1","Customer1","Store1","xyz")]
    public void Order_is_created_successfully(string orderId,string customerId,string storeId,string discountCode)
    {
        var rand = new Random();
        //Arrange
        var order = new CreateOrderRequest
        {
            Id = orderId,
            CustomerId = customerId,
            StoreId = storeId,
            DiscountCode = discountCode,
            Products = new List<ProductRequestItem>()
            {
                new() { Id = "1" },
                new() { Id = "2" }
            }
        };
        
        //Act
        var actual = _sut.CreateOrder(order);
        
        //Assert
        actual.Customer.IsActive.Should().Be(true);
        actual.Store.IsActive.Should().Be(true);
        actual.Discount?.IsActive.Should().Be(true);
        actual.Products.Count.Should().Be(2);
    }
    
    [Fact]
    public void Order_is_modified_successfully()
    {        
        //Arrange
        Order_is_created_successfully("ModifyingOrder","C1","C1","DC1");
        var order = new ModifyOrderRequest()
        {
            Id = "ModifyingOrder",
            CustomerId = "C2",
            StoreId = "S2",
            DiscountCode = "DC2",
            Products = new List<ProductRequestItem>()
            {
                new() { Id = "P2", Quantity = 10 }
            }
        };
        //Act
        var actual = _sut.UpdateOrder(order);
        
        //Assert
        actual.Id.Should().Be("ModifyingOrder");
        actual.Customer.Id.Should().Be("C2");
        actual.Customer.IsActive.Should().Be(true);
        actual.Store.Id.Should().Be("S2");
        actual.Store.IsActive.Should().Be(true);
        actual.Discount?.Id.Should().Be("DC2");
        actual.Discount?.IsActive.Should().Be(true);
        actual.Products.Count.Should().Be(1);
    }
}