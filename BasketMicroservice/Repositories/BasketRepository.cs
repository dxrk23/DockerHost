using System;
using System.Threading.Tasks;
using BasketMicroService.Data.Interfaces;
using BasketMicroService.Entities;
using BasketMicroService.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BasketMicroService.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketCartContext _context;

        public BasketRepository(IBasketCartContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> DeleteBasketCart(string username)
        {
            return await _context.Redis.KeyDeleteAsync(username);
        }

        public async Task<BasketCart> GetBasketCart(string username)
        {
            var basketCart = await _context.Redis.StringGetAsync(username);
            if (basketCart.IsNullOrEmpty) return null;

            try
            {
                return JsonConvert.DeserializeObject<BasketCart>(basketCart);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BasketCart> UpdateBasketCart(BasketCart basketCart)
        {
            var updatedbasketCart =
                await _context.Redis.StringSetAsync(basketCart.Username, JsonConvert.SerializeObject(basketCart));
            if (!updatedbasketCart) return null;

            return await GetBasketCart(basketCart.Username);
        }
    }
}