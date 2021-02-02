using BasketMicroService.Data.Interfaces;
using StackExchange.Redis;

namespace BasketMicroService.Data
{
    public class BasketCartContext : IBasketCartContext
    {
        private readonly ConnectionMultiplexer _connection;

        public BasketCartContext(ConnectionMultiplexer connection)
        {
            _connection = connection;
            Redis = _connection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}