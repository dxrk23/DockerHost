using StackExchange.Redis;

namespace BasketMicroService.Data.Interfaces
{
    public interface IBasketCartContext
    {
        IDatabase Redis { get; }
    }
}