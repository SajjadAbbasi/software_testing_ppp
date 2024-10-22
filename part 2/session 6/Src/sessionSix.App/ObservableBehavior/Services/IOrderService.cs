using Ardalis.GuardClauses;
using sessionSix.App.ObservableBehavior.Domain;

namespace sessionSix.App.ObservableBehavior.Services;

public interface IOrderService
{
    Order CreateOrder(CreateOrderRequest request);
    Order UpdateOrder(ModifyOrderRequest request);
}

public class OrderService(
    IStoreRepository storeRepository,
    IDiscountRepository discountRepository,
    ICustomerRepository customerRepository,
    IProductRepository productRepository,
    IOrderRepository orderRepository) : IOrderService
{
    public Order CreateOrder(CreateOrderRequest request)
    {
        var customer = customerRepository.GetBy(request.CustomerId);
        var store = storeRepository.GetBy(request.StoreId);
        var discount = discountRepository.GetBy(request.DiscountCode);
        
        var order = new Order(request.Id, store, customer, discount);
        var products = request.Products.Select(p => productRepository.GetBy(p.Id)).ToList();
        if (!products.Any())
            throw new Exception("AtLeast one product is required.");
        products.ForEach(p=>order.AddProduct(p));

        orderRepository.Add(order);

        return order;
    }

    public Order UpdateOrder(ModifyOrderRequest request)
    {
        var order = orderRepository.GetBy(request.Id);

        var customer = customerRepository.GetBy(request.CustomerId);
        var store = storeRepository.GetBy(request.StoreId);
        var discount = discountRepository.GetBy(request.DiscountCode);
        
        var products = request.Products.Select(p => productRepository.GetBy(p.Id)).ToList();
        if (!products.Any())
            throw new Exception("AtLeast one product is required.");
        products.ForEach(p=>order.AddProduct(p));


        order.SetStore(store);
        order.SetCustomer(customer);
        order.SetDiscount(discount);

        orderRepository.Add(order);

        return order;
    }
}