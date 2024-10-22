namespace sessionSix.App.ObservableBehavior.Domain;

public class Store
{
    public Store(string id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }
    
    public string Id { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; set; }
    
}