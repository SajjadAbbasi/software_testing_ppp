using sessionSix.App.ObservableBehavior.Domain;

namespace sessionSix.App.Tests.ObservableBehavior.Domain.FakeObjects;

public class StoreRepositoryFakeObject : IStoreRepository
{
    public Store GetBy(string id)
    {
        return new Store(id, "Fake Store Name", true);
    }
}