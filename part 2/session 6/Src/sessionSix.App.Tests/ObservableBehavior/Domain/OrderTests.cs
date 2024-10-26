using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

public class OrderTests
{
    public Order Sut { get; private set;}

    [Theory]
    [InlineData("23B76933-FFA3-401B-A924-FEF9B0F6D31C")]
    public void Order_is_Created_successfully(string orderId)
    {
        var customerTests = new CustomerTests();
        customerTests.Customer_is_Created_successfully(Guid.NewGuid().ToString(),"Alice",true);
        var discountTests = new DiscountTests();
        discountTests.Discount_is_Created_successfully(Guid.NewGuid().ToString(),"PromotionCode",1000,true);
        var storeTests = new StoreTests();
        storeTests.Store_is_Created_successfully(Guid.NewGuid().ToString(),"Amazon",true);
        var productTests = new ProductTests();
        productTests.Product_is_Created_successfully(Guid.NewGuid().ToString(),"Book",120500);
        var products = new [] { productTests.Sut }.ToList();

        //act
        Sut = new Order
        {
            Id = orderId,
            Store = storeTests.Sut,
            Discount = discountTests.Sut,
            Customer = customerTests.Sut,
            Products = products,
        };
        //assert
        Sut.Id.Should().Be(orderId);
        Sut.Store.Should().Be(storeTests.Sut);
        Sut.Discount.Should().Be(discountTests.Sut);
        Sut.Customer.Should().Be(customerTests.Sut);
        Sut.Products.Should().Equal(products);
    }
}