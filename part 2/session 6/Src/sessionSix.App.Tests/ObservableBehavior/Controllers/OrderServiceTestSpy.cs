using sessionSix.App.ObservableBehavior.Domain;
using sessionSix.App.ObservableBehavior.Services;

namespace sessionSix.App.Tests.ObservableBehavior.Controllers;

public class OrderServiceTestSpy : IOrderService
{
    public string OrderId { get; private set; }
    public string CustomerId { get; private set; }
    public string? DiscountCode { get; private set; }
    public string StoreId { get; private set; }
    public List<string> ProductIds { get; private set; }
    public int NumberOfCalls { get; private set; }
    public Order CreateOrder(CreateOrderRequest request)
    {
        OrderId = request.Id;
        CustomerId = request.CustomerId;
        StoreId = request.StoreId;
        DiscountCode = request.DiscountCode;
        ProductIds = request.Products.Select(p => p.Id).ToList();
        NumberOfCalls += 1;
        return new Order { Id = request.Id };
    }

    public Order UpdateOrder(ModifyOrderRequest request)
    {     
        OrderId = request.Id;
        CustomerId = request.CustomerId;
        StoreId = request.StoreId;
        DiscountCode = request.DiscountCode;
        ProductIds = request.Products.Select(p => p.Id).ToList();
        NumberOfCalls += 1;
        return new Order { Id = request.Id };
    }
}