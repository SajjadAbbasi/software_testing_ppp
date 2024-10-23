using sessionSix.App.ObservableBehavior.Domain;

namespace sessionSix.App.Tests.ObservableBehavior.Domain.FakeObjects;

public class CustomerRepositoryFakeObject : ICustomerRepository 
{
    public Customer GetBy(string id)
    {
        return new Customer(id, "Fake Customer Name", true);
    }
}