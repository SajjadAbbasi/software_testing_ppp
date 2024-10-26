using FluentAssertions;
using NSubstitute;
using sessionSix.App.ObservableBehavior.Domain;
using sessionSix.App.ObservableBehavior.Services;
using sessionSix.App.Tests.ObservableBehavior.Domain;
using sessionSix.App.Tests.ObservableBehavior.FakeObjects;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Services;

public class OrderServiceTests
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IStoreRepository _storeRepository;
    private readonly IProductRepository _productRepository;
    private readonly OrderService _sut;

    public OrderServiceTests()
    {
        _customerRepository = Substitute.For<ICustomerRepository>();
        _discountRepository = Substitute.For<IDiscountRepository>();
        _storeRepository = Substitute.For<IStoreRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _sut = new OrderService(_storeRepository, _discountRepository, _customerRepository,
            _productRepository, new OrderRepositoryFakeObject());
    }
    [Theory]
    [InlineData("CA3EA5F9-70CD-454D-BA47-F73EB6F62795")]
    public void Order_is_created_successfully(string orderId)
    {
        //arrange
        var orderTests = new OrderTests();
        orderTests.Order_is_Created_successfully(orderId);
        var order = orderTests.Sut;
        _customerRepository.GetBy(order.Customer.Id).Returns(order.Customer);
        _discountRepository.GetBy(order.Discount?.Code).Returns(order.Discount);
        _storeRepository.GetBy(order.Store.Id).Returns(order.Store);
        order.Products.ForEach(p=> _productRepository.GetBy(p.Id).Returns(p));

        var orderRequest = new CreateOrderRequest
        {
            Id = order.Id,
            CustomerId = order.Customer.Id,
            StoreId = order.Store.Id,
            DiscountCode = order.Discount?.Code,
            Products = order.Products.Select(p => new ProductRequestItem
            {
                Id = p.Id,
                Quantity = 1
            }).ToList()
        };
        //act
        var actual =_sut.CreateOrder(orderRequest);
        //assert
        actual.Id.Should().Be(order.Id);
        actual.Customer.Should().Be(order.Customer);
        actual.Discount.Should().Be(order.Discount);
        actual.Store.Should().Be(order.Store);
        actual.Products.Should().Equal(order.Products);
    }
    
    [Theory]
    [InlineData("0DA2FF23-808A-4C2D-B313-177FE8E08CB0")]
    public void Order_is_modified_successfully(string orderId)
    {
        //arrange
        Order_is_created_successfully(orderId);
        
        var customerTests = new CustomerTests();
        customerTests.Customer_is_Created_successfully(Guid.NewGuid().ToString(),"James",true);
        var discountTests = new DiscountTests();
        discountTests.Discount_is_Created_successfully(Guid.NewGuid().ToString(),"New Promo",100,true);
        var storeTests = new StoreTests();
        storeTests.Store_is_Created_successfully(Guid.NewGuid().ToString(),"MacDonald",true);
        var productTests = new ProductTests();
        productTests.Product_is_Created_successfully(Guid.NewGuid().ToString(),"Pizza",20000);
        var products = new [] { productTests.Sut }.ToList();
        
        
        _customerRepository.GetBy(customerTests.Sut.Id).Returns(customerTests.Sut);
        _discountRepository.GetBy(discountTests.Sut.Code).Returns(discountTests.Sut);
        _storeRepository.GetBy(storeTests.Sut.Id).Returns(storeTests.Sut);
        products.ForEach(p=> _productRepository.GetBy(p.Id).Returns(p));
        
        var orderRequest = new ModifyOrderRequest
        {
            Id = orderId,
            CustomerId = customerTests.Sut.Id,
            StoreId = storeTests.Sut.Id,
            DiscountCode = discountTests.Sut.Code,
            Products = products.Select(p => new ProductRequestItem
            {
                Id = p.Id,
                Quantity = 1
            }).ToList()
        };
        //act 
        var actual =_sut.UpdateOrder(orderRequest);
        //assert
        actual.Id.Should().Be(orderId);
        actual.Customer.Should().Be(customerTests.Sut);
        actual.Discount.Should().Be(discountTests.Sut);
        actual.Store.Should().Be(storeTests.Sut);
        actual.Products.Should().Equal(products);

    }
}