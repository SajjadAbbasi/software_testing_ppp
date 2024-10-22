namespace sessionSix.App.ObservableBehavior.Domain;

public class Customer
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; set; }

    public Customer(string id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }
    
}