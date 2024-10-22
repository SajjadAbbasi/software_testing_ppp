namespace sessionSix.App.ObservableBehavior.Domain;

public class Discount
{
    public string Id { get; private set; }
    public string Code { get; private set; }
    public int Amount { get; private set; }
    public bool IsActive { get; private set; }

    public Discount(string id, string code, int amount, bool isActive)
    {
        Id = id;
        Code = code;
        Amount = amount;
        IsActive = isActive;
    }
}