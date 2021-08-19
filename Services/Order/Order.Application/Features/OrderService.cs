using Order.Application.Exceptions;
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
            return orderModel.Id;
        }

        public async Task DeleteOrder(Guid id)
        {
            var orderToDelete = await _orderRepository.GetByIdAsync(id);
            if(orderToDelete == null) 
            {
                throw new NotFoundException(nameof(Domain.Entities.Order), id);
            }
            await _orderRepository.DeleteAsync(orderToDelete);
        }

        public async Task<List<Domain.Entities.Order>> GetAllOrders()
        {
            var data = await _orderRepository.GetAllAsync();
            return data?.Select(x => new Domain.Entities.Order(x)).ToList();
        }

        public async Task<List<Domain.Entities.Order>> GetByUser(string user)
        {
            var data = _orderRepository.GetAsync(x => x.UserName == user);
            List<Domain.Entities.Order> orders = (await data).Select(x=> new Domain.Entities.Order(x)).ToList();
            return orders;
        }

        public async Task<Domain.Entities.Order> GetOrder(Guid id)
        {
            var data = _orderRepository.GetByIdAsync(id);
            return new Domain.Entities.Order((await data));
        }

        public async Task UpdateOrder(Domain.Entities.Order order)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(order.Id);
            if(orderToUpdate == null) 
            {
                throw new NotFoundException(nameof(Domain.Entities.Order), order.Id);
            }
            var newOrder = order.MapToModel(orderToUpdate);
            await _orderRepository.UpdateAsync(newOrder);
        }
    }
}
