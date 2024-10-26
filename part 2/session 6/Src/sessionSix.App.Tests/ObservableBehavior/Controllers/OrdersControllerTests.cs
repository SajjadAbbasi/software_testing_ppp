using FluentAssertions;
using sessionSix.App.ObservableBehavior.Controllers;
using sessionSix.App.ObservableBehavior.Services;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Controllers;

public class OrdersControllerTests
{
    [Fact]
    public void Order_is_created_successfully()
    {
        //arrange
        var request = new CreateOrderRequest
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = Guid.NewGuid().ToString(),
            StoreId = Guid.NewGuid().ToString(),
            DiscountCode = Guid.NewGuid().ToString(),
            Products =
            [
                new() { Id = Guid.NewGuid().ToString(), Quantity = 1 },
                new() { Id = Guid.NewGuid().ToString(), Quantity = 2 }
            ]
        };
        var orderService = new OrderServiceTestSpy();
        var sut = new OrdersController(orderService);
        //act
        var actual =sut.CreateOrder(request);
        //assert
        actual.Should().Be(request.Id);
        orderService.OrderId.Should().Be(request.Id);
        orderService.CustomerId.Should().Be(request.CustomerId);
        orderService.StoreId.Should().Be(request.StoreId);
        orderService.DiscountCode.Should().Be(request.DiscountCode);
        orderService.ProductIds.Should().Equal(request.Products.Select(p=>p.Id).ToList());
        orderService.NumberOfCalls.Should().Be(1);
    }
    
    [Fact]
    public void Order_is_modified_successfully()
    {
        //arrange
        var request = new ModifyOrderRequest
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = Guid.NewGuid().ToString(),
            StoreId = Guid.NewGuid().ToString(),
            DiscountCode = Guid.NewGuid().ToString(),
            Products =
            [
                new() { Id = Guid.NewGuid().ToString(), Quantity = 1 },
                new() { Id = Guid.NewGuid().ToString(), Quantity = 2 }
            ]
        };
        var orderService = new OrderServiceTestSpy();
        var sut = new OrdersController(orderService);
        //act
        var actual =sut.UpdateOrder(request);
        //assert
        actual.Should().Be(request.Id);
        orderService.OrderId.Should().Be(request.Id);
        orderService.CustomerId.Should().Be(request.CustomerId);
        orderService.StoreId.Should().Be(request.StoreId);
        orderService.DiscountCode.Should().Be(request.DiscountCode);
        orderService.ProductIds.Should().Equal(request.Products.Select(p=>p.Id).ToList());
        orderService.NumberOfCalls.Should().Be(1);
    }
}