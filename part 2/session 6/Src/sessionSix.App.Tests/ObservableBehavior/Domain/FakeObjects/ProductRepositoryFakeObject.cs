using sessionSix.App.ObservableBehavior.Domain;

namespace sessionSix.App.Tests.ObservableBehavior.Domain.FakeObjects;

public class ProductRepositoryFakeObject : IProductRepository
{
    public Product GetBy(string id)
    {
        return new Product(id, $"Fake Product {id}", 1000);
    }
}