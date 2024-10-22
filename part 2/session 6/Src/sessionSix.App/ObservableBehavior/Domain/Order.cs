using Ardalis.GuardClauses;

namespace sessionSix.App.ObservableBehavior.Domain;

public class Order
{
    public string Id { get; private set; }
    private List<Product> _orderProducts;

    public Order(string id, Store store, Customer customer, Discount? discount,List<Product> products)
    {
        
        Id = id;
        _orderProducts = new();
        SetStore(store);
        SetCustomer(customer);
        SetDiscount(discount);
        SetProducts(products);
    }
    
    private Store Store { get; set; }
    private Customer Customer { get; set; }
    private Discount? Discount { get; set; }
    public IReadOnlyList<Product> Products => _orderProducts;
    
    public void SetStore(Store store)
    {
        Guard.Against.InvalidInput(store, "IsActive", s => !s.IsActive,
            "Store is deActivated");
        Store = store;
    }

    public void SetCustomer(Customer customer)
    {
        Guard.Against.InvalidInput(customer, "IsActive", c => !c.IsActive,
            "Customer is deActivated");
        Customer = customer;
    }

    public void SetDiscount(Discount? discount)
    {
        Guard.Against.InvalidInput(discount, "IsActive",
            d => d is not null && !d.IsActive, "Discount is deActivated");
        Discount = discount;
    }


    public void SetProducts(List<Product> products)
    {
        if (!products.Any())
            throw new Exception("AtLeast one product is required.");
        _orderProducts = products;
    }
    
}