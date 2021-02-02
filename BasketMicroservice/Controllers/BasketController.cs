using System.Net;
using System.Threading.Tasks;
using BasketMicroService.Entities;
using BasketMicroService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasketMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BasketCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> Get([FromQuery] string username)
        {
            var basketCart = await _repository.GetBasketCart(username);
            return Ok(basketCart ?? new BasketCart(username));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> Post([FromBody] BasketCart basketCart)
        {
            var updatedbasketCart = await _repository.UpdateBasketCart(basketCart);
            return Ok(updatedbasketCart);
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(string username)
        {
            return Ok(await _repository.DeleteBasketCart(username));
        }
    }
}