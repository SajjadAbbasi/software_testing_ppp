using sessionSix.App.ObservableBehavior.Domain;

namespace sessionSix.App.Tests.ObservableBehavior.Domain.FakeObjects;

public class DiscountRepositoryFakeObject : IDiscountRepository
{
    public Discount? GetBy(string? id)
    {
        if (id == null)
            return null;
        return new Discount(id, "Fake Discount Code", 1000, true);
    }
}