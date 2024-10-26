using sessionSix.App.ObservableBehavior.Domain;

namespace sessionSix.App.Tests.ObservableBehavior.Services;

public class OrderRepositoryFakeObject : IOrderRepository
{
    private IDictionary<string, Order> _orders = new Dictionary<string, Order>();

    public Order GetBy(string id)
    {
        return _orders[id];
    }

    public void Add(Order order)
    {
        _orders[order.Id] = order;
    }
}