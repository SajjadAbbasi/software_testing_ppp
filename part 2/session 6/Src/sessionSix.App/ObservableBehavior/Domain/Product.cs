using Ardalis.GuardClauses;

namespace sessionSix.App.ObservableBehavior.Domain;

public class Product
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }

    public Product(string id, string name, int price)
    {
        Id = id;
        Name = name;
        SetPrice(price);
    }

    public void SetPrice(int price)
    {
        Guard.Against.NegativeOrZero(price, message: "Product price must be greater than 0.");
        Price = price;
    }
}