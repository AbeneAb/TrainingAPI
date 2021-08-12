using Order.Domain.Interfaces.Facade;
using Order.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Guid> Add(Domain.Entities.Order order)
        {
            Order.Domain.Models.OrderModel orderModel = order.MapToModel();
            await _orderRepository.AddAsync(orderModel);
            return orderModel.Guid;
        }

        public async Task<List<Domain.Entities.Order>> GetAllOrders()
        {
            var data = await _orderRepository.GetAllAsync();
            return data?.Select(x => new Domain.Entities.Order(x)).ToList();
        }

        public async Task<List<Domain.Entities.Order>> GetByUser(string user)
        {
            var data = _orderRepository.GetQueryAsync(x => x.UserName == user);
            List<Domain.Entities.Order> orders = (await data).Select(x=> new Domain.Entities.Order(x)).ToList();
            return orders;
        }

        public Task<Domain.Entities.Order> GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(Domain.Entities.Order order)
        {
            throw new NotImplementedException();
        }
    }
}
