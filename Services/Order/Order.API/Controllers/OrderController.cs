using Microsoft.AspNetCore.Mvc;
using Order.Domain.Interfaces.Facade;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Order.API.Models;
using Microsoft.AspNetCore.Http;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet(Name = "GetAllOrders")]
        [ProducesResponseType(typeof(IEnumerable<Domain.Entities.Order>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Order>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<Domain.Entities.Order>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Order>>> GetOrdersByUserName(string userName)
        {
            var orders = await _orderService.GetByUser(userName);
            return Ok(orders);
        }
        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CheckoutOrder([FromBody] OrderPostModel order)
        {
            var newOrder = await _orderService.Add(order.MapToEntity<Domain.Entities.Order>());
            return Ok(newOrder);
        }
        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderPostModel order)
        {
            await _orderService.UpdateOrder(order.MapToEntity<Domain.Entities.Order>());
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(Guid id) 
        {
            var data = _orderService.DeleteOrder(id);
            await data;
            return NoContent();

        }
    }
}
