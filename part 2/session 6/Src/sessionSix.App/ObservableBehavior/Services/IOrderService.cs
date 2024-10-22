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
        var products = request.Products.Select(p => productRepository.GetBy(p.Id)).ToList();
        
        var order = new Order(request.Id, store, customer, discount,products);

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
        
        order.SetStore(store);
        order.SetCustomer(customer);
        order.SetDiscount(discount);
        order.SetProducts(products);

        orderRepository.Add(order);

        return order;
    }
}